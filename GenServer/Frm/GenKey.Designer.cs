namespace GenServer.Frm
{
    partial class GenKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenKey));
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.lbKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.lbMachineID = new System.Windows.Forms.Label();
            this.tbHardDiskID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(74, 15);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(55, 13);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "用户名：";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(132, 12);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(312, 20);
            this.tbUsername.TabIndex = 1;
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Location = new System.Drawing.Point(50, 41);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(79, 13);
            this.lbStartTime.TabIndex = 2;
            this.lbStartTime.Text = "开始有效期：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(132, 38);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(312, 20);
            this.dtpStartTime.TabIndex = 3;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(132, 64);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(312, 20);
            this.dtpEndTime.TabIndex = 4;
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(50, 67);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(79, 13);
            this.lbEndTime.TabIndex = 5;
            this.lbEndTime.Text = "截止有效期：";
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(83, 119);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(43, 13);
            this.lbKey.TabIndex = 6;
            this.lbKey.Text = "密钥：";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(132, 116);
            this.tbKey.Multiline = true;
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(312, 94);
            this.tbKey.TabIndex = 7;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(132, 216);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(120, 25);
            this.btnGen.TabIndex = 8;
            this.btnGen.Text = "密钥生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // lbMachineID
            // 
            this.lbMachineID.AutoSize = true;
            this.lbMachineID.Location = new System.Drawing.Point(14, 93);
            this.lbMachineID.Name = "lbMachineID";
            this.lbMachineID.Size = new System.Drawing.Size(115, 13);
            this.lbMachineID.TabIndex = 9;
            this.lbMachineID.Text = "用户机器唯一标识：";
            // 
            // tbHardDiskID
            // 
            this.tbHardDiskID.Location = new System.Drawing.Point(132, 90);
            this.tbHardDiskID.Name = "tbHardDiskID";
            this.tbHardDiskID.Size = new System.Drawing.Size(312, 20);
            this.tbHardDiskID.TabIndex = 10;
            // 
            // GenKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 252);
            this.Controls.Add(this.tbHardDiskID);
            this.Controls.Add(this.lbMachineID);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lbStartTime);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.lbUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenKey";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端密钥生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label lbMachineID;
        private System.Windows.Forms.TextBox tbHardDiskID;
    }
}