using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCatTools.common;
using GenDataLibrary;
using GenClassLibrary;

namespace iCatTools.Frm
{
    public partial class ExecSql : Form
    {
        private ConnectionData connectionDs = new ConnectionData();
        private string _ConnectString = "";
        public ExecSql()
        {
            InitializeComponent();
        }

        private bool CheckStaticExec()
        {

            return true;
        }

        private void btnStaticQuery_Click(object sender, EventArgs e)
        {
            #region
            string tablename = null;
            object toprecord = null;
            //if (!FormCheck.CheckValid(this.tbTableName, this.lbTableName, EnumCheck.IsEmpty, ref tablename))
            //    return;
            if (!FormCheck.CheckValid(this.tbTopRecord, this.lbToprecord, EnumCheck.IsNumber, ref toprecord))
                return;
            tablename = (this.cbTableName.SelectedValue == null) ? "" : this.cbTableName.SelectedValue.ToString();

            if (String.IsNullOrEmpty(tablename))
            {
                MessageBase.Show("所选表名不能为空！");
                return;
            }
            DateTime dtstart = DateTime.Now;
            SqlSelect sqlselect = new SqlSelect(this._ConnectString);
            DataSet tablerecord = sqlselect.getTableRecord(tablename, Convert.ToInt16(toprecord));
            DateTime dtend = DateTime.Now;
            this.rtbQueryResult.Visible = false;
            this.dgvQueryViewDataset.Visible = true;
            this.dgvQueryViewDataset.Dock = DockStyle.Fill;
            this.dgvQueryViewDataset.DataSource = tablerecord.Tables[0].DefaultView;
            TimeSpan queryspan = dtend.Subtract(dtstart);
            this.tsslQueryTime.Text = "查询时长： " + queryspan.TotalMilliseconds.ToString() + " ms";
            #endregion
        }

        private void btnStaticClearTable_Click(object sender, EventArgs e)
        {

        }

        private void btnStaticTruncate_Click(object sender, EventArgs e)
        {

        }

        private void btnDynamicExec_Click(object sender, EventArgs e)
        {

        }

        private void btnDynamicStop_Click(object sender, EventArgs e)
        {

        }

        private void btnClearSql_Click(object sender, EventArgs e)
        {

        }

        private void ExecSql_Load(object sender, EventArgs e)
        {
            #region
            connectionDs.ReadXml(Application.StartupPath + "\\Connection.xml", XmlReadMode.Auto);
            
            this.dgvDataBase.DataSource = connectionDs.Tables[0].DefaultView;
            for (int i = 0; i < this.dgvDataBase.Columns.Count; i++)
                this.dgvDataBase.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvDataBase.Columns[3].Visible = false;
            this.dgvDataBase.Columns[4].Visible = false;
            DataGridViewColumnCollection columncollection = this.dgvDataBase.Columns;
            columncollection[0].HeaderText = "序号";
            columncollection[1].HeaderText = "数据库实例名";
            columncollection[2].HeaderText = "数据库名称";
            columncollection[0].Width = 35;
            columncollection[1].Width = 150;
            this.dgvDataBase.CurrentCell = null;

            this.rtbQueryResult.Dock = DockStyle.Fill;

            this.rtbExecSqlExpression.AcceptsTab = true;
            this.rtbExecSqlExpression.SelectionIndent = 4;
            this.rtbExecSqlExpression.SelectionHangingIndent = 2;
            this.rtbExecSqlExpression.SelectionRightIndent = 8;

            this.dgvQueryViewDataset.Visible = false;
            #endregion
        }
        /// <summary>
        /// 单击欲选数据库行后所做操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region
            int rowindex = e.RowIndex;
            if (rowindex >= 0)
            {
                DLSetcbtablename setcbtable = new DLSetcbtablename(this.settcbtablename);
                DataGridViewCellCollection rowcells = this.dgvDataBase.Rows[rowindex].Cells;
                this._ConnectString = "Data Source=" + rowcells["DataSource"].Value.ToString() + ";Initial Catalog=" + rowcells["InitialCatalog"].Value.ToString() + ";Persist Security Info=True;User ID=" + rowcells["UserID"].Value.ToString() + ";Password=" + rowcells["Password"].Value.ToString() + ";";
                setcbtable.BeginInvoke(this._ConnectString, null, null);
            }
            #endregion
        }
        private delegate void DLSetcbtablename(string connectString);
        private void settcbtablename(string connectString)
        {
            #region
            DLSetsetcbtableui setcbtableui;
            try
            {
                SqlTable sqlTableClass = new SqlTable(connectString);
                setcbtableui = new DLSetsetcbtableui(this.setcbtableui);
                this.BeginInvoke(setcbtableui, new object[2] { this.cbTableName, sqlTableClass.getTableName().Tables[0] });
            }
            catch
            {
                setcbtableui = new DLSetsetcbtableui(this.clearcbtableui);
                this.BeginInvoke(setcbtableui, new object[2] { this.cbTableName, null });
            }
            #endregion
        }
        private delegate void DLSetsetcbtableui(object cbControl, DataTable dtsource);
        private void setcbtableui(object cbControl, DataTable dtsource)
        { 
            ComboBox comlist = (ComboBox)cbControl;
            comlist.DataSource = dtsource;
            comlist.DisplayMember = "name";
            comlist.ValueMember = "name";
            comlist.Update();

        }
        private void clearcbtableui(object cbControl, DataTable dtsource)
        {
            ComboBox comlist = (ComboBox)cbControl;
            comlist.DataSource = null;
            comlist.Items.Clear();
        }

        private void btnRecordCount_Click(object sender, EventArgs e)
        {
            string tablename = (this.cbTableName.SelectedValue == null) ? "" : this.cbTableName.SelectedValue.ToString();
            string describeformat = "表 {0} 有 {1} 条记录！\r\n总共查询耗时 {2} ms";
            if (String.IsNullOrEmpty(tablename))
            {
                MessageBase.Show("所选表名不能为空！");
                return;
            }
            int rowcount = 0;
            DateTime dtstart = DateTime.Now;
            SqlTable sqltableClass = new SqlTable(this._ConnectString);
            rowcount = sqltableClass.getTableRowCount(tablename);
            DateTime dtend = DateTime.Now;
            TimeSpan queryspan = dtend.Subtract(dtstart);

            MessageBase.Show(String.Format(describeformat, tablename, rowcount, queryspan.TotalMilliseconds));
        }
   }
}
