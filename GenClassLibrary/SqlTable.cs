using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccessLibrary;
using System.Data;

namespace GenClassLibrary
{
    public class SqlTable : AccessBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlTable(string connectionString)
        {
            base.sqlConnection1.ConnectionString = connectionString;
        }
        /// <summary>
        /// 获取全部数据表的数据集
        /// </summary>
        /// <returns></returns>
        public DataSet getTableName()
        {
            #region
            DataSet ds = new DataSet();
            string strSql = "select [name] from [sysobjects] where xtype='u' order by name";
            this.sqlSelectCommand1.CommandText = strSql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "tableName");
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
        /// <summary>
        /// 获取指定表的记录条数
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public int getTableRowCount(string tablename)
        {
            #region
            string sqltext = @"SELECT count(*) FROM [" + tablename + "] ";
            this.sqlSelectCommand1.CommandText = sqltext;
            try
            {
                this.OpenDatabase();
                object obj = this.sqlSelectCommand1.ExecuteScalar();
                if (obj != System.DBNull.Value)
                    return Convert.ToInt32(obj);
                else
                    return 0;
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
