using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccessLibrary;
using PagingLib;

namespace BaseSqlLibrary
{
    public class BaseCommon : AccessBase
    {
        /// <summary>
        /// 新增时获取最大的ID+1
        /// </summary>
        /// <param name="keyField"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetNextKey(string keyField, string tableName)
        {
            #region
            string strSql = "select Max(" + keyField + ") from " + tableName;
            this.sqlSelectCommand1.CommandText = strSql;
            object obj;
            try
            {
                this.OpenDatabase();
                obj = this.sqlSelectCommand1.ExecuteScalar();
                if (obj == System.DBNull.Value)
                    return 1;
                else
                    return Convert.ToInt32(obj) + 1;
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
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTimeNow()
        {
            #region
            string strSql = "select getdate()";
            this.sqlSelectCommand1.CommandText = strSql;
            object obj;
            try
            {
                this.OpenDatabase();
                obj = this.sqlSelectCommand1.ExecuteScalar();
                if (obj == System.DBNull.Value)
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(obj);
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
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="keyField"></param>
        public void SaveDataSet(DataSet ds, String tableName, String keyField)
        {
            #region
            try
            {
                this.OpenDatabase();
                this.sqlSelectCommand1.CommandText = "select * from [" + tableName + "] where " + keyField + "='' ";
                this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
                System.Data.SqlClient.SqlCommandBuilder sqlbuild = new SqlCommandBuilder(this.sqlDataAdapter1);
                //sqlbuild.ConflictOption = System.Data.ConflictOption.OverwriteChanges;
                //sqlbuild.SetAllValues = false;
                this.sqlDataAdapter1.InsertCommand = sqlbuild.GetInsertCommand();
                this.sqlDataAdapter1.UpdateCommand = sqlbuild.GetUpdateCommand();
                this.sqlDataAdapter1.DeleteCommand = sqlbuild.GetDeleteCommand();
                this.sqlDataAdapter1.Update(ds, tableName);
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
        /// 删除行
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyField">主键字段名</param>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public int DeleteRow(String tableName, String keyField, String keyValue)
        {
            #region
            string sqltext = @"delete FROM [" + tableName + "]";
            string sqlwhere = string.Empty;
            if (keyValue != string.Empty)
            {
                sqlwhere += " (" + keyField + "=@key) and ";
                this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@key", System.Data.SqlDbType.Int));
                this.sqlSelectCommand1.Parameters["@key"].Value = keyValue;
            }
            if (sqlwhere != string.Empty)
            {
                sqlwhere = sqlwhere.Remove(sqlwhere.Length - 4, 4);
                sqltext = sqltext + " WHERE " + sqlwhere;
            }
            this.sqlSelectCommand1.CommandText = sqltext;
            try
            {
                this.OpenDatabase();
                return this.sqlSelectCommand1.ExecuteNonQuery();
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
        /// 
        /// </summary>
        /// <param name="qb"></param>
        public void SelectStoredPro(QueryParam qb)
        {
            this.sqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            this.sqlSelectCommand1.CommandText = "SupesoftPage";
            this.sqlSelectCommand1.Parameters.Add("@TableName", SqlDbType.NVarChar, 2000).Value = qb.TableName;
            this.sqlSelectCommand1.Parameters.Add("@ReturnFields", SqlDbType.NVarChar, 500).Value = qb.ReturnFields;
            this.sqlSelectCommand1.Parameters.Add("@PageSize", SqlDbType.NVarChar, 500).Value = qb.PageSize;
            this.sqlSelectCommand1.Parameters.Add("@PageIndex", SqlDbType.NVarChar, 500).Value = qb.PageIndex;
            this.sqlSelectCommand1.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = qb.Where;
            this.sqlSelectCommand1.Parameters.Add("@Orderfld", SqlDbType.NVarChar, 500).Value = qb.Orderfld;
            this.sqlSelectCommand1.Parameters.Add("@OrderType", SqlDbType.NVarChar, 500).Value = qb.OrderType;
            this.sqlSelectCommand1.Parameters.Add("@AllQueryRecordCount", SqlDbType.Int, 8).Value = 0;
            this.sqlSelectCommand1.Parameters.Add("@TotalPage", SqlDbType.Int, 8).Value = 0;
            this.sqlSelectCommand1.Parameters.Add("@CurrentPageSize", SqlDbType.Int, 8).Value = 0;
        }
        /// <summary>
        /// 判断参数值是否合法
        /// </summary>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public bool ParamIsValid(string paramValue)
        {
            return (paramValue != string.Empty && paramValue != null) ? true : false;
        }

        private string IsNullReplace(string source)
        {
            return source == null ? "" : source;
        }
    }
}
