using iCatTools.common;
namespace iCatTools.Frm
{
    partial class ExecSql
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecSql));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbExecSqlExpression = new iCatTools.common.UxSQLRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearSql = new System.Windows.Forms.Button();
            this.btnDynamicStop = new System.Windows.Forms.Button();
            this.btnDynamicExec = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRecordCount = new System.Windows.Forms.Button();
            this.cbTableName = new System.Windows.Forms.ComboBox();
            this.btnStaticTruncate = new System.Windows.Forms.Button();
            this.btnStaticClearTable = new System.Windows.Forms.Button();
            this.btnStaticQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTopRecord = new System.Windows.Forms.TextBox();
            this.lbToprecord = new System.Windows.Forms.Label();
            this.lbTableName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvQueryViewDataset = new System.Windows.Forms.DataGridView();
            this.rtbQueryResult = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslQueryResultDescribe = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslQueryTime = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryViewDataset)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(796, 464);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbExecSqlExpression);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(352, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入SQL语句进行查询";
            // 
            // rtbExecSqlExpression
            // 
            this.rtbExecSqlExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExecSqlExpression.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbExecSqlExpression.Location = new System.Drawing.Point(3, 16);
            this.rtbExecSqlExpression.Name = "rtbExecSqlExpression";
            this.rtbExecSqlExpression.Size = new System.Drawing.Size(328, 162);
            this.rtbExecSqlExpression.TabIndex = 1;
            this.rtbExecSqlExpression.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearSql);
            this.panel1.Controls.Add(this.btnDynamicStop);
            this.panel1.Controls.Add(this.btnDynamicExec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(331, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 162);
            this.panel1.TabIndex = 0;
            // 
            // btnClearSql
            // 
            this.btnClearSql.Location = new System.Drawing.Point(17, 76);
            this.btnClearSql.Name = "btnClearSql";
            this.btnClearSql.Size = new System.Drawing.Size(75, 25);
            this.btnClearSql.TabIndex = 2;
            this.btnClearSql.Text = "清空语句";
            this.btnClearSql.UseVisualStyleBackColor = true;
            this.btnClearSql.Click += new System.EventHandler(this.btnClearSql_Click);
            // 
            // btnDynamicStop
            // 
            this.btnDynamicStop.Location = new System.Drawing.Point(17, 44);
            this.btnDynamicStop.Name = "btnDynamicStop";
            this.btnDynamicStop.Size = new System.Drawing.Size(75, 25);
            this.btnDynamicStop.TabIndex = 1;
            this.btnDynamicStop.Text = "停止执行";
            this.btnDynamicStop.UseVisualStyleBackColor = true;
            this.btnDynamicStop.Click += new System.EventHandler(this.btnDynamicStop_Click);
            // 
            // btnDynamicExec
            // 
            this.btnDynamicExec.Location = new System.Drawing.Point(17, 13);
            this.btnDynamicExec.Name = "btnDynamicExec";
            this.btnDynamicExec.Size = new System.Drawing.Size(75, 25);
            this.btnDynamicExec.TabIndex = 0;
            this.btnDynamicExec.Text = "执行语句";
            this.btnDynamicExec.UseVisualStyleBackColor = true;
            this.btnDynamicExec.Click += new System.EventHandler(this.btnDynamicExec_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRecordCount);
            this.groupBox2.Controls.Add(this.cbTableName);
            this.groupBox2.Controls.Add(this.btnStaticTruncate);
            this.groupBox2.Controls.Add(this.btnStaticClearTable);
            this.groupBox2.Controls.Add(this.btnStaticQuery);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbTopRecord);
            this.groupBox2.Controls.Add(this.lbToprecord);
            this.groupBox2.Controls.Add(this.lbTableName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(352, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "固定模式查询";
            // 
            // btnRecordCount
            // 
            this.btnRecordCount.Location = new System.Drawing.Point(116, 50);
            this.btnRecordCount.Name = "btnRecordCount";
            this.btnRecordCount.Size = new System.Drawing.Size(80, 25);
            this.btnRecordCount.TabIndex = 9;
            this.btnRecordCount.Text = "数据量";
            this.btnRecordCount.UseVisualStyleBackColor = true;
            this.btnRecordCount.Click += new System.EventHandler(this.btnRecordCount_Click);
            // 
            // cbTableName
            // 
            this.cbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.Location = new System.Drawing.Point(123, 22);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.Size = new System.Drawing.Size(163, 21);
            this.cbTableName.TabIndex = 8;
            // 
            // btnStaticTruncate
            // 
            this.btnStaticTruncate.Location = new System.Drawing.Point(288, 51);
            this.btnStaticTruncate.Name = "btnStaticTruncate";
            this.btnStaticTruncate.Size = new System.Drawing.Size(80, 25);
            this.btnStaticTruncate.TabIndex = 7;
            this.btnStaticTruncate.Text = "重建该表";
            this.btnStaticTruncate.UseVisualStyleBackColor = true;
            this.btnStaticTruncate.Click += new System.EventHandler(this.btnStaticTruncate_Click);
            // 
            // btnStaticClearTable
            // 
            this.btnStaticClearTable.Location = new System.Drawing.Point(202, 51);
            this.btnStaticClearTable.Name = "btnStaticClearTable";
            this.btnStaticClearTable.Size = new System.Drawing.Size(80, 25);
            this.btnStaticClearTable.TabIndex = 6;
            this.btnStaticClearTable.Text = "清空该表";
            this.btnStaticClearTable.UseVisualStyleBackColor = true;
            this.btnStaticClearTable.Click += new System.EventHandler(this.btnStaticClearTable_Click);
            // 
            // btnStaticQuery
            // 
            this.btnStaticQuery.Location = new System.Drawing.Point(30, 51);
            this.btnStaticQuery.Name = "btnStaticQuery";
            this.btnStaticQuery.Size = new System.Drawing.Size(80, 25);
            this.btnStaticQuery.TabIndex = 5;
            this.btnStaticQuery.Text = "现在查询";
            this.btnStaticQuery.UseVisualStyleBackColor = true;
            this.btnStaticQuery.Click += new System.EventHandler(this.btnStaticQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "条记录";
            // 
            // tbTopRecord
            // 
            this.tbTopRecord.Location = new System.Drawing.Point(315, 22);
            this.tbTopRecord.Name = "tbTopRecord";
            this.tbTopRecord.Size = new System.Drawing.Size(68, 20);
            this.tbTopRecord.TabIndex = 3;
            this.tbTopRecord.Text = "1000";
            // 
            // lbToprecord
            // 
            this.lbToprecord.AutoSize = true;
            this.lbToprecord.Location = new System.Drawing.Point(292, 25);
            this.lbToprecord.Name = "lbToprecord";
            this.lbToprecord.Size = new System.Drawing.Size(19, 13);
            this.lbToprecord.TabIndex = 2;
            this.lbToprecord.Text = "前";
            // 
            // lbTableName
            // 
            this.lbTableName.AutoSize = true;
            this.lbTableName.Location = new System.Drawing.Point(28, 25);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(91, 13);
            this.lbTableName.TabIndex = 0;
            this.lbTableName.Text = "查询的目标表：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDataBase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择目标数据库";
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.AllowUserToAddRows = false;
            this.dgvDataBase.AllowUserToDeleteRows = false;
            this.dgvDataBase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataBase.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvDataBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDataBase.ColumnHeadersHeight = 18;
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataBase.EnableHeadersVisualStyles = false;
            this.dgvDataBase.Location = new System.Drawing.Point(3, 16);
            this.dgvDataBase.MultiSelect = false;
            this.dgvDataBase.Name = "dgvDataBase";
            this.dgvDataBase.ReadOnly = true;
            this.dgvDataBase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDataBase.RowHeadersWidth = 20;
            this.dgvDataBase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDataBase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDataBase.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvDataBase.RowTemplate.Height = 18;
            this.dgvDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataBase.ShowCellErrors = false;
            this.dgvDataBase.ShowCellToolTips = false;
            this.dgvDataBase.ShowEditingIcon = false;
            this.dgvDataBase.ShowRowErrors = false;
            this.dgvDataBase.Size = new System.Drawing.Size(346, 254);
            this.dgvDataBase.TabIndex = 4;
            this.dgvDataBase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBase_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvQueryViewDataset);
            this.groupBox4.Controls.Add(this.rtbQueryResult);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(796, 187);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查询结果";
            // 
            // dgvQueryViewDataset
            // 
            this.dgvQueryViewDataset.AllowUserToAddRows = false;
            this.dgvQueryViewDataset.AllowUserToDeleteRows = false;
            this.dgvQueryViewDataset.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvQueryViewDataset.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQueryViewDataset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueryViewDataset.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvQueryViewDataset.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvQueryViewDataset.ColumnHeadersHeight = 18;
            this.dgvQueryViewDataset.EnableHeadersVisualStyles = false;
            this.dgvQueryViewDataset.Location = new System.Drawing.Point(43, 22);
            this.dgvQueryViewDataset.MultiSelect = false;
            this.dgvQueryViewDataset.Name = "dgvQueryViewDataset";
            this.dgvQueryViewDataset.ReadOnly = true;
            this.dgvQueryViewDataset.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQueryViewDataset.RowHeadersVisible = false;
            this.dgvQueryViewDataset.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvQueryViewDataset.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQueryViewDataset.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvQueryViewDataset.RowTemplate.Height = 18;
            this.dgvQueryViewDataset.ShowCellErrors = false;
            this.dgvQueryViewDataset.ShowCellToolTips = false;
            this.dgvQueryViewDataset.ShowEditingIcon = false;
            this.dgvQueryViewDataset.ShowRowErrors = false;
            this.dgvQueryViewDataset.Size = new System.Drawing.Size(279, 153);
            this.dgvQueryViewDataset.TabIndex = 5;
            // 
            // rtbQueryResult
            // 
            this.rtbQueryResult.Location = new System.Drawing.Point(340, 37);
            this.rtbQueryResult.Name = "rtbQueryResult";
            this.rtbQueryResult.ReadOnly = true;
            this.rtbQueryResult.Size = new System.Drawing.Size(395, 104);
            this.rtbQueryResult.TabIndex = 2;
            this.rtbQueryResult.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslQueryResultDescribe,
            this.toolStripStatusLabel2,
            this.tsslQueryTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslQueryResultDescribe
            // 
            this.tsslQueryResultDescribe.Name = "tsslQueryResultDescribe";
            this.tsslQueryResultDescribe.Size = new System.Drawing.Size(31, 17);
            this.tsslQueryResultDescribe.Text = "就绪";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(750, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // tsslQueryTime
            // 
            this.tsslQueryTime.Name = "tsslQueryTime";
            this.tsslQueryTime.Size = new System.Drawing.Size(0, 17);
            // 
            // ExecSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 486);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExecSql";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iCat Assist Tools简易版查询分析器";
            this.Load += new System.EventHandler(this.ExecSql_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryViewDataset)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearSql;
        private System.Windows.Forms.Button btnDynamicStop;
        private System.Windows.Forms.Button btnDynamicExec;
        private System.Windows.Forms.Button btnStaticTruncate;
        private System.Windows.Forms.Button btnStaticClearTable;
        private System.Windows.Forms.Button btnStaticQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTopRecord;
        private System.Windows.Forms.Label lbToprecord;
        private System.Windows.Forms.Label lbTableName;
        private UxSQLRichTextBox rtbExecSqlExpression;
        private System.Windows.Forms.DataGridView dgvQueryViewDataset;
        private System.Windows.Forms.RichTextBox rtbQueryResult;
        private System.Windows.Forms.ComboBox cbTableName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslQueryResultDescribe;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslQueryTime;
        private System.Windows.Forms.Button btnRecordCount;

    }
}