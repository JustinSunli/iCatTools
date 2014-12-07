namespace iCatTools.Frm
{
    partial class NotRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotRegister));
            this.btnCopyIDToClipBorad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDiskID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopyIDToClipBorad
            // 
            this.btnCopyIDToClipBorad.Location = new System.Drawing.Point(12, 119);
            this.btnCopyIDToClipBorad.Name = "btnCopyIDToClipBorad";
            this.btnCopyIDToClipBorad.Size = new System.Drawing.Size(152, 25);
            this.btnCopyIDToClipBorad.TabIndex = 5;
            this.btnCopyIDToClipBorad.Text = "复制上面信息到剪贴板";
            this.btnCopyIDToClipBorad.UseVisualStyleBackColor = true;
            this.btnCopyIDToClipBorad.Click += new System.EventHandler(this.btnCopyIDToClipBorad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "请复制以下信息发给管理员进行注册：";
            // 
            // tbDiskID
            // 
            this.tbDiskID.Location = new System.Drawing.Point(12, 35);
            this.tbDiskID.Multiline = true;
            this.tbDiskID.Name = "tbDiskID";
            this.tbDiskID.ReadOnly = true;
            this.tbDiskID.Size = new System.Drawing.Size(473, 78);
            this.tbDiskID.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(337, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭该窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NotRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 167);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbDiskID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyIDToClipBorad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NotRegister";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我还未注册用户，即将支持正版！";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NotRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopyIDToClipBorad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDiskID;
        private System.Windows.Forms.Button btnClose;
    }
}