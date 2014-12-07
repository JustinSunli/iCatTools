using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccessLibrary;
using System.Data;

namespace GenClassLibrary
{
    public class SqlSelect : AccessBase
    {
        public SqlSelect(string connectionString)
        {
            base.sqlConnection1.ConnectionString = connectionString;
        }
        /// <summary>
        /// 获取全部数据表的数据集
        /// </summary>
        /// <returns></returns>
        public DataSet getTableRecord(string tablename, int toprecordcount)
        {
            #region
            DataSet ds = new DataSet();
            string strsqlformat = "select {0} * from [{1}]";
            string topsql = (toprecordcount != 0) ? "top " + toprecordcount.ToString() : "";
            string strsql = string.Format(strsqlformat, topsql, tablename);
            this.sqlSelectCommand1.CommandText = strsql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "DestTable");
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseDatabase();
            }
            #endregion
        }
    }
}
