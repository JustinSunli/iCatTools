using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccessLibrary;

namespace GenClassLibrary
{
    public class SqlInsert : AccessBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlInsert(string connectionString)
        {
            base.sqlConnection1.ConnectionString = connectionString;
        }
        /// <summary>
        /// 获取插入语句的数据集
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet getInsertData(string tableName)
        {
            #region
            DataSet ds = new DataSet();
            string strSql = "declare @sqlstr varchar(4000) ;" +
 "declare @sqlstr1 varchar(4000) ;" +
 "declare @sqlstr2 varchar(4000) ;" +
 "select @sqlstr='select ''insert " + tableName + "';" +
 "select @sqlstr1='' ;" +
 "select @sqlstr2=' (' ;" +
 "select @sqlstr1= ' values ( ''+' ;" +
 "select @sqlstr1=@sqlstr1+col+'+'',''+' ,@sqlstr2=@sqlstr2+name +',' from (select case  " +
 "when a.xtype =104 then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(1),'+a.name +')'+' end' " +
 "when a.xtype =175 then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'replace('+a.name+','''''''','''''''''''')' + '+'''''''''+' end' " +
 "when a.xtype =61  then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'convert(varchar(23),'+a.name +',121)'+ '+'''''''''+' end' " +
 "when a.xtype =106 then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar('+convert(varchar(4),a.xprec+2)+'),'+a.name +')'+' end' " +
 "when a.xtype =62  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(23),'+a.name +',2)'+' end' " +
 "when a.xtype =56  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(11),'+a.name +')'+' end' " +
 "when a.xtype =60  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(22),'+a.name +')'+' end' " +
 "when a.xtype =239 then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'replace('+a.name+','''''''','''''''''''')' + '+'''''''''+' end' " +
 "when a.xtype =108 then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar('+convert(varchar(4),a.xprec+2)+'),'+a.name +')'+' end' " +
 "when a.xtype =231 then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'replace('+a.name+','''''''','''''''''''')' + '+'''''''''+' end' " +
 "when a.xtype =59  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(23),'+a.name +',2)'+' end' " +
 "when a.xtype =58  then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'convert(varchar(23),'+a.name +',121)'+ '+'''''''''+' end' " +
 "when a.xtype =52  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(12),'+a.name +')'+' end' " +
 "when a.xtype =122 then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(22),'+a.name +')'+' end' " +
 "when a.xtype =48  then 'case when '+a.name+' is null then ''NULL'' else '+'convert(varchar(6),'+a.name +')'+' end' " +
 "when a.xtype =167 then 'case when '+a.name+' is null then ''NULL'' else '+'''''''''+'+'replace('+a.name+','''''''','''''''''''')' + '+'''''''''+' end' " +
 "else '''NULL''' " +
 "end as col,a.colid,a.name " +
 "from syscolumns a where a.id = object_id('" + tableName + "') and a.xtype <>189 and a.xtype <>34 and a.xtype <>35 and  a.xtype <>36 " +
 ")t order by colid ;" +

 "select @sqlstr=@sqlstr+left(@sqlstr2,len(@sqlstr2)-1)+') '+left(@sqlstr1,len(@sqlstr1)-3)+')'' from " + tableName + "';" +
 "exec( @sqlstr);";
            this.sqlSelectCommand1.CommandText = strSql;
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(ds, "InsertData");
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
