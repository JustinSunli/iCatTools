using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iCatTools.common;
using GenDataLibrary;
using GenClassLibrary;

namespace iCatTools.Frm
{
    public partial class SelectConnection : Form
    {
        private int rowIndex = -1;
        public SelectConnection()
        {
            InitializeComponent();
        }

        private ConnectionData connectionDs = new ConnectionData();
        /// <summary>
        /// 加载选择连接字符串对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectConnection_Load(object sender, EventArgs e)
        {
            #region
            #region 利用ListView来绑定
            //string sNote = "";
            //ListViewItem li;
            //XmlDocument doc = new XmlDocument();
            //doc.Load("Connection.xml");
            //XmlNodeList nodeLst = doc.GetElementsByTagName("Connection");
            //this.listViewConnString.Items.Clear();
            //foreach (XmlNode node in nodeLst)
            //{
            //    li = new ListViewItem();
            //    this.listViewConnString.BeginUpdate();
            //    sNote = "Data Source=" + node.ChildNodes[0].InnerText + ";Initial Catalog=" + node.ChildNodes[1].InnerText + ";Persist Security Info=True;User ID=" + node.ChildNodes[2].InnerText + ";Password=" + node.ChildNodes[2].InnerText + ";";// node.ChildNodes[2].InnerText;
            //    li.SubItems.Add(sNote);
            //    this.listViewConnString.Items.Add(li);
            //    this.listViewConnString.EndUpdate();//此处设置ListView的view为detail，column为两项（因为第一项默认为ICONIndex）
            //}
            #endregion

            rowIndex = -1;
            connectionDs.ReadXml(Application.StartupPath + "\\Connection.xml", XmlReadMode.Auto);
            this.dataGridView1.DataSource = connectionDs.Tables[0].DefaultView;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewColumnCollection columncollection = this.dataGridView1.Columns;
            columncollection[0].HeaderText = "序号";
            columncollection[1].HeaderText = "数据库实例名";
            columncollection[2].HeaderText = "数据库名称";
            columncollection[3].HeaderText = "数据库登录名";
            columncollection[4].HeaderText = "密码";
            columncollection[0].Width = 50;
            columncollection[1].Width = 200;
            this.dataGridView1.CurrentCell = null;
            #endregion
        }
        /// <summary>
        /// 双击连接字符串grid某一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region
            //如果此处有空行头，鼠标需要双击行头来选择时，可以没有&&e.ColumnIndex的判断
            if (e.RowIndex > -1)
            {
                DataRow dr = connectionDs.Tables[0].Rows[e.RowIndex];
                this.tbDataSource.Text = dr[ConnectionData.DataSource].ToString();
                this.tbDataBase.Text = dr[ConnectionData.InitialCatalog].ToString();
                this.tbUserID.Text = dr[ConnectionData.UserID].ToString();
                this.tbPassword.Text = dr[ConnectionData.Password].ToString();
            }
            
