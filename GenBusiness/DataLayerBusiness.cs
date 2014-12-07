/****************************************
###创建人：lify
###创建时间：2012-03-02
###公司：Cat Studio
###最后修改时间：2012-03-02
###最后修改人：lify
###修改摘要：获取主键、获取列的描述？？？？
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GenClassLibrary;
using System.Reflection;
using BaseBusiness;

namespace GenBusiness
{
    public class DataLayerBusiness : GenTools
    {
        #region private const members
        private const string dataFileFormat =
@"#region Create by {0}
/****************************************
***生成器版本：V{1}
***创建人：{2}
***生成时间：{3}
***公司：{4}
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Data;
using Fundation.Core;
            
namespace {5}
{{
    public class {6}Data : DataLibBase
    {{
        {7}
        {8}
        public {6}Data()
        {{
            this.BuildData();
        }}
    }}
}}
#endregion";
        private const string buildFunctionFormat =
@"
        private void BuildData()
        {{
            DataTable dt = new DataTable({0});
            {1}
            dt.TableName = {0};
            this.Tables.Add(dt);
            this.DataSetName = ""T{0}"";
        }}
";
        private const string constFormat = 
@"
        /// <summary>
        /// {0}。
        /// </summary>
        public const string {1} = ""{1}"";";

        private const string entityFileFormat =
@"#region Create by {0}
/****************************************
***生成器版本：V{1}
***创建人：{2}
***生成时间：{3}
***公司：{4}
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace {5}
{{
    public class Entity{6}
    {{
        {7}
    }}
}}
#endregion";
        private const string entityFieldFormat =
@"
        /// <summary>
        /// {0}。
        /// </summary>
        public string {1} {{ get; set; }}";

        #endregion

        public DataLayerBusiness(string connectString)
            : base(connectString)
        {
            
        }
        /// <summary>
        /// 异步方法保存业务层文件
        /// </summary>
        /// <param name="tableName"></param>
        public void SaveDataFile(string dir, string dataLayerName, string busicommonName)
        {
            #region
            StringBuilder codeStr = this.GetDataLayerString(
                dataLayerName, busicommonName);
            StringBuilder entityCodeStr = this.GetEntityString(
                dataLayerName);

            string codeDir = dir + "\\" + dataLayerName + "\\";
            string filename = tableName + "Data.cs";
            string entityfilename = "Entity" + tableName + ".cs";

            FileGenerate fileGen = new FileGenerate();
            fileGen.SaveFile(codeDir, filename, codeStr);
            fileGen.SaveFile(codeDir, entityfilename, entityCodeStr);
            #endregion
        }
        /// <summary>
        /// 获取常量列表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colDs"></param>
        /// <returns></returns>
        private StringBuilder getConstList()
        {
            #region
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < this.columnsDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = this.columnsDs.Tables[0].Rows[i];
                string colname = dr["name"].ToString();
                string describe = dr["value"].ToString();
                strBuilder.Append(String.Format(constFormat, describe, colname));
            }
            strBuilder.Append(String.Format(constFormat, "表名", tableName));
            return strBuilder;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colDs"></param>
        /// <returns></returns>
        private StringBuilder getDtColList(DataSet dsPKDs)
        {
            #region
            StringBuilder codestring = new StringBuilder();
            StringBuilder columncode = new StringBuilder();
            int pkCount = dsPKDs.Tables[0].Rows.Count;

            for (int i = 0; i < this.columnsDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = this.columnsDs.Tables[0].Rows[i];
                string colname = dr["name"].ToString();
                string type = dr["xtype"].ToString();
                columncode.Append(String.Format(@"
            dt.Columns.Add({0}, typeof(System.{1}));", colname, XType.getCSharpTypeName(type)));
            }
            if (pkCount > 0)
            {
                string pkstring = "";
                for (int i = 0; i < pkCount; i++)
                {
                    DataRow dr = dsPKDs.Tables[0].Rows[i];
                    pkstring += string.Format("dt.Columns[{0}],", dr["COLUMN_NAME"]);
                }
                pkstring = pkstring.Remove(pkstring.Length - 1, 1);
                columncode.Append(String.Format(@"
            dt.PrimaryKey = new DataColumn[{0}] {{ {1} }};", 
                    pkCount, pkstring));
            }

            codestring.Append(String.Format(buildFunctionFormat, tableName, columncode));
            return codestring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dataLayerName"></param>
        /// <returns></returns>
        public StringBuilder GetDataLayerString( 
            string dataLayerName, string busicommonName)
        {
            #region
            StringBuilder codestring = new StringBuilder();
            DataSet dsPKDs = sqlcolClass.getPkOfTable(tableName);
            string[] codeparams = new string[10];

            codeparams[0] = App.GetName();
            codeparams[1] = BaseBusiness.Version.GetEntryVersion();
            codeparams[2] = base.UserName;
            codeparams[3] = UtilityDateTime.getAllPart();
            codeparams[4] = base.Company;
            codeparams[5] = dataLayerName;
            codeparams[6] = tableName;
            codeparams[7] = this.getConstList().ToString();
            codeparams[8] = this.getDtColList(dsPKDs).ToString();
            codeparams[9] = busicommonName;

            codestring.Append(String.Format(dataFileFormat, codeparams));
            return codestring;
            #endregion
        }

        public StringBuilder GetEntityString(string dataLayerName)
        {
            #region
            StringBuilder codestring = new StringBuilder();
            DataSet dsPKDs = sqlcolClass.getPkOfTable(this.tableName);
            string[] codeparams = new string[8];

            codeparams[0] = App.GetName();
            codeparams[1] = BaseBusiness.Version.GetEntryVersion();
            codeparams[2] = base.UserName;
            codeparams[3] = UtilityDateTime.getAllPart();
            codeparams[4] = base.Company;
            codeparams[5] = dataLayerName;
            codeparams[6] = this.tableName;
            codeparams[7] = this.getEntityFieldList().ToString();


            codestring.Append(String.Format(entityFileFormat, codeparams));
            return codestring;
            #endregion
        }

        private StringBuilder getEntityFieldList()
        {
            #region
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < this.columnsDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = this.columnsDs.Tables[0].Rows[i];
                string colname = dr["name"].ToString();
                string describe = dr["value"].ToString();
                strBuilder.Append(String.Format(entityFieldFormat, describe, colname));
            }
            return strBuilder;
            #endregion
        }

    }
}
