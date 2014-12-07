using BaseBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GenBusiness
{
    public class HandleBusiness : GenTools
    {
        private const string handleFileFormat = 
@"    
    public class {0} :PageHandlerBase, IHttpHandler
    {{
        #region Create by {1}
        /****************************************
        ***生成器版本：V{2}
        ***生成时间：{3}
        ***公司：{4}
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private Entity{0} {5} = new Entity{0}();
        private {0}Business {5}class = new {0}Business();
        private {0}Data {5}data = new {0}Data();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name=""requestObject""></param>
        private void getPostParams(HttpRequest requestObject)
        {{
            #region
            {6}
            #endregion
        }}
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name=""json""></param>
        private void ActionList(ref string json)
        {{
            #region
            json = this.{5}class.GetJsonByPage({5}, base.GetPageParamsFromClient());
            #endregion
        }}
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name=""json""></param>
        private void ActionGetAll(ref string json)
        {{
            #region
            json = this.{5}class.GetJsonByAll();
            #endregion
        }}
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionAddNew(ref string json)
        {{
            #region
            {5}.writeUser = this.SessionUserId;
            {5}.writeIp = this.SessionUserIp;

            this.{5}class.AddRow(ref {5}data, {5});

            json = this.{5}class.Save{0}({5}data);
            #endregion
        }}
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionEdit(ref string json)
        {{
            #region
            {5}.writeUser = this.SessionUserId;

            this.{5}class.EditRow(ref {5}data, {5});

            json = this.{5}class.Save{0}({5}data);
            #endregion
        }}
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionDelete(ref string json)
        {{
            #region
            this.{5}class.DeleteRow(ref {5}data, {7});
            json = this.{5}class.Save{0}({5}data);
            #endregion
        }}
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {{
            #region
            {5}class.OutputExcel(fileName, base.GetExcelParams(), this.{5});
            #endregion
        }}
        #endregion

        #region public member functons entry point
        /// <summary>
        /// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。
        /// </summary>
        /// <param name=""context"">上下文</param>
        public void ProcessRequest(HttpContext context)
        {{
            #region
            HttpRequest requestobject = context.Request;
            String action = requestobject.QueryString[""action""];
            String json = """";
            //同业务层开始交互

            this.getPostParams(requestobject);

            context.Response.ContentType = ""text/json"";
            switch (action)
            {{
                case ""list"":
                    this.ActionList(ref json);
                    break;
                case ""viewall"":
                    this.ActionGetAll(ref json);
                    break;
                case ""add"":
                    this.ActionAddNew(ref json);
                    break;
                case ""update"":
                    this.ActionEdit(ref json);
                    break;
                case ""delete"":
                    this.ActionDelete(ref json);
                    break;
                case ""outputexcel"":
                    this.ActionOutputExcel(""文件名.xls"");
                    break;
                default:
                    break;
            }}
            context.Response.Write(json);
            #endregion
        }}

        public bool IsReusable
        {{
            #region
            get
            {{
                return false;
            }}
            #endregion
        }}
        #endregion

        #endregion
    }}";
        private const string assignFormat = 
@"
            this.{0}.{1} = requestObject.Params[{2}Data.{1}];";

        public HandleBusiness(string connectString)
            : base(connectString)
        {
            
        }

        private void getPkCollects(DataSet dsPKDs, ref string pkAssignList)
        {
            #region
            int pkCount = dsPKDs.Tables[0].Rows.Count;
            string pkcolumnname = "";

            if (pkCount > 0)
            {
                for (int i = 0; i < pkCount; i++)
                {
                    DataRow dr = dsPKDs.Tables[0].Rows[i];
                    pkcolumnname = dr["COLUMN_NAME"].ToString();

                    pkAssignList += String.Format("{1}.{0},", pkcolumnname, base.tableName.ToLower());
                }
                pkAssignList = pkAssignList.Remove(pkAssignList.Length - 1, 1);
            }
            #endregion
        }

        public StringBuilder GetHandleFile()
        {
            #region
            StringBuilder codestring = new StringBuilder();
            DataSet dsPKDs = sqlcolClass.getPkOfTable(tableName);
            string pkAssignList = "";
            this.getPkCollects(dsPKDs, ref pkAssignList);
            string[] codeparams = new string[8];

            codeparams[0] = base.tableName;
            codeparams[1] = App.GetName();
            codeparams[2] = BaseBusiness.Version.GetEntryVersion();
            codeparams[3] = UtilityDateTime.getAllPart();
            codeparams[4] = base.Company;
            codeparams[5] = base.tableName.ToLower();
            codeparams[6] = this.getFieldAssignList().ToString();
            codeparams[7] = pkAssignList;;

            codestring.Append(String.Format(handleFileFormat, codeparams));
            return codestring;

            #endregion
        }

        private StringBuilder getFieldAssignList()
        {
            #region
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < base.columnsDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = this.columnsDs.Tables[0].Rows[i];
                string colname = dr["name"].ToString();
                string describe = dr["value"].ToString();
                strBuilder.Append(String.Format(assignFormat, base.tableName.ToLower(), colname, base.tableName));
            }
            return strBuilder;
            #endregion
        }
    }
}
