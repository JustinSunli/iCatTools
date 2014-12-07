using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenDataLibrary
{
    public class AppParamsData : DataSet
    {
        /// <summary>
        /// 。
        /// <summary>
        public const string rid = "rid";
        /// <summary>
        /// 。
        /// <summary>
        public const string IpAddress = "IpAddress";
        /// <summary>
        /// 。
        /// <summary>
        public const string Port = "Port";
        /// <summary>
        /// 表名。
        /// <summary>
        public const string AppParams = "AppParams";
        private void BuildData()
        {
            DataTable dt = new DataTable(AppParams);
            dt.Columns.Add(rid, typeof(System.Int32));
            dt.Columns.Add(IpAddress, typeof(System.String));
            dt.Columns.Add(Port, typeof(System.Int32));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[rid] };
            dt.TableName = AppParams;
            this.Tables.Add(dt);
            this.DataSetName = "DSAppParams";
        }
        public AppParamsData()
        {
            this.BuildData();
        }
    }
}
