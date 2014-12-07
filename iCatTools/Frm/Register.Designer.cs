namespace iCatTools.Frm
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbRegUsername = new System.Windows.Forms.TextBox();
            this.lbPwd = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.lbRegLimit = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNotRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(16, 16);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(67, 13);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "注册用户：";
            // 
            // tbRegUsername
            // 
            this.tbRegUsername.Location = new System.Drawing.Point(87, 13);
            this.tbRegUsername.MaxLength = 100;
            this.tbRegUsername.Name = "tbRegUsername";
            this.tbRegUsername.Size = new System.Drawing.Size(398, 20);
            this.tbRegUsername.TabIndex = 1;
            this.tbRegUsername.TextChanged += new System.EventHandler(this.tbRegUsername_TextChanged);
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.Location = new System.Drawing.Point(16, 46);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(67, 13);
            this.lbPwd.TabIndex = 2;
            this.lbPwd.Text = "注册密钥：";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(87, 42);
            this.tbPwd.MaxLength = 500;
            this.tbPwd.Multiline = true;
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(398, 77);
            this.tbPwd.TabIndex = 3;
            this.tbPwd.TextChanged += new System.EventHandler(this.tbRegUsername_TextChanged);
            // 
            // btnReg
            // 
            this.btnReg.Enabled = false;
            this.btnReg.Location = new System.Drawing.Point(168, 130);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 25);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "确认注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // lbRegLimit
            // 
            this.lbRegLimit.AutoSize = true;
            this.lbRegLimit.Location = new System.Drawing.Point(330, 136);
            this.lbRegLimit.Name = "lbRegLimit";
            this.lbRegLimit.Size = new System.Drawing.Size(67, 13);
            this.lbRegLimit.TabIndex = 5;
            this.lbRegLimit.Text = "注册期限：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(249, 130);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(249, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出本软件";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNotRegister
            // 
            this.btnNotRegister.Enabled = false;
            this.btnNotRegister.Location = new System.Drawing.Point(87, 130);
            this.btnNotRegister.Name = "btnNotRegister";
            this.btnNotRegister.Size = new System.Drawing.Size(75, 25);
            this.btnNotRegister.TabIndex = 8;
            this.btnNotRegister.Text = "未注册用户";
            this.btnNotRegister.UseVisualStyleBackColor = true;
            this.btnNotRegister.Click += new System.EventHandler(this.btnNotRegister_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 167);
            this.Controls.Add(this.btnNotRegister);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRegLimit);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lbPwd);
            this.Controls.Add(this.tbRegUsername);
            this.Controls.Add(this.lbUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Register";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册本软件（版权所有，翻版枪毙）";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbRegUsername;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label lbRegLimit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNotRegister;
    }
}