using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccessLibrary;
using System.Data;

namespace GenClassLibrary
{
    public class SqlColumn : AccessBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlColumn(string connectionString)
        {
            base.sqlConnection1.ConnectionString = connectionString;
        }
        /// <summary>
        /// 获取目标表的所有列名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet getColumnsOfTable(string tableName)
        {
            #region
            DataSet ds = new DataSet();
            string strSql = "select a.name,a.xtype,b.value from [syscolumns] a left join sys.extended_properties b on b.major_id = a.id and b.minor_id = a.colorder where id=object_id('" + tableName + "')";
            this.sqlSelectCommand1.CommandText = strSql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "allColumns");
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
        /// 获取目标表的所有列、描述、数据类型（字符形式体现）
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet getColumnsAndType(string tableName)
        {
            #region
            DataSet ds = new DataSet();
            string strSql = @"select a.name,a.user_type_id as xtype,b.value,a.max_length as maxlength,
            c.name+'('+CAST(a.max_length AS VARCHAR(5))+')('+CAST(a.precision AS VARCHAR(5))+','+CAST(a.scale AS VARCHAR(5))+')' as xtypename 
            from sys.columns a 
            left join sys.extended_properties b on b.major_id = a.object_id and b.minor_id = a.column_id 
            inner join sys.types c on a.user_type_id = c.user_type_id 
            where a.object_id=object_id('" + tableName + "')";
            this.sqlSelectCommand1.CommandText = strSql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "allColumns");
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
        /// 获取指定表的所有主键
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet getPkOfTable(string tableName)
        {
            #region
            DataSet ds = new DataSet();
            string strSql = "exec sp_pkeys '" + tableName + "'";
            this.sqlSelectCommand1.CommandText = strSql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "allPkeys");
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
