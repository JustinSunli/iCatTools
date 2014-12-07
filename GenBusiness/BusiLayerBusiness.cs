using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GenClassLibrary;
using System.IO;
using System.Reflection;
using BaseBusiness;

namespace GenBusiness
{
    public class BusiLayerBusiness : GenTools
    {
        #region private members
        private const string businessFileFormat =
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
using System.Data;
using {3};
using {4};

namespace {5}
{{
    public class {6}Business : GeneralBusinesser
    {{
        private {6}Class _{17}class = new {6}Class();
        #region Create by {7}
        /****************************************
        ***生成器版本：V{8}
        ***生成时间：{1}
        ***公司：{2}
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        {9}
        {10}
        {11}
        {12}
        {13}
        {15}
        #endregion

        #region private members methods
        {14}
        {16}
        #endregion

        #endregion
    }}
}}
";
        private const string addFunctionFormat =
@"        
        /// <summary>
        /// 添加{0}表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name=""{1}data"">数据集对象</param>
        /// <param name=""{1}"">实体对象</param>
        public void AddRow(ref {0}Data {1}data, Entity{0} {1})
        {{
            #region
            DataRow dr = {1}data.Tables[0].NewRow();{2}
            {1}data.Tables[0].Rows.Add(dr);
            #endregion
        }}";

        private const string editFunctionFormat =
@"
        /// <summary>
        /// 编辑{0}data数据集中指定的行数据
        /// </summary>
        /// <param name=""{0}data"">数据集对象</param>
        /// <param name=""{0}"">实体对象</param>
        public void EditRow(ref {1}Data {0}data, Entity{1} {0})
        {{
            #region
            if ({0}data.Tables[0].Rows.Count <= 0)
                {0}data = this.getData({2});
            DataRow dr = {0}data.Tables[0].Rows.Find(new object[{3}] {{{2}}});{4}
            #endregion
        }}";
        private const string deleteFunctionFormat =
@"		
        /// <summary>
        /// 删除{0}data数据集中指定的行数据
        /// </summary>
        /// <param name=""{0}data"">数据集对象</param>{5}
        public void DeleteRow(ref {1}Data {0}data,{2})
        {{
            #region
            if ({0}data.Tables[0].Rows.Count <= 0)
                {0}data = this.getData({3});
            DataRow dr = {0}data.Tables[0].Rows.Find(new object[{4}] {{ {3} }});
            if (dr != null)
                dr.Delete();
            #endregion
        }}";

        private const string saveFunctionFormat =
@"
        /// <summary>
        /// 保存{0}data数据集数据
        /// </summary>
        /// <param name=""{0}data"">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String Save{1}({1}Data {0}data)
        {{
            #region
            return base.Save({0}data, this._{0}class);
            #endregion
        }}";
        private const string selectFunctionFormat =
@"
        /// <summary>
        /// 根据条件筛选所有{0}指定页码的数据（分页型）
        /// </summary>
        /// <param name=""{1}"">实体对象</param>
        /// <param name=""pageparams"">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(Entity{0} {1}, PageParams pageparams)
        {{
            #region
            int totalCount = 0;
            DataSet {1}data = this.GetData({1}, pageparams, out totalCount);
            return base.GetJson({1}data, totalCount);
            #endregion
        }}";
        private const string getAllFunctionFormat =
@"
        /// <summary>
        /// 获取{0}数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {{
            #region
            int totalCount = 0;
            {0}Data {1}data = this.getData({2});
            totalCount = {1}data.Tables[0].Rows.Count;
            return base.GetJson({1}data, totalCount);
            #endregion
        }}";
        private const string getbykeyFunctionFormat =
@"
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>{4}
        /// <returns></returns>
        private {1}Data getData({0})
        {{
            #region
            {1}Data {2}data = new {1}Data();
            DBConditions querybusinessparams = new DBConditions();{3}
            this._{2}class.GetSingleTAllWithoutCount({2}data, querybusinessparams);   
            return {2}data;
            #endregion
        }}";
        private const string getDataByPageFormat =
@"
        /// <summary>
        /// 根据条件筛选所有{0}指定页码的数据（分页型）
        /// </summary>
        /// <param name=""{1}"">实体对象</param>
        /// <param name=""pageparams"">分页对象</param>
        /// <param name=""totalCount"">符合条件的记录总数量</param>
        /// <returns></returns>
        public {0}Data GetData(Entity{0} {1}, PageParams pageparams, out int totalCount)
        {{
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);{2}
            {0}Data {1}data = new {0}Data();
            totalCount = this._{1}class.GetSingleT({1}data, querybusinessparams);
            return {1}data;
            #endregion
        }}";
        /*
        private const string getOutputExcelFormat =
@"
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name=""filename""></param>
        /// <param name=""grid""></param>
        /// <param name=""httplink""></param>
        public void OutputExcel(string filename, ExtjsGrid grid, Entity{0} {1})
        {{
            #region
            int totalcount = 0;
            QueryParam queryparams = new QueryParam(1, 65536);
            DataSet ds = this.GetData({1}, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }}";
         * */
        #endregion

        public StringBuilder getDataByPage(string conditions)
        {
            #region

            string[] codeparams = new string[3];
            codeparams[0] = base.tableName;
            codeparams[1] = base.tableName.ToLower();
            codeparams[2] = conditions;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(getDataByPageFormat, codeparams));
            return codestring;
            #endregion
        }
        
        public BusiLayerBusiness(string connectString)
            : base(connectString)
        {

        }
        /// <summary>
        /// 异步方法保存业务层文件
        /// </summary>
        /// <param name="tableName"></param>
        public void SaveBusiFile( string dir, string dataLayerName,
            string baseBusiLayer, string classLayerName, string busiLayerName)
        {
            #region
            StringBuilder codeStr = this.getSingleBusiFileCode(
                dataLayerName, baseBusiLayer, classLayerName, busiLayerName);

            string codeDir = dir + "\\" + busiLayerName + "\\";
            string filename = tableName + "Business.cs";

            FileGenerate fileGen = new FileGenerate();
            fileGen.SaveFile(codeDir, filename, codeStr);
            #endregion
        }
        /// <summary>
        /// 获取单个文件的业务层代码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dataLayerName"></param>
        /// <param name="baseBusiLayer"></param>
        /// <param name="classLayerName"></param>
        /// <param name="busiLayerName"></param>
        /// <returns></returns>
        public StringBuilder getSingleBusiFileCode( string dataLayerName,
            string baseBusiLayer, string classLayerName, string busiLayerName)
        {
            #region
            StringBuilder codestring = new StringBuilder();
            SqlColumn sqlColClass = new SqlColumn(this._connectString);
            DataSet allColumns = sqlColClass.getColumnsOfTable(tableName);
            DataSet dsPKDs = sqlColClass.getPkOfTable(tableName);
            int pkcount = dsPKDs.Tables[0].Rows.Count;

            string conditions = "";
            string assignlist = "";
            string pksummarylist = "";
            string pkconditions = "";
            string pkparamslist = "";
            string pkassignlist = "";
            string pkassignlistwithoutobject = "";
            string pknulllist = "";

            this.getCollects(allColumns, ref conditions, ref assignlist);
            this.getPkCollects(allColumns, dsPKDs, 
                ref pksummarylist, ref pkparamslist, ref pkconditions,
                ref pkassignlist, ref pknulllist, ref pkassignlistwithoutobject);

            string[] codeparams = new string[18];
            codeparams[0] = base.UserName;
            codeparams[1] = UtilityDateTime.getAllPart();
            codeparams[2] = base.Company;
            codeparams[3] = dataLayerName;
            codeparams[4] = classLayerName;
            codeparams[5] = busiLayerName;
            codeparams[6] = tableName;
            codeparams[7] = App.GetName();
            codeparams[8] = BaseBusiness.Version.GetEntryVersion();
            codeparams[9] = this.getJsonSelectPage(conditions).ToString();
            codeparams[10] = this.getSaveCode().ToString();
            codeparams[11] = this.getAddCode(assignlist).ToString();
            codeparams[12] = this.getEditCode(assignlist, pkassignlist, pkcount).ToString();
            codeparams[13] = this.getDeleteCode(pkparamslist, pksummarylist, pkassignlistwithoutobject, pkcount).ToString();
            codeparams[14] = this.getBykey( pkparamslist, pkconditions, pksummarylist).ToString();
            codeparams[15] = this.getAllJsonCode(pknulllist).ToString();
            codeparams[16] = this.getDataByPage(conditions).ToString();
            //codeparams[17] = String.Format(getOutputExcelFormat, this.tableName, this.tableName.ToLower());
            codeparams[17] = tableName.ToLower();


            codestring.Append(String.Format(businessFileFormat, codeparams));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 获取赋值参数列表
        /// </summary>
        /// <param name="allColumns"></param>
        /// <returns></returns>
        private string getParamsString(DataSet allColumns)
        {
            #region
            string paramString = "";
            foreach (DataRow dr in allColumns.Tables[0].Rows)
                paramString += dr["name"].ToString() + ",";
            if (allColumns.Tables[0].Rows.Count > 0)
                paramString = paramString.Remove(paramString.Length - 1, 1);
            return paramString;
            #endregion
        }

        private void getPkCollects(DataSet allColumns, DataSet dsPKDs, 
            ref string pkSummaryList,ref string pkParamsList, ref string pkConditions
            , ref string pkAssignList, ref string pknullList, ref string pkassignlistwithoutobject)
        {
            #region
            int pkCount = dsPKDs.Tables[0].Rows.Count;
            string primarykey = "";
            string pkcolumnname = "";
            string colType = "";
            string colName = "";

            if (pkCount > 0)
            {
                for (int i = 0; i < pkCount; i++)
                {
                    DataRow dr = dsPKDs.Tables[0].Rows[i];
                    pkcolumnname = dr["COLUMN_NAME"].ToString();
                    DataRow drpkinfor =  allColumns.Tables[0].Select("name='" + pkcolumnname + "'")[0];

                    primarykey = drpkinfor["value"].ToString();
                    colType = drpkinfor["xtype"].ToString();
                    colName = drpkinfor["name"].ToString();
                    pknullList += "null,";
                    pkAssignList += String.Format("{1}.{0},", pkcolumnname, base.tableName.ToLower());
                    pkParamsList += String.Format("string {0},", pkcolumnname);
                    pkassignlistwithoutobject += String.Format("{0},", pkcolumnname);
                    pkConditions += String.Format(@"
            querybusinessparams.Add({0}Data.{1}, {2}, EnumCondition.Equal, {1});", base.tableName, colName, SqlType.GetEnumString(colType));
                    pkSummaryList += String.Format(@"
        /// <param name=""{0}"">主键-{1}</param>", pkcolumnname, primarykey);
                }
                pknullList = pknullList.Remove(pknullList.Length - 1, 1);
                pkAssignList = pkAssignList.Remove(pkAssignList.Length - 1, 1);
                pkParamsList = pkParamsList.Remove(pkParamsList.Length - 1, 1);
                pkassignlistwithoutobject = pkassignlistwithoutobject.Remove(pkassignlistwithoutobject.Length - 1, 1);
            }
            #endregion
        }
        /// <summary>
        /// 获取摘要和方法参数列表信息
        /// </summary>
        /// <param name="allColumns"></param>
        /// <param name="summaryList"></param>
        /// <param name="paramsList"></param>
        private void getCollects(DataSet allColumns, ref string conditions, ref string assignList)
        {
            #region
            string colType = "";
            string colName = "";
            string colDescribe = "";
            string enumsqltype = "";
            int colscount = allColumns.Tables[0].Rows.Count;
            if (colscount > 0)
            {
                for (int i = 0; i < allColumns.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = allColumns.Tables[0].Rows[i];
                    colType = dr["xtype"].ToString();
                    colName = dr["name"].ToString();
                    colDescribe = dr["value"].ToString();
                    enumsqltype = SqlType.GetEnumString(colType);

                    conditions += String.Format(@"
            querybusinessparams.Add({0}Data.{1}, {2}, 
                EnumCondition.Equal, {3}.{1});",
                    base.tableName, colName, enumsqltype, base.tableName.ToLower());

                    assignList += String.Format(@"
            {0}data.Assign(dr, {1}Data.{2}, {0}.{2});", base.tableName.ToLower(), base.tableName, colName);
                }
            }
            #endregion
        }
        /// <summary>
        /// 根据关键字查询记录
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="pkparamslist"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public StringBuilder getBykey( string pkparamslist, 
            string conditions, string pksummarylist)
        {
            #region
            string[] codeparams = new string[5];
            codeparams[0] = pkparamslist;
            codeparams[1] = base.tableName;
            codeparams[2] = base.tableName.ToLower();
            codeparams[3] = conditions;
            codeparams[4] = pksummarylist;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(getbykeyFunctionFormat,codeparams));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 根据条件获取数据非分页的Json方法
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public StringBuilder getJsonSelectPage(string conditions)
        {
            #region

            string[] codeparams = new string[2];
            codeparams[0] = base.tableName;
            codeparams[1] = base.tableName.ToLower();

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(selectFunctionFormat, codeparams));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public StringBuilder getSaveCode()
        {
            #region
            string dsVarName = base.tableName.ToLower();
            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(saveFunctionFormat, dsVarName, base.tableName));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="allColumns"></param>
        /// <returns></returns>
        public StringBuilder getEditCode(
            string assignlist,string pkassignList, int pkCount)
        {
            #region
            string dsVarName = base.tableName.ToLower();

            string[] codeparams = new string[5];
            codeparams[0] = dsVarName;
            codeparams[1] = tableName;
            codeparams[2] = pkassignList;
            codeparams[3] = pkCount.ToString();
            codeparams[4] = assignlist;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(editFunctionFormat, codeparams));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="allColumns"></param>
        /// <returns></returns>
        public StringBuilder getDeleteCode( string pkparamslist,
            string pksummarylist, string pkassignlist, int pkCount)
        {
            #region
            string dsVarName = base.tableName.ToLower();

            string[] codeparams = new string[6];
            codeparams[0] = dsVarName;
            codeparams[1] = base.tableName;
            codeparams[2] = pkparamslist;
            codeparams[3] = pkassignlist;
            codeparams[4] = pkCount.ToString();
            codeparams[5] = pksummarylist;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(deleteFunctionFormat, codeparams));
            return codestring;

            #endregion
        }
        /// <summary>
        /// 根据表名获取业务层的保存方法
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public StringBuilder getAddCode(string assignlist)
        {
            #region
            string dsVarName = base.tableName.ToLower();

            string[] codeparams = new string[3];
            codeparams[0] = tableName;
            codeparams[1] = dsVarName;
            codeparams[2] = assignlist;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(addFunctionFormat, codeparams));
            return codestring;

            #endregion
        }
        public StringBuilder getAllJsonCode(
            string nulllist)
        {
            #region
            string dsVarName = base.tableName.ToLower();

            string[] codeparams = new string[5];
            codeparams[0] = tableName;
            codeparams[1] = dsVarName;
            codeparams[2] = nulllist;

            StringBuilder codestring = new StringBuilder();
            codestring.Append(String.Format(getAllFunctionFormat, codeparams));
            return codestring;

            #endregion
        }

    }
}
