using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AccessLibrary
{
    /// <summary>
    /// 数据库操作基类
    /// </summary>
    public class AccessBase : IDisposable
    {
        #region 取出连接数据库的字符串配置
        /// <summary>
        /// 取出连接数据库的字符串配置
        /// </summary>
        private string ConnectString
        {
            get
            {
                string values = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                return values;
            }
        }

        #endregion

        #region 数据库的对象
        /// <summary>
        /// 表示用于填充 DataSet 和更新 SQL Server 数据库的一组数据命令和一个数据库连接。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlDataAdapter sqlDataAdapter1
        {
            get
            {
                return this.sqlDataAdaptermy;
            }
            set
            {
                this.sqlDataAdaptermy = value;
            }
        }
        /// <summary>
        /// 表示 SQL Server 数据库的一个打开的连接。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlConnection sqlConnection1
        {
            get
            {
                return this.sqlConnectionmy;
            }
            set
            {
                this.sqlConnectionmy = value;
            }
        }
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个查询语句或存储过程。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlCommand sqlSelectCommand1
        {
            get
            {
                return this.sqlSelectCommandmy;
            }
        }

        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个插入语句或存储过程。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlCommand sqlInsertCommand1
        {
            get
            {
                return this.sqlInsertCommandmy;
            }
        }
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个更新语句或存储过程。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlCommand sqlUpdateCommand1
        {
            get
            {
                return this.sqlUpdateCommandmy;
            }
        }
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个删除语句或存储过程。
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        protected SqlCommand sqlDeleteCommand1
        {
            get
            {
                return this.sqlDeleteCommandmy;
            }
        }



        /// <summary>
        /// 表示用于填充 DataSet 和更新 SQL Server 数据库的一组数据命令和一个数据库连接。
        /// </summary>
        private SqlDataAdapter sqlDataAdaptermy = new SqlDataAdapter();
        /// <summary>
        /// 表示 SQL Server 数据库的一个打开的连接。
        /// </summary>
        private SqlConnection sqlConnectionmy = new SqlConnection();
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个查询语句或存储过程。
        /// </summary>
        private SqlCommand sqlSelectCommandmy = new SqlCommand();
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个插入语句或存储过程。
        /// </summary>
        private SqlCommand sqlInsertCommandmy = new SqlCommand();
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个更新语句或存储过程。
        /// </summary>
        private SqlCommand sqlUpdateCommandmy = new SqlCommand();
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个删除语句或存储过程。
        /// </summary>
        private SqlCommand sqlDeleteCommandmy = new SqlCommand();


        #endregion

        #region 给sqlDataAdapter1的各个执行Command赋值。
        /// <summary>
        /// 给sqlDataAdapter1的各个执行Command赋值。
        /// </summary>
        private void BuildSqlClient()
        {
            //this.sqlSelectCommand1.CommandType = CommandType.StoredProcedure;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;

            this.sqlConnection1.ConnectionString = ConnectString;

            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;

            this.sqlDataAdapter1.SelectCommand.CommandTimeout = 100000;

        }
        /// <summary>
        ///  给sqlDataAdapter1的各个执行Command赋值。
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        private void BuildSqlClient(String connstr)
        {
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;

            this.sqlConnection1.ConnectionString = connstr;

            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;

            this.sqlDataAdapter1.SelectCommand.CommandTimeout = 100000;

        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessBase()
        {
            this.BuildSqlClient();
        }
        /// <summary>
        /// 构造函数，外部提供连接字符串
        /// </summary>
        /// <param name="connstr"> 连接字符串 </param>
        public AccessBase(String connstr)
        {
            this.BuildSqlClient(connstr);
        }

        #region 释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
        /// <summary>
        /// 释放定义的Command资源
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            //if(this.sqlConnection1!=null)
            //{
            //    sqlConnection1.Close();
            //    sqlConnection1.Dispose();
            //    sqlConnection1=null;
            //}
            if (this.sqlConnectionmy != null)
            {
                this.sqlConnectionmy.Close();
                this.sqlConnectionmy.Dispose();
                this.sqlConnectionmy = null;
            }
            //if(this.sqlDataAdapter1!=null)
            //{
            //    if(this.sqlInsertCommand1!=null)sqlInsertCommand1.Dispose();
            //    if(this.sqlUpdateCommand1!=null)sqlUpdateCommand1.Dispose();
            //    if(this.sqlDeleteCommand1!=null)sqlDeleteCommand1.Dispose();
            //    if(this.sqlSelectCommand1!=null)sqlSelectCommand1.Dispose();

            //    this.sqlDataAdapter1.Dispose();
            //    this.sqlDataAdapter1=null;
            //}

            if (this.sqlDataAdaptermy != null)
            {
                if (this.sqlInsertCommandmy != null) sqlInsertCommandmy.Dispose();
                if (this.sqlUpdateCommandmy != null) sqlUpdateCommandmy.Dispose();
                if (this.sqlDeleteCommandmy != null) sqlDeleteCommandmy.Dispose();
                if (this.sqlSelectCommandmy != null) sqlSelectCommandmy.Dispose();

                this.sqlDataAdaptermy.Dispose();
                this.sqlDataAdaptermy = null;
            }


        }
        #endregion

        #region 打开数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public void OpenDatabase() //连接数据库
        {
            if (this.sqlConnection1.State == System.Data.ConnectionState.Closed)
            {
                this.sqlConnection1.Open();
            }
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseDatabase() //断开数据库
        {
            this.sqlConnection1.Close();
            this.ClearParameters();
        }
        /// <summary>
        /// 清除所有适配器、Command命令执行器的参数
        /// </summary>
        protected void ClearParameters()
        {
            this.sqlDataAdapter1.TableMappings.Clear();
            this.sqlSelectCommand1.Parameters.Clear();
            this.sqlInsertCommand1.Parameters.Clear();
            this.sqlUpdateCommand1.Parameters.Clear();
            this.sqlDeleteCommand1.Parameters.Clear();

            this.sqlDataAdapter1.SelectCommand.CommandText = "";
            this.sqlDataAdapter1.InsertCommand.CommandText = "";
            this.sqlDataAdapter1.UpdateCommand.CommandText = "";
            this.sqlDataAdapter1.DeleteCommand.CommandText = "";

            this.sqlDataAdapter1.SelectCommand.CommandType = CommandType.Text;
            //this.sqlDataAdapter1.SelectCommand.CommandType = CommandType.StoredProcedure;
            this.sqlDataAdapter1.InsertCommand.CommandType = CommandType.Text;
            this.sqlDataAdapter1.UpdateCommand.CommandType = CommandType.Text;
            this.sqlDataAdapter1.DeleteCommand.CommandType = CommandType.Text;

            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;

        }
        #endregion



    }
}
