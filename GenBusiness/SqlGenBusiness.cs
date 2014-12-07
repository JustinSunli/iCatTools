using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenClassLibrary;
using System.Data;

namespace GenBusiness
{
    public class SqlGenBusiness
    {
        private string _connectString = "";
        public SqlGenBusiness(string connectString)
        {
            this._connectString = connectString;
        }
        /// <summary>
        /// 获取目标数据表的插入语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public string GetInsertString(string tableName)
        {
            SqlInsert sqlInserClass = new SqlInsert(this._connectString);
            DataSet insertData = sqlInserClass.getInsertData("[" + tableName + "]");
            string inStr = "";
            for (int i = 0; i < insertData.Tables[0].Rows.Count; i++)
            {
                DataRow dr;
                dr = insertData.Tables[0].Rows[i];
                inStr += dr[0].ToString() + "\r\n";
            }
            if (inStr == "")
                inStr = "选中表中暂无记录！";
            return inStr;
        }
        /// <summary>
        /// 获取单行insert sql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="rowIndex">行索引</param>
        /// <returns></returns>
        public string GetInsertSingleRow(DataSet insertData, int rowIndex)
        {
            string inStr = "";
            DataRow dr;
            dr = insertData.Tables[0].Rows[rowIndex];
            inStr += dr[0].ToString() + "\r\n";
            return inStr;
        }
        /// <summary>
        /// 获取指定表记录数目
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetTableRowCount(string tableName) 
        {
            SqlTable sqltableClass = new SqlTable(this._connectString);
            string retFormat = "表{0}中有 {1} 条记录。\r\n";
            return string.Format(retFormat, tableName, sqltableClass.getTableRowCount(tableName));
        }
    }
}
