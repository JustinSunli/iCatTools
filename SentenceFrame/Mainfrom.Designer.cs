namespace SentenceFrame
{
    partial class Mainfrom
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbXMLFile = new System.Windows.Forms.TextBox();
            this.btnBrowserFile = new System.Windows.Forms.Button();
            this.btnGenTXT = new System.Windows.Forms.Button();
            this.openXMLFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择XML路径：";
            // 
            // tbXMLFile
            // 
            this.tbXMLFile.Location = new System.Drawing.Point(144, 36);
            this.tbXMLFile.Name = "tbXMLFile";
            this.tbXMLFile.Size = new System.Drawing.Size(201, 20);
            this.tbXMLFile.TabIndex = 1;
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(351, 34);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFile.TabIndex = 2;
            this.btnBrowserFile.Text = "浏览…";
            this.btnBrowserFile.UseVisualStyleBackColor = true;
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // btnGenTXT
            // 
            this.btnGenTXT.Location = new System.Drawing.Point(144, 62);
            this.btnGenTXT.Name = "btnGenTXT";
            this.btnGenTXT.Size = new System.Drawing.Size(141, 23);
            this.btnGenTXT.TabIndex = 3;
            this.btnGenTXT.Text = "生成TXT数据文件";
            this.btnGenTXT.UseVisualStyleBackColor = true;
            this.btnGenTXT.Click += new System.EventHandler(this.btnGenTXT_Click);
            // 
            // openXMLFile
            // 
            this.openXMLFile.FileName = "openFileDialog1";
            // 
            // Mainfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 119);
            this.Controls.Add(this.btnGenTXT);
            this.Controls.Add(this.btnBrowserFile);
            this.Controls.Add(this.tbXMLFile);
            this.Controls.Add(this.label1);
            this.Name = "Mainfrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrameNet特征选择匹配";
            this.Load += new System.EventHandler(this.Mainfrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbXMLFile;
        private System.Windows.Forms.Button btnBrowserFile;
        private System.Windows.Forms.Button btnGenTXT;
        private System.Windows.Forms.OpenFileDialog openXMLFile;
    }
}