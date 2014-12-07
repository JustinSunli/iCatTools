/****************************************
###创建人：lify
###创建时间：2012-07-29
###公司：Cat Studio
###最后修改时间：2012-07-29
###最后修改人：lify
###修改摘要：更新后启动软件，顺便把自动更新的软件也更新了
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

namespace iCatTools.business
{
    class AutoUpdate
    {
        private static int aaa = 0;

        private static void DirSearch(string strBaseDir, ArrayList fileList)
        {
            DirectoryInfo di = new DirectoryInfo(strBaseDir);
            DirectoryInfo[] diA = di.GetDirectories();
            if (aaa == 0)
            {
                FileInfo[] fis2 = di.GetFiles();   //有关目录下的文件   
                for (int i2 = 0; i2 < fis2.Length; i2++)
                {
                    fileList.Add(fis2[i2].FullName);
                    //fis2[i2].FullName是根目录中文件的绝对地址，把它记录在ArrayList中
                }
            }
            for (int i = 0; i < diA.Length; i++)
            {
                aaa++;
                fileList.Add(diA[i].FullName); //+ "\t<目录>"
                //diA[i].FullName是某个子目录的绝对地址，把它记录在ArrayList中
                DirectoryInfo di1 = new DirectoryInfo(diA[i].FullName);
                DirectoryInfo[] diA1 = di1.GetDirectories();
                FileInfo[] fis1 = di1.GetFiles();   //有关目录下的文件   
                for (int ii = 0; ii < fis1.Length; ii++)
                {
                    fileList.Add(fis1[ii].FullName);
                    //fis1[ii].FullName是某个子目录中文件的绝对地址，把它记录在ArrayList中

                }
                DirSearch(diA[i].FullName, fileList);
                //注意：递归了。逻辑思维正常的人应该能反应过来
            }
        }
        private static string[] getUpdateList(string sDir)
        {
            string updateDir = Application.StartupPath + "\\" + (sDir);
            ArrayList fileList = new ArrayList();

            DirSearch(updateDir, fileList);
            string[] filePathArr = new string[fileList.Count];
            for (int i = 0; i < fileList.Count; i++)
                filePathArr[i] = fileList[i].ToString();
            return filePathArr;
        }
        private static string getFileName(string path)
        {
            string[] segment = path.Split('\\');
            return segment[segment.Length - 1];
        }
        private static string getDirPath()
        {
            string updateDir = AppDomain.CurrentDomain.BaseDirectory + "update\\";
            if (!Directory.Exists(updateDir))
                Directory.CreateDirectory(updateDir);
            return updateDir;
        }
        public static void Execute()
        {
            //FileList flist = new FileList();
            string filename = "";
            string saveDir = getDirPath();
            byte[] fileBuffer;
            foreach (string filePath in getUpdateList("update"))
            {
                filename = getFileName(filePath);
                if (filename == "GenAutoUpdate.exe" || filename == "GenAutoUpdate.exe.config")
                {
                    fileBuffer = File.ReadAllBytes(filePath);
                    FileStream downloadfs = new FileStream(saveDir.Replace("update\\", "") + filename, FileMode.Create, FileAccess.Write);
                    downloadfs.Write(fileBuffer, 0, fileBuffer.Length);
                    downloadfs.Close();
                    File.Delete(filePath);
                    Thread.Sleep(10);
                }
            }

        }
    }
}