            #endregion
        }
        /// <summary>
        /// 鼠标单击单元格时的情形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region
            //修正了鼠标点击列头时的选中bug
            rowIndex = e.RowIndex > -1 ? e.RowIndex : 0;
            #endregion
        }
        /// <summary>
        /// 连接字符串因四参数变动而变动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDataSource_TextChanged(object sender, EventArgs e)
        {
            #region
            string formatconnect = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};";
            string[] conn = new string[4];
            conn[0] = this.tbDataSource.Text.Trim();
            conn[1] = this.tbDataBase.Text.Trim();
            conn[2] = this.tbUserID.Text.Trim();
            conn[3] = this.tbPassword.Text.Trim();

            this.tbConnectString.Text = string.Format(formatconnect, conn);
            #endregion
        }
        /// <summary>
        /// 连接目标数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTestConnect_Click(object sender, EventArgs e)
        {
            #region

            if (rowIndex > -1)
            {
                try
                {
                    string connectstring = "";
                    DataRow dr = connectionDs.Tables[0].Rows[rowIndex];
                    connectstring = "Data Source=" + dr["DataSource"].ToString() + ";Initial Catalog=" + dr["InitialCatalog"].ToString() + ";Persist Security Info=True;User ID=" + dr["UserID"].ToString() + ";Password=" + dr["Password"].ToString() + ";";
                    SqlTable sqlTableClass = new SqlTable(connectstring);
                    MainForm._DataSetAllTableName = sqlTableClass.getTableName();
                    MainForm._ConnectionString = connectstring;
                    MainForm._DatabaseName = dr["InitialCatalog"].ToString();
                    this.Close();
                }
                catch
                {
                    MessageBase.ShowError("数据库连接不成功！");
                    return;
                }
            }
            else
                MessageBase.Show("请选择目标数据库连接字符串！");
            #endregion
        }
        /// <summary>
        /// 保存目标连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmNew_Click(object sender, EventArgs e)
        {
            #region
            #region 利用XmlWriter来实现创建
            /********************************
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create("Connection.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("ConnectionData");
            writer.WriteStartElement("Connection");
            writer.WriteElementString("DataSource", this.tbDataSource.Text.Trim());
            writer.WriteElementString("InitialCatalog", this.tbDataBase.Text.Trim());
            writer.WriteElementString("UserID", this.tbUserID.Text.Trim());
            writer.WriteElementString("Password", this.tbPassword.Text.Trim());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            ********************************/
            #endregion
            int nextId = 0;
            DataRow[] drArr = connectionDs.Tables[0].Select("", ConnectionData.rid);
            if (drArr.Length == 0)
                nextId = 1;
            else
                nextId = Convert.ToInt16(drArr[drArr.Length - 1][ConnectionData.rid]) + 1;
            DataRow dr = connectionDs.Tables[0].NewRow();
            dr[ConnectionData.rid] = nextId;
            dr[ConnectionData.DataSource] = this.tbDataSource.Text.Trim();
            dr[ConnectionData.InitialCatalog] = this.tbDataBase.Text.Trim();
            dr[ConnectionData.UserID] = this.tbUserID.Text.Trim();
            dr[ConnectionData.Password] = this.tbPassword.Text.Trim();
            connectionDs.Tables[0].Rows.Add(dr);

            //ds.WriteXmlSchema("Connection.xdr");
            connectionDs.WriteXml("Connection.xml", XmlWriteMode.IgnoreSchema);
            connectionDs.AcceptChanges();
            this.dataGridView1.CurrentCell = null;
            #endregion
        }
        /// <summary>
        /// 更新连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            #region
            if (rowIndex > -1)
            {
                DataRow dr = connectionDs.Tables[0].Rows[rowIndex];
                dr[ConnectionData.DataSource] = this.tbDataSource.Text.Trim();
                dr[ConnectionData.InitialCatalog] = this.tbDataBase.Text.Trim();
                dr[ConnectionData.UserID] = this.tbUserID.Text.Trim();
                dr[ConnectionData.Password] = this.tbPassword.Text.Trim();
                connectionDs.WriteXml("Connection.xml", XmlWriteMode.IgnoreSchema);
                connectionDs.Tables[0].AcceptChanges();
                this.dataGridView1.CurrentCell = null;
            }
            else
                MessageBase.Show("请选择欲修改的连接字符串！");
            #endregion
        }
        /// <summary>
        /// 删除已保存过的连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            #region
            if (rowIndex > -1)
            {
                connectionDs.Tables[0].Rows[rowIndex].Delete();
                //ds.WriteXmlSchema("Connection.xdr");
                connectionDs.WriteXml("Connection.xml", XmlWriteMode.IgnoreSchema);
                connectionDs.Tables[0].AcceptChanges();
                rowIndex = -1;
                this.dataGridView1.CurrentCell = null;
            }
            else
                MessageBase.Show("请选择欲删除的连接字符串！");
            #endregion
        }
    }
}