using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GenClassLibrary;
using System.Data;

namespace GenBusiness
{
    public abstract class GenTools
    {
        private string username = "bhlfy";
        private string company = "山西博华科技有限公司";
        public string _connectString = "";

        protected SqlColumn sqlcolClass = null;
        protected string tableName = "";
        protected DataSet columnsDs = null;

        public GenTools(string connectString)
        {
            this._connectString = connectString;
            this.sqlcolClass = new SqlColumn(this._connectString);
        }
        /// <summary>
        /// 创建者的用户名称
        /// </summary>
        public String UserName
        {
            #region
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
            #endregion
        }
        /// <summary>
        /// 版权所有者
        /// </summary>
        public String Company
        {
            #region
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
            #endregion
        }
        /// <summary>
        /// 应用程序版本
        /// </summary>
        public String AppVersion
        {
            #region
            get
            {
                return Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            #endregion
        }
        /// <summary>
        /// 设置目标表
        /// </summary>
        /// <param name="tableName"></param>
        public void SetTableName(string tableName)
        {
            #region
            this.tableName = tableName;
            this.columnsDs = this.sqlcolClass.getColumnsOfTable(this.tableName);
            #endregion
        }
        public string GetTablename()
        {
            #region
            return this.tableName;
            #endregion
        }
        /// <summary>
        /// 为方法添加到文件时要加Tab键
        /// </summary>
        /// <param name="strFunction"></param>
        /// <returns></returns>
        protected string AddTab(string strFunction)
        {
            #region
            string newstrfunction = "";
            string[] funcRows = strFunction.ToString().Split('\n');
            int i = 0;
            foreach (string s in funcRows)
            {
                i++;
                if (i != funcRows.Length)
                    newstrfunction += "\t\t" + s;
                else
                    newstrfunction += "\r\n";
            }
            return newstrfunction;
            #endregion
        }
    }
}
