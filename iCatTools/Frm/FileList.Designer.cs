namespace iCatTools.Frm
{
    partial class FileList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbfilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbModifytime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCreatetime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvFileList = new System.Windows.Forms.TreeView();
            this.imglistTreeview = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExcelViewFilelist = new System.Windows.Forms.Button();
            this.btnSelectFileGrid = new System.Windows.Forms.Button();
            this.btnSelectTopFolder = new System.Windows.Forms.Button();
            this.tbTopFolderPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Dlgtopfolderbrower = new System.Windows.Forms.FolderBrowserDialog();
            this.folderSaveDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbfilePath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbModifytime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbCreatetime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFileSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件属性";
            // 
            // tbfilePath
            // 
            this.tbfilePath.Location = new System.Drawing.Point(148, 79);
            this.tbfilePath.Name = "tbfilePath";
            this.tbfilePath.ReadOnly = true;
            this.tbfilePath.Size = new System.Drawing.Size(546, 20);
            this.tbfilePath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "文件全路径：";
            // 
            // tbModifytime
            // 
            this.tbModifytime.Location = new System.Drawing.Point(451, 53);
            this.tbModifytime.Name = "tbModifytime";
            this.tbModifytime.ReadOnly = true;
            this.tbModifytime.Size = new System.Drawing.Size(243, 20);
            this.tbModifytime.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "修改时间：";
            // 
            // tbCreatetime
            // 
            this.tbCreatetime.Location = new System.Drawing.Point(148, 53);
            this.tbCreatetime.Name = "tbCreatetime";
            this.tbCreatetime.ReadOnly = true;
            this.tbCreatetime.Size = new System.Drawing.Size(224, 20);
            this.tbCreatetime.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "创建时间：";
            // 
            // tbFileSize
            // 
            this.tbFileSize.Location = new System.Drawing.Point(451, 27);
            this.tbFileSize.Name = "tbFileSize";
            this.tbFileSize.ReadOnly = true;
            this.tbFileSize.Size = new System.Drawing.Size(243, 20);
            this.tbFileSize.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件大小：";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(148, 27);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(224, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "原目录或文件名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tvFileList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 368);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件列表";
            // 
            // tvFileList
            // 
            this.tvFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFileList.ImageIndex = 0;
            this.tvFileList.ImageList = this.imglistTreeview;
            this.tvFileList.Location = new System.Drawing.Point(3, 16);
            this.tvFileList.Name = "tvFileList";
            this.tvFileList.SelectedImageIndex = 0;
            this.tvFileList.Size = new System.Drawing.Size(713, 349);
            this.tvFileList.TabIndex = 0;
            this.tvFileList.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvFileList_AfterLabelEdit);
            this.tvFileList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFileList_AfterSelect);
            this.tvFileList.DoubleClick += new System.EventHandler(this.tvFileList_DoubleClick);
            // 
            // imglistTreeview
            // 
            this.imglistTreeview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistTreeview.ImageStream")));
            this.imglistTreeview.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistTreeview.Images.SetKeyName(0, "folder_closed_16x16.gif");
            this.imglistTreeview.Images.SetKeyName(1, "notepad_16x16.gif");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnExcelViewFilelist);
            this.groupBox3.Controls.Add(this.btnSelectFileGrid);
            this.groupBox3.Controls.Add(this.btnSelectTopFolder);
            this.groupBox3.Controls.Add(this.tbTopFolderPath);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(719, 87);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "请选择顶层文件夹";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "注明：双击列表节点可修改文件名或目录名";
            // 
            // btnExcelViewFilelist
            // 
            this.btnExcelViewFilelist.Location = new System.Drawing.Point(320, 48);
            this.btnExcelViewFilelist.Name = "btnExcelViewFilelist";
            this.btnExcelViewFilelist.Size = new System.Drawing.Size(133, 23);
            this.btnExcelViewFilelist.TabIndex = 7;
            this.btnExcelViewFilelist.Text = "导出查看文件列表";
            this.btnExcelViewFilelist.UseVisualStyleBackColor = true;
            this.btnExcelViewFilelist.Click += new System.EventHandler(this.btnExcelViewFilelist_Click);
            // 
            // btnSelectFileGrid
            // 
            this.btnSelectFileGrid.Location = new System.Drawing.Point(148, 48);
            this.btnSelectFileGrid.Name = "btnSelectFileGrid";
            this.btnSelectFileGrid.Size = new System.Drawing.Size(166, 23);
            this.btnSelectFileGrid.TabIndex = 6;
            this.btnSelectFileGrid.Text = "所有文件另存为根目录……";
            this.btnSelectFileGrid.UseVisualStyleBackColor = true;
            this.btnSelectFileGrid.Click += new System.EventHandler(this.btnSelectFileGrid_Click);
            // 
            // btnSelectTopFolder
            // 
            this.btnSelectTopFolder.Location = new System.Drawing.Point(619, 20);
            this.btnSelectTopFolder.Name = "btnSelectTopFolder";
            this.btnSelectTopFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTopFolder.TabIndex = 5;
            this.btnSelectTopFolder.Text = "浏览……";
            this.btnSelectTopFolder.UseVisualStyleBackColor = true;
            this.btnSelectTopFolder.Click += new System.EventHandler(this.btnSelectTopFolder_Click);
            // 
            // tbTopFolderPath
            // 
            this.tbTopFolderPath.Location = new System.Drawing.Point(148, 22);
            this.tbTopFolderPath.Name = "tbTopFolderPath";
            this.tbTopFolderPath.ReadOnly = true;
            this.tbTopFolderPath.Size = new System.Drawing.Size(465, 20);
            this.tbTopFolderPath.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "最顶层文件夹：";
            // 
            // folderSaveDialog
            // 
            this.folderSaveDialog.Description = "请选择保存目录";
            // 
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件管理";
            this.Load += new System.EventHandler(this.FileList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tvFileList;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSelectTopFolder;
        private System.Windows.Forms.TextBox tbTopFolderPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog Dlgtopfolderbrower;
        private System.Windows.Forms.ImageList imglistTreeview;
        private System.Windows.Forms.TextBox tbfilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbModifytime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCreatetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExcelViewFilelist;
        private System.Windows.Forms.Button btnSelectFileGrid;
        private System.Windows.Forms.FolderBrowserDialog folderSaveDialog;
    }
}