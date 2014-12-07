using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using GenAutoUpdate.common;

namespace GenAutoUpdate
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        public delegate void UpdatePbControl(object ctrl, object value, object pbCtrl, object pbValue);
        public void UpdatePb_Method(object ctrl, object value, object pbCtrl, object pbValue)
        {
            #region
            int iPbValue = Int16.Parse(pbValue.ToString());
            TextBox lbl = (TextBox)ctrl;
            lbl.AppendText(value.ToString());
            ProgressBar pb = (ProgressBar)pbCtrl;
            pb.Value = iPbValue;
            //if (iPbValue == 100)
            //    pb.Visible = false;
            #endregion
        }

        private string getDirPath()
        {
            string updateDir = AppDomain.CurrentDomain.BaseDirectory + "update\\";
            if (!Directory.Exists(updateDir))
                Directory.CreateDirectory(updateDir);
            return updateDir;
        }

        private string getFileName(string path)
        {
            string[] segment = path.Split('\\');
            return segment[segment.Length - 1];
        }
        private delegate void DlDownloadUpdateFile(UpdatePbControl updateDl);
        private void downLoadUpdateFile(UpdatePbControl updateDl)
        {
            GenClientAutoUpdate.GenClientAutoUpdateSoapClient hello = new GenClientAutoUpdate.GenClientAutoUpdateSoapClient();
            //this.tbConsole.AppendText("---开始获取服务端更新文件列表---\r\n");
            List<String> fileList = hello.getUpdateList("updatefile/");
            long fileByte = 0;
            int readByte = 0;
            string filename = "";
            string httpDir = hello.Endpoint.ListenUri.ToString().Replace("GenClientAutoUpdate.asmx", "");
            string saveDir = getDirPath();
            byte[] fileBuffer;
            int fileCount = 0;
            foreach (string filePath in fileList)
            {
                fileCount++;
                //this.tbConsole.AppendText(httpDir + filePath.Replace("\\", "/") + "\r\n");

                filename = getFileName(filePath);
                System.Net.WebRequest rqst = System.Net.WebRequest.Create(httpDir + filePath.Replace("\\", "/"));
                System.Net.WebResponse rsps = rqst.GetResponse();
                fileByte = rsps.ContentLength;
                System.IO.Stream myStream = rsps.GetResponseStream();
                fileBuffer = new byte[fileByte];
                FileStream downloadfs = new FileStream(saveDir + filename, FileMode.Create, FileAccess.Write);
                while ((readByte = myStream.Read(fileBuffer, 0, (int)fileByte)) != 0)
                    downloadfs.Write(fileBuffer, 0, readByte);
                this.BeginInvoke(updateDl, new object[] { this.tbConsole, "正在下载文件---" + filename + "\r\n", this.pbUpdate, fileCount * 100 / fileList.Count });
                downloadfs.Close();
                Thread.Sleep(10);
            }
            FileList flist = new FileList();
            fileCount = 0;
            foreach (string filePath in flist.getUpdateList("update"))
            {
                filename = getFileName(filePath);
                if (filename == "GenAutoUpdate.exe" || filename == "GenAutoUpdate.exe.config")
                    continue;
                foreach (string fileupdatePath in fileList)
                {
                    if (fileupdatePath.IndexOf(filename)>-1)
                    {
                        fileCount++;
                        fileBuffer = File.ReadAllBytes(filePath);
                        FileStream downloadfs = new FileStream(saveDir.Replace("update\\", "") + filename, FileMode.Create, FileAccess.Write);
                        downloadfs.Write(fileBuffer, 0, fileBuffer.Length);
                        this.BeginInvoke(updateDl, new object[] { this.tbConsole, "正在更新文件---" + filename + "\r\n", this.pbUpdate, fileCount * 100 / fileList.Count });
                        downloadfs.Close();
                        File.Delete(filePath);
                    }
                }
                Thread.Sleep(10);
            }
        }
        /*此种Copy方法有误，需深究
        public void CopyDirectory(string sourceDirName, string destDirName)
        {
            int total = 0;
            try
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                    File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));

                }

                if (destDirName[destDirName.Length - 1] != Path.DirectorySeparatorChar)
                    destDirName = destDirName + Path.DirectorySeparatorChar;

                string[] files = Directory.GetFiles(sourceDirName);
                foreach (string file in files)
                {
                    if (File.Exists(destDirName + Path.GetFileName(file)))
                        continue;
                    File.Copy(file, destDirName + Path.GetFileName(file), true);
                    File.SetAttributes(destDirName + Path.GetFileName(file), FileAttributes.Normal);
                    Thread.Sleep(10);
                    total++;
                }

                string[] dirs = Directory.GetDirectories(sourceDirName);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destDirName + Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\log.txt", true);
                sw.Write(ex.Message + "     " + DateTime.Now + "\r\n");
                sw.Close();
            }
        }
        */

        public void downloadCallback(IAsyncResult ar)
        {
            #region
            DlDownloadUpdateFile dl_do = (DlDownloadUpdateFile)ar.AsyncState;
            dl_do.EndInvoke(ar);
            //this.tbConsole.AppendText("-----------全部更新完成-----------");
            if (MessageBase.ShowConfirm("您确认要现在运行新版本应用程序？") == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\GenerateCode.exe");
            }
            System.Environment.Exit(0);
            
            //CopyDirectory(getDirPath(), getDirPath().Replace("update\\", ""));
            #endregion
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            
            UpdatePbControl updatePbControl = new UpdatePbControl(this.UpdatePb_Method);
            DlDownloadUpdateFile dldownload = new DlDownloadUpdateFile(this.downLoadUpdateFile);
            AsyncCallback callbak = new AsyncCallback(this.downloadCallback);
            dldownload.BeginInvoke(updatePbControl, callbak, dldownload);
        }
    }
}
