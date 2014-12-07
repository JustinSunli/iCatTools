using iCatTools.common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatTools.Frm
{
    public partial class FileList : Form
    {
        public static void TopShow()
        {
            FileList filelist = new FileList();
            filelist.Show();
        } 

        public FileList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileList_Load(object sender, EventArgs e)
        {
            #region

            this.tvFileList.LabelEdit = true;//可编辑状态。
            /*
             * string stationip = "";
            TreeNode rootnode = new TreeNode("NNN");
            foreach (string client in clientStationno)
            {
                stationip = getStationIp(_StaitonSetData, client);
                string nodetext = client + ":" + stationip;
                TreeNode node = new TreeNode(nodetext);
                node.Tag = client;
                rootnode.Nodes.Add(node);
            }
            treeClient.Nodes.Add(rootnode);
             * */
            #endregion
        }

        #region 列出所有文件目录（已注释）
        /*
        public ArrayList al = new ArrayList();//定义存储文件和文件夹名的数组
        public bool isFirst = false;
        private void GetAllDirList(string strBaseDir)
        {
            #region
            DirectoryInfo di = new DirectoryInfo(strBaseDir);
            DirectoryInfo[] diA = di.GetDirectories();
            if (isFirst)
            {
                FileInfo[] fis2 = di.GetFiles();   //有关目录下的文件

                for (int i2 = 0; i2 < fis2.Length; i2++)
                    al.Add(fis2[i2].FullName);

            }
            for (int i = 0; i < diA.Length; i++)
            {
                isFirst = true;
                al.Add(diA[i].FullName + "\t<目录>");
                DirectoryInfo di1 = new DirectoryInfo(diA[i].FullName);
                DirectoryInfo[] diA1 = di1.GetDirectories();
                FileInfo[] fis1 = di1.GetFiles();   //有关目录下的文件   

                for (int ii = 0; ii < fis1.Length;ii++ )
                    al.Add(fis1[ii].FullName);

                GetAllDirList(diA[i].FullName);
            }
            #endregion
        }
        */
        #endregion
        /// <summary>
        /// 选择目录后显示文件结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectTopFolder_Click(object sender, EventArgs e)
        {
            #region
            DialogResult dlgresult = this.Dlgtopfolderbrower.ShowDialog();
            if (dlgresult == DialogResult.OK)
            {
                filePathList.Clear();
                string path = this.Dlgtopfolderbrower.SelectedPath;
                this.tbTopFolderPath.Text = path;
                this.relateTreeView(this.tvFileList, path);
            }
            #endregion
        }
        /// <summary>
        /// 构建指定目录的树形结构
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="path"></param>
        private void relateTreeView(TreeView tv, string path)
        {
            #region
            tv.Nodes.Clear();
            tv.Nodes.Add(new TreeNode());
            string[] pathinfo = Path.GetFullPath(path.Trim()).Split(char.Parse("\\"));
            tv.Nodes[0].Text = pathinfo[pathinfo.Length - 1];
            tv.Nodes[0].Name = path;
            tv.Nodes[0].Tag = path;
            tv.Nodes[0].Expand();

            traversingCatalog(tv.Nodes[0], path);
            #endregion
        }
        /// <summary>
        /// 递归遍历目录
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool traversingCatalog(TreeNode tn, string path)
        {
            #region
            if (!Directory.Exists(path))
                return false;
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            DirectoryInfo[] insidedirinfos = dirinfo.GetDirectories();
            FileInfo[] fileinfos = dirinfo.GetFiles("*.*");
            int allnum = insidedirinfos.Length + fileinfos.Length;
            if (allnum == 0)
            {
                TreeNode empty = new TreeNode();
                empty.Text = "(空白)";
                empty.Name = "";
                empty.Tag = "";
                empty.ImageIndex = 0;
                tn.Nodes.Add(empty);
                return false;
            }

            int folderindex = -1;
            foreach (DirectoryInfo folder in insidedirinfos)
            {
                folderindex++;
                TreeNode foldernode = new TreeNode();
                foldernode.Text = folder.Name;
                foldernode.Name = folder.Name;
                foldernode.Tag = folder.FullName;
                foldernode.ToolTipText = folder.Name;
                foldernode.Expand();
                foldernode.ImageIndex = 0;
                tn.Nodes.Add(foldernode);

                traversingCatalog(tn.Nodes[folderindex], path+"/"+folder.Name);
            }

            foreach (FileInfo file in fileinfos)
            {
                TreeNode fileNode = new TreeNode();
                fileNode.Text = file.Name;
                fileNode.Name = file.FullName;
                fileNode.Tag = file.FullName;
                fileNode.ToolTipText = file.Name;
                fileNode.Expand();
                fileNode.ImageIndex = 1;
                fileNode.SelectedImageIndex = 1;
                filePathList.Add(file.FullName);
                tn.Nodes.Add(fileNode);
            }
            return true;
            #endregion
        }
        private string oldFilename = "";
        public List<string> filePathList = new List<string>();
        private string oldPath = "";
        /// <summary>
        /// 双击节点修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFileList_DoubleClick(object sender, EventArgs e)
        {
            #region
            if (this.tvFileList.SelectedNode == null)
                return;

            this.tvFileList.SelectedNode.BeginEdit();
            //this.viewFileInformation();
            #endregion
        }
        /// <summary>
        /// 节点信息编辑后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFileList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            #region
            if (e.Label == null)
                return;

            string newfilename = oldPath + "\\" + e.Label;

            if (oldFilename != newfilename)
            {
                FileInfo inf = new FileInfo(oldFilename);
                inf.MoveTo(newfilename);
                e.Node.Tag = newfilename;
                e.Node.ToolTipText = newfilename;
                RemoveChildNodes(e.Node);

                traversingCatalog(e.Node, newfilename);
            }
            #endregion
        }
        /// <summary>
        /// 删除指定节点的所有子节点
        /// </summary>
        /// <param name="aNode"></param>
        private void RemoveChildNodes(TreeNode aNode)
        {
            #region
            if (aNode.Nodes.Count > 0)
            {
                for (int i = aNode.Nodes.Count - 1; i >= 0; i--)
                {
                    aNode.Nodes[i].Remove();
                }
            }
            #endregion
        }

        /// <summary>
        /// 显示文件信息
        /// </summary>
        private void viewFileInformation()
        {
            #region
            string filename = "";
            oldFilename = this.tvFileList.SelectedNode.Tag.ToString();
            int lastindex = oldFilename.LastIndexOf("\\");
            oldPath = oldFilename.Substring(0, lastindex);
            filename = oldFilename.Substring(lastindex + 1, oldFilename.Length - oldPath.Length - 1);

            FileInfo inf = new FileInfo(oldFilename);
            this.tbfilePath.Text = oldFilename;
            this.tbCreatetime.Text = inf.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tbModifytime.Text = inf.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tbFileName.Text = filename;

            if (File.Exists(oldFilename))
                this.tbFileSize.Text = getFileSize(inf.Length);
            #endregion
        }

        private string getfileName(string path)
        {
            #region
            int lastindex = path.LastIndexOf("\\");
            string oldPath = path.Substring(0, lastindex);
            return path.Substring(lastindex + 1, path.Length - oldPath.Length - 1);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string getFileSize(long bytes)
        {
            #region
            string size = "";
            if (bytes >= 1024 * 1024 * 1024)
                size = ((double)bytes / (1024 * 1024 * 1024)).ToString("F2") + " GB";
            else if (bytes >= 1024 * 1024)
                size = ((double)bytes / (1024 * 1024)).ToString("F2") + " MB";
            else if (bytes >= 1024)
                size = ((double)bytes / 1024).ToString("F2") + " KB";
            else
                size = bytes.ToString() + " Bytes";
            return size;
            #endregion
        }
        /// <summary>
        /// 选择节点后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region
            if (this.tvFileList.SelectedNode == null)
                return;
            viewFileInformation();
            #endregion
        }

        private void btnSelectFileGrid_Click(object sender, EventArgs e)
        {
            #region

            if (string.IsNullOrEmpty(this.tbTopFolderPath.Text))
            {
                MessageBase.Show("请选择目录树根路径！");
                return;
            }
            string oldFolder = getfileName(this.tbTopFolderPath.Text);
            if (this.folderSaveDialog.ShowDialog() == DialogResult.OK)
            {
                string dir = this.folderSaveDialog.SelectedPath + "\\" + oldFolder;
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                for (int i = 0; i < filePathList.Count; i++)
                { 
                    string filename = getfileName(filePathList[i]);
                    if (File.Exists(filePathList[i]))
                        File.Copy(filePathList[i], dir +"\\"+ filename);
                }
            }
            #endregion
        }

        private void btnExcelViewFilelist_Click(object sender, EventArgs e)
        {
            MessageBase.Show("恭喜你，你碰到GUI了！");
            MessageBase.Show("到底有木有？");
        }

    }
}
