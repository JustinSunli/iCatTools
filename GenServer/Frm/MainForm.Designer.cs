namespace GenServer.Frm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.服务端管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStartListen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpdateClient = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mainFrmstatusStrip = new System.Windows.Forms.StatusStrip();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.nIconSystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.客户端管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenKey = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务端管理ToolStripMenuItem,
            this.客户端管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 服务端管理ToolStripMenuItem
            // 
            this.服务端管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStartListen,
            this.tsmViewClient,
            this.tsmUpdateClient});
            this.服务端管理ToolStripMenuItem.Name = "服务端管理ToolStripMenuItem";
            this.服务端管理ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.服务端管理ToolStripMenuItem.Text = "服务端管理";
            // 
            // tsmStartListen
            // 
            this.tsmStartListen.Name = "tsmStartListen";
            this.tsmStartListen.Size = new System.Drawing.Size(154, 22);
            this.tsmStartListen.Text = "开启侦听";
            this.tsmStartListen.Click += new System.EventHandler(this.tsmStartListen_Click);
            // 
            // tsmViewClient
            // 
            this.tsmViewClient.Name = "tsmViewClient";
            this.tsmViewClient.Size = new System.Drawing.Size(154, 22);
            this.tsmViewClient.Text = "显示在线客户端";
            this.tsmViewClient.Click += new System.EventHandler(this.tsmViewClient_Click);
            // 
            // tsmUpdateClient
            // 
            this.tsmUpdateClient.Name = "tsmUpdateClient";
            this.tsmUpdateClient.Size = new System.Drawing.Size(154, 22);
            this.tsmUpdateClient.Text = "更新客户端";
            this.tsmUpdateClient.Click += new System.EventHandler(this.tsmUpdateClient_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mainFrmstatusStrip);
            this.groupBox1.Controls.Add(this.tbConsole);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            // 
            // mainFrmstatusStrip
            // 
            this.mainFrmstatusStrip.Location = new System.Drawing.Point(3, 294);
            this.mainFrmstatusStrip.Name = "mainFrmstatusStrip";
            this.mainFrmstatusStrip.Size = new System.Drawing.Size(580, 22);
            this.mainFrmstatusStrip.TabIndex = 1;
            this.mainFrmstatusStrip.Text = "statusStrip1";
            // 
            // tbConsole
            // 
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Location = new System.Drawing.Point(3, 17);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.Size = new System.Drawing.Size(580, 299);
            this.tbConsole.TabIndex = 0;
            // 
            // nIconSystem
            // 
            this.nIconSystem.Icon = ((System.Drawing.Icon)(resources.GetObject("nIconSystem.Icon")));
            this.nIconSystem.Text = "notifyIcon1";
            this.nIconSystem.Visible = true;
            // 
            // 客户端管理ToolStripMenuItem
            // 
            this.客户端管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenKey});
            this.客户端管理ToolStripMenuItem.Name = "客户端管理ToolStripMenuItem";
            this.客户端管理ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.客户端管理ToolStripMenuItem.Text = "客户端管理";
            // 
            // tsmGenKey
            // 
            this.tsmGenKey.Name = "tsmGenKey";
            this.tsmGenKey.Size = new System.Drawing.Size(152, 22);
            this.tsmGenKey.Text = "密钥生成";
            this.tsmGenKey.Click += new System.EventHandler(this.tsmGenKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成器服务端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务端管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmStartListen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmViewClient;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.NotifyIcon nIconSystem;
        private System.Windows.Forms.StatusStrip mainFrmstatusStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateClient;
        private System.Windows.Forms.ToolStripMenuItem 客户端管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGenKey;
    }
}