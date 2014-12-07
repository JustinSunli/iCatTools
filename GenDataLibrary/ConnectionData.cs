using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenDataLibrary
{
    public class ConnectionData : DataSet
    {
       /// <summary>
        /// 序号。
        /// </summary>
        public const string rid = "rid";
        /// <summary>
        /// 实例名。
        /// </summary>
        public const string DataSource = "DataSource";
        /// <summary>
        /// 数据库名。
        /// </summary>
        public const string InitialCatalog = "InitialCatalog";
        /// <summary>
        /// 用户名。
        /// </summary>
        public const string UserID = "UserID";
        /// <summary>
        /// 密码。
        /// </summary>
        public const string Password = "Password";
        public const string ConnectionList = "ConnectionList";


        //构建数据集结构
        private void BuildData()
        {
            DataTable dt = new DataTable(ConnectionList);
            
            dt.Columns.Add(rid, typeof(System.Int32));
            dt.Columns.Add(DataSource, typeof(System.String));
            dt.Columns.Add(InitialCatalog, typeof(System.String));
            dt.Columns.Add(UserID, typeof(System.String));
            dt.Columns.Add(Password, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[rid] };
            dt.TableName = ConnectionList;
            this.Tables.Add(dt);
            this.DataSetName = "TConnection";
        }
        //类构造方法
        public ConnectionData()
        {
            this.BuildData();
        }
    }
}
