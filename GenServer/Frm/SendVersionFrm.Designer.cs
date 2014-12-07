namespace GenServer.Frm
{
    partial class SendVersionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendVersionFrm));
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tvOnlineList = new System.Windows.Forms.TreeView();
            this.gbOnlineList = new System.Windows.Forms.GroupBox();
            this.gbUpdateClient = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbOnlineList.SuspendLayout();
            this.gbUpdateClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(35, 62);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(164, 21);
            this.tbVersion.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(35, 168);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(102, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "更新客户端";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tvOnlineList
            // 
            this.tvOnlineList.CheckBoxes = true;
            this.tvOnlineList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOnlineList.Location = new System.Drawing.Point(3, 17);
            this.tvOnlineList.Name = "tvOnlineList";
            this.tvOnlineList.Size = new System.Drawing.Size(194, 326);
            this.tvOnlineList.TabIndex = 2;
            // 
            // gbOnlineList
            // 
            this.gbOnlineList.Controls.Add(this.tvOnlineList);
            this.gbOnlineList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbOnlineList.Location = new System.Drawing.Point(0, 0);
            this.gbOnlineList.Name = "gbOnlineList";
            this.gbOnlineList.Size = new System.Drawing.Size(200, 346);
            this.gbOnlineList.TabIndex = 3;
            this.gbOnlineList.TabStop = false;
            this.gbOnlineList.Text = "在线客户端列表";
            // 
            // gbUpdateClient
            // 
            this.gbUpdateClient.Controls.Add(this.label1);
            this.gbUpdateClient.Controls.Add(this.btnSend);
            this.gbUpdateClient.Controls.Add(this.tbVersion);
            this.gbUpdateClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUpdateClient.Location = new System.Drawing.Point(200, 0);
            this.gbUpdateClient.Name = "gbUpdateClient";
            this.gbUpdateClient.Size = new System.Drawing.Size(239, 346);
            this.gbUpdateClient.TabIndex = 4;
            this.gbUpdateClient.TabStop = false;
            this.gbUpdateClient.Text = "更新客户端";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "最新客户端版本：";
            // 
            // SendVersionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 346);
            this.Controls.Add(this.gbUpdateClient);
            this.Controls.Add(this.gbOnlineList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SendVersionFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新客户端版本";
            this.Load += new System.EventHandler(this.SendVersionFrm_Load);
            this.gbOnlineList.ResumeLayout(false);
            this.gbUpdateClient.ResumeLayout(false);
            this.gbUpdateClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TreeView tvOnlineList;
        private System.Windows.Forms.GroupBox gbOnlineList;
        private System.Windows.Forms.GroupBox gbUpdateClient;
        private System.Windows.Forms.Label label1;
    }
}