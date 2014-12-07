namespace iCatTools.Frm
{
    partial class SetUIParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUIParams));
            this.lbNamespace = new System.Windows.Forms.Label();
            this.tbUINamespace = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbHandlerName = new System.Windows.Forms.TextBox();
            this.lbHandlerName = new System.Windows.Forms.Label();
            this.cbPerpageRecord = new System.Windows.Forms.ComboBox();
            this.lbPerpageRecord = new System.Windows.Forms.Label();
            this.tbStartrecord = new System.Windows.Forms.TextBox();
            this.lbStartrecord = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDeleteInformation = new System.Windows.Forms.TextBox();
            this.lbDeleteInformation = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbQueryTitle = new System.Windows.Forms.TextBox();
            this.lbQueryTitle = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbNewEditTitle = new System.Windows.Forms.TextBox();
            this.lbNewEditTitle = new System.Windows.Forms.Label();
            this.btniCatTools = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbQuery = new System.Windows.Forms.CheckBox();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.cbNewEdit = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNamespace
            // 
            this.lbNamespace.AutoSize = true;
            this.lbNamespace.Location = new System.Drawing.Point(33, 31);
            this.lbNamespace.Name = "lbNamespace";
            this.lbNamespace.Size = new System.Drawing.Size(90, 13);
            this.lbNamespace.TabIndex = 0;
            this.lbNamespace.Text = "UI层命名空间：";
            // 
            // tbUINamespace
            // 
            this.tbUINamespace.Location = new System.Drawing.Point(128, 28);
            this.tbUINamespace.Name = "tbUINamespace";
            this.tbUINamespace.Size = new System.Drawing.Size(302, 20);
            this.tbUINamespace.TabIndex = 1;
            this.tbUINamespace.Text = "Sys.App.Book";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbHandlerName);
            this.groupBox1.Controls.Add(this.lbHandlerName);
            this.groupBox1.Controls.Add(this.cbPerpageRecord);
            this.groupBox1.Controls.Add(this.lbPerpageRecord);
            this.groupBox1.Controls.Add(this.tbStartrecord);
            this.groupBox1.Controls.Add(this.lbStartrecord);
            this.groupBox1.Controls.Add(this.lbNamespace);
            this.groupBox1.Controls.Add(this.tbUINamespace);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 133);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "共有参数";
            // 
            // tbHandlerName
            // 
            this.tbHandlerName.Location = new System.Drawing.Point(128, 57);
            this.tbHandlerName.Name = "tbHandlerName";
            this.tbHandlerName.Size = new System.Drawing.Size(302, 20);
            this.tbHandlerName.TabIndex = 7;
            this.tbHandlerName.Text = "handler.ashx";
            // 
            // lbHandlerName
            // 
            this.lbHandlerName.AutoSize = true;
            this.lbHandlerName.Location = new System.Drawing.Point(33, 61);
            this.lbHandlerName.Name = "lbHandlerName";
            this.lbHandlerName.Size = new System.Drawing.Size(86, 13);
            this.lbHandlerName.TabIndex = 6;
            this.lbHandlerName.Text = "Hanler文件名：";
            // 
            // cbPerpageRecord
            // 
            this.cbPerpageRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPerpageRecord.FormattingEnabled = true;
            this.cbPerpageRecord.Items.AddRange(new object[] {
            "15",
            "18",
            "20",
            "30",
            "50",
            "100"});
            this.cbPerpageRecord.Location = new System.Drawing.Point(321, 87);
            this.cbPerpageRecord.Name = "cbPerpageRecord";
            this.cbPerpageRecord.Size = new System.Drawing.Size(109, 21);
            this.cbPerpageRecord.TabIndex = 5;
            // 
            // lbPerpageRecord
            // 
            this.lbPerpageRecord.AutoSize = true;
            this.lbPerpageRecord.Location = new System.Drawing.Point(226, 90);
            this.lbPerpageRecord.Name = "lbPerpageRecord";
            this.lbPerpageRecord.Size = new System.Drawing.Size(91, 13);
            this.lbPerpageRecord.TabIndex = 4;
            this.lbPerpageRecord.Text = "每页显示记录：";
            // 
            // tbStartrecord
            // 
            this.tbStartrecord.Location = new System.Drawing.Point(128, 87);
            this.tbStartrecord.Name = "tbStartrecord";
            this.tbStartrecord.Size = new System.Drawing.Size(92, 20);
            this.tbStartrecord.TabIndex = 3;
            this.tbStartrecord.Text = "0";
            // 
            // lbStartrecord
            // 
            this.lbStartrecord.AutoSize = true;
            this.lbStartrecord.Location = new System.Drawing.Point(33, 90);
            this.lbStartrecord.Name = "lbStartrecord";
            this.lbStartrecord.Size = new System.Drawing.Size(91, 13);
            this.lbStartrecord.TabIndex = 2;
            this.lbStartrecord.Text = "列表开始记录：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDeleteInformation);
            this.groupBox2.Controls.Add(this.lbDeleteInformation);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 64);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询界面";
            // 
            // tbDeleteInformation
            // 
            this.tbDeleteInformation.Location = new System.Drawing.Point(128, 24);
            this.tbDeleteInformation.Name = "tbDeleteInformation";
            this.tbDeleteInformation.Size = new System.Drawing.Size(302, 20);
            this.tbDeleteInformation.TabIndex = 8;
            this.tbDeleteInformation.Text = "您确认要删除该记录吗？";
            // 
            // lbDeleteInformation
            // 
            this.lbDeleteInformation.AutoSize = true;
            this.lbDeleteInformation.Location = new System.Drawing.Point(9, 27);
            this.lbDeleteInformation.Name = "lbDeleteInformation";
            this.lbDeleteInformation.Size = new System.Drawing.Size(115, 13);
            this.lbDeleteInformation.TabIndex = 6;
            this.lbDeleteInformation.Text = "删除时的提醒语句：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbQueryTitle);
            this.groupBox3.Controls.Add(this.lbQueryTitle);
            this.groupBox3.Location = new System.Drawing.Point(12, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 69);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件界面";
            // 
            // tbQueryTitle
            // 
            this.tbQueryTitle.Location = new System.Drawing.Point(128, 27);
            this.tbQueryTitle.Name = "tbQueryTitle";
            this.tbQueryTitle.Size = new System.Drawing.Size(302, 20);
            this.tbQueryTitle.TabIndex = 8;
            this.tbQueryTitle.Text = "（主题）信息查询界面";
            // 
            // lbQueryTitle
            // 
            this.lbQueryTitle.AutoSize = true;
            this.lbQueryTitle.Location = new System.Drawing.Point(33, 30);
            this.lbQueryTitle.Name = "lbQueryTitle";
            this.lbQueryTitle.Size = new System.Drawing.Size(91, 13);
            this.lbQueryTitle.TabIndex = 8;
            this.lbQueryTitle.Text = "弹出页面标题：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbNewEditTitle);
            this.groupBox4.Controls.Add(this.lbNewEditTitle);
            this.groupBox4.Location = new System.Drawing.Point(12, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 66);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "信息维护界面";
            // 
            // tbNewEditTitle
            // 
            this.tbNewEditTitle.Location = new System.Drawing.Point(128, 26);
            this.tbNewEditTitle.Name = "tbNewEditTitle";
            this.tbNewEditTitle.Size = new System.Drawing.Size(302, 20);
            this.tbNewEditTitle.TabIndex = 6;
            this.tbNewEditTitle.Text = "（主题）信息维护界面";
            // 
            // lbNewEditTitle
            // 
            this.lbNewEditTitle.AutoSize = true;
            this.lbNewEditTitle.Location = new System.Drawing.Point(33, 29);
            this.lbNewEditTitle.Name = "lbNewEditTitle";
            this.lbNewEditTitle.Size = new System.Drawing.Size(91, 13);
            this.lbNewEditTitle.TabIndex = 7;
            this.lbNewEditTitle.Text = "弹出页面标题：";
            // 
            // btniCatTools
            // 
            this.btniCatTools.Location = new System.Drawing.Point(140, 457);
            this.btniCatTools.Name = "btniCatTools";
            this.btniCatTools.Size = new System.Drawing.Size(90, 25);
            this.btniCatTools.TabIndex = 5;
            this.btniCatTools.Text = "设置完成";
            this.btniCatTools.UseVisualStyleBackColor = true;
            this.btniCatTools.Click += new System.EventHandler(this.btniCatTools_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(251, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbQuery);
            this.groupBox5.Controls.Add(this.cbDelete);
            this.groupBox5.Controls.Add(this.cbNewEdit);
            this.groupBox5.Location = new System.Drawing.Point(12, 372);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(446, 69);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "权限控制";
            // 
            // cbQuery
            // 
            this.cbQuery.AutoSize = true;
            this.cbQuery.Checked = true;
            this.cbQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQuery.Location = new System.Drawing.Point(358, 33);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(74, 17);
            this.cbQuery.TabIndex = 2;
            this.cbQuery.Text = "查询条件";
            this.cbQuery.UseVisualStyleBackColor = true;
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Checked = true;
            this.cbDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDelete.Location = new System.Drawing.Point(210, 33);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(74, 17);
            this.cbDelete.TabIndex = 1;
            this.cbDelete.Text = "删除记录";
            this.cbDelete.UseVisualStyleBackColor = true;
            // 
            // cbNewEdit
            // 
            this.cbNewEdit.AutoSize = true;
            this.cbNewEdit.Checked = true;
            this.cbNewEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewEdit.Location = new System.Drawing.Point(35, 33);
            this.cbNewEdit.Name = "cbNewEdit";
            this.cbNewEdit.Size = new System.Drawing.Size(110, 17);
            this.cbNewEdit.TabIndex = 0;
            this.cbNewEdit.Text = "新增或修改记录";
            this.cbNewEdit.UseVisualStyleBackColor = true;
            // 
            // SetUIParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 508);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btniCatTools);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetUIParams";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置UI层参数";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SetUIParams_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNamespace;
        private System.Windows.Forms.TextBox tbUINamespace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPerpageRecord;
        private System.Windows.Forms.Label lbPerpageRecord;
        private System.Windows.Forms.TextBox tbStartrecord;
        private System.Windows.Forms.Label lbStartrecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbDeleteInformation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbNewEditTitle;
        private System.Windows.Forms.Label lbNewEditTitle;
        private System.Windows.Forms.Button btniCatTools;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbQueryTitle;
        private System.Windows.Forms.Label lbQueryTitle;
        private System.Windows.Forms.TextBox tbHandlerName;
        private System.Windows.Forms.Label lbHandlerName;
        private System.Windows.Forms.TextBox tbDeleteInformation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbQuery;
        private System.Windows.Forms.CheckBox cbDelete;
        private System.Windows.Forms.CheckBox cbNewEdit;
    }
}