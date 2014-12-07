using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenClassLibrary;
using System.Data;
using System.Reflection;
using BaseBusiness;

namespace GenBusiness
{
    public class AccessLayerBusiness : GenTools
    {
        #region private members
        private const string accessFileFormat =
@"/****************************************
***创建人：{0}
***创建时间：{1}
***公司：{2}
***修改人：
***修改时间：
***文件描述：。
*****************************************/

using BusinessBase;
using Fundation.Core;
using System;

namespace {3}
{{
    public class {4}Class : GeneralAccessor
    {{
        #region 自定义业务关联访问
        #endregion
    }}
}}
";
        /*
        private const string selectFunctionFormat = 
        @"
        /// <summary>
        /// 检索数据并分页返回数据集
        /// </summary>
        /// <param name=""recordCount"">符合条件的总记录数</param>
        /// <param name=""qParams"">分页对象</param>
        /// <param name=""conditions"">查询条件集合</param>
        /// <returns>分页数据</returns>
        public DataSet Select{0}ByPage(out int recordCount, QueryParam qParams, 
            Conditions conditions)
        {{
            #region
            string businessSql = @""SELECT * FROM [{0}]"";
            qParams.SetDefaultOrderBy({0}Data.{1}, EnumSQLOrderBY.ASC);
            base.SetViewTableName({0}Data.{0});
            base.CreateSql(businessSql, conditions);
            return base.SelectDataByPage(out recordCount, qParams);
            #endregion
        }}";

        private const string selectAllDataFormat = 
        @"
        /// <summary>
        /// 无分页条件检索数据
        /// </summary>
        /// <param name=""conditions"">查询条件集合</param>
        /// <returns>符合条件的数据</returns>
        public {0}Data Select{0}(Conditions conditions)
        {{
            #region
            {0}Data {1}data = new {0}Data();
            string businessSql = @""SELECT * FROM [{0}]"";
            base.SetViewTableName({0}Data.{0});
            base.CreateSql(businessSql, conditions);
            base.SelectData({1}data);
            return {1}data;
            #endregion
        }}";

        private const string getMaxAndOne =
        @"
        /// <summary>
        /// 获取该表中主键的最大值+1
        /// </summary>
        public override int GetMaxAddOne()
        {{
            #region
            return base.GetMaxFromTable({0}Data.{0}, {0}Data.{1});
            #endregion
        }}";
         * */
        #endregion

        public AccessLayerBusiness(string connectString)
            : base(connectString)
        {
            
        }
        /// <summary>
        /// 异步方法保存数据访问层文件
        /// </summary>
        /// <param name="tableName"></param>
        public void SaveAccessFile(string dir, string AccLayerName, 
            string dataLayerName, string baseSqlLayerName, string busicommonName)
        {
            #region
            StringBuilder codeStr = this.GetAccLayerString(
                AccLayerName, dataLayerName, baseSqlLayerName, busicommonName);

            string codeDir = dir + "\\" + AccLayerName + "\\";
            string filename = tableName + "Class.cs";

            FileGenerate fileGen = new FileGenerate();
            fileGen.SaveFile(codeDir, filename, codeStr);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getPrimaryFirstKey()
        {
            #region
            string pk0 = "";
            SqlColumn sqlColClass = new SqlColumn(this._connectString);
            DataSet pkDs = sqlColClass.getPkOfTable(tableName);
            if (pkDs.Tables[0].Rows.Count > 0)
                pk0 = pkDs.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            return pk0;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="AccLayerName"></param>
        /// <param name="dataLayerName"></param>
        /// <param name="baseSqlLayerName"></param>
        /// <returns></returns>
        public StringBuilder GetAccLayerString( string AccLayerName, 
            string dataLayerName, string baseSqlLayerName, string busicommonName)
        {
            #region
            StringBuilder codestring = new StringBuilder();
            string firstkey = this.getPrimaryFirstKey();
            string[] codeparams = new string[5];

            codeparams[0] = base.UserName;
            codeparams[1] = UtilityDateTime.getAllPart();
            codeparams[2] = base.Company;
            codeparams[3] = AccLayerName;
            codeparams[4] = tableName;
            codestring.Append(String.Format(accessFileFormat, codeparams));

            return codestring;
            #endregion
        }
    }
}
