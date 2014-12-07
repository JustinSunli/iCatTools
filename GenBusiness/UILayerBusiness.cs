using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GenClassLibrary;
using System.Reflection;

namespace GenBusiness
{
    public class UILayerBusiness : GenTools
    {
        public UILayerBusiness(string connectString)
            : base(connectString)
        {

        }
        /// <summary>
        /// 获取UI层的数据对象代码
        /// </summary>
        /// <returns></returns>
        public StringBuilder GetDataBaseObjectsForUI()
        {
            #region
            SqlColumn sqlcolClass = new SqlColumn(this._connectString);
            SqlTable sqltabclass= new SqlTable(this._connectString);
            string tablename = "";
            StringBuilder databaseobjects = new StringBuilder();
            DataSet tabDs = sqltabclass.getTableName();
            databaseobjects.AppendLine("Ext.ns(\"Sys.DB\");");
            foreach (DataRow drtable in tabDs.Tables[0].Rows)
            {
                tablename = drtable["name"].ToString();
                databaseobjects.Append("Sys.DB." + tablename + " = {");
                DataSet colDs = sqlcolClass.getColumnsOfTable(tablename);
                foreach (DataRow dr in colDs.Tables[0].Rows)
                    databaseobjects.Append(dr["name"].ToString() + ":'" + dr["name"].ToString() + "',");
                if (colDs.Tables[0].Rows.Count > 0)
                    databaseobjects = databaseobjects.Remove(databaseobjects.Length - 1, 1);
                databaseobjects.AppendLine("};");
            }
            return databaseobjects;
            #endregion
        }
        /// <summary>
        /// 获取UI层的相应代码
        /// </summary>
        /// <param name="nSpace"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public StringBuilder GetUI(string nSpace,string perpageRecord, string startrecord, string handlerName, 
            string deleteInformation,string newEditTitle, string queryTitle, 
            bool isQuery, bool isDelete, bool isNewEdit, string tablename)
        {
            #region
            SqlColumn sqlcolClass = new SqlColumn(this._connectString);
            StringBuilder ui = new StringBuilder();
            string lowertablename = tablename.ToLower();
            DataSet colds = sqlcolClass.getColumnsAndType(tablename);
            DataSet dsPKDs = sqlcolClass.getPkOfTable(tablename);

            ui.AppendLine(this.getNote().ToString());

            #region 业务模块的各项共有参数
            ui.AppendLine("/// 本业务模块的各项共有参数定义");
            ui.AppendLine(nSpace + "." + tablename + "Common = {");
            ui.AppendLine("\thandlerUrl: '" + handlerName + "',");  //可定义动态文件夹
            ui.AppendLine("\tlistStartRecord: " + startrecord + ",");
            ui.AppendLine("\tlistPagesize: " + perpageRecord); //可定义动态参数
            ui.AppendLine("};");
            #endregion

            if (isNewEdit)
            {
                #region 维护界面
                ui.AppendLine("/// 维护界面（新增和编辑）的定义");
                ui.AppendLine("/// <param name=\"isadd\">是否为新增（true为新增）</param>");
                ui.AppendLine("/// <param name=\"" + lowertablename + "Data\">列表框中所引用的store</param>");
                ui.AppendLine("/// <param name=\"currentrows\">针对列表框中选择的当前行（可为多行，所以加's'）</param>");
                ui.AppendLine(nSpace + "." + tablename + "Edit = function (isadd, " + lowertablename + "Data, currentrows) {");
                ui.AppendLine("\tvar " + lowertablename + " = Sys.DB." + tablename + ";");
                ui.AppendLine("\tvar handerurl = " + nSpace + "." + tablename + "Common.handlerUrl;");
                ui.AppendLine("\thanderurl += (isadd) ? 'add' : 'update';");
                ui.AppendLine("\tvar edithandler = {");
                ui.AppendLine("\t\tbuttonclose : function () {");
                ui.AppendLine("\t\t\t" + lowertablename + "topwindow.close();");
                ui.AppendLine("\t\t},");
                ui.AppendLine("\t\tbuttonsave : function () {");
                ui.AppendLine("\t\t\tvar editform = " + lowertablename + "editform.getForm();");
                ui.AppendLine("\t\t\tif (!editform.isValid())");
                ui.AppendLine("\t\t\t\treturn;");
                ui.AppendLine("\t\t\t//此处只要form提交，会默认传输到服务端界面上元素的值。");
                ui.AppendLine("\t\t\teditform.submit({");
                ui.AppendLine("\t\t\t\turl: handerurl,");
                ui.AppendLine("\t\t\t\tmethod: 'post',");
                ui.AppendLine("\t\t\t\tsuccess: function (frm, action) {");
                ui.AppendLine("\t\t\t\t\tvar result = action.result;");
                ui.AppendLine("\t\t\t\t\tif (result.success == 'true') {");
                ui.AppendLine("\t\t\t\t\t\tSys.App.MsgSuccess('保存成功！');");
                ui.AppendLine("\t\t\t\t\t\t" + lowertablename + "Data.reload();");
                ui.AppendLine("\t\t\t\t\t}");
                ui.AppendLine("\t\t\t\t\telse {");
                ui.AppendLine("\t\t\t\t\t\tif (result.msg != null)");
                ui.AppendLine("\t\t\t\t\t\t\tSys.App.MsgFailure(result.msg);");
                ui.AppendLine("\t\t\t\t\t}");
                ui.AppendLine("\t\t\t\t},");
                ui.AppendLine("\t\t\t\tfailure: function (frm, action) {");
                ui.AppendLine("\t\t\t\t\tSys.App.Error(action);");
                ui.AppendLine("\t\t\t\t}");
                ui.AppendLine("\t\t\t});");
                ui.AppendLine("\t\t\t" + lowertablename + "topwindow.close();");
                ui.AppendLine("\t\t}");
                ui.AppendLine("\t};");

                ui.AppendLine("\tvar " + lowertablename + "editform = Ext.create('Sys.App.TopForm', {");
                ui.AppendLine("\t\tfieldDefaults: {");
                ui.AppendLine("\t\t\tlabelWidth: 100, //可微调，以适应不同的界面。");
                ui.AppendLine("\t\t\tanchor: '90%',  //控件所占宽度比例，可微调。");
                ui.AppendLine("\t\t\tlabelAlign: 'right', //标签内容靠左\\右");
                ui.AppendLine("\t\t\tmsgTarget: 'side'");
                ui.AppendLine("\t\t},");
                ui.AppendLine("\t\titems: [");
                this.insertFormField(ui, colds.Tables[0].Rows, lowertablename);
                ui.AppendLine("\t\t]");
                ui.AppendLine("\t});");

                ui.AppendLine("\tvar " + lowertablename + "topwindow = Ext.create('Sys.App.TopWindow', {");
                ui.AppendLine("\t\ttitle: '" + newEditTitle + "',    //窗口名称");
                ui.AppendLine("\t\twidth: 400, //界面初始化时宽、高");
                ui.AppendLine("\t\theight: 220,    //");
                ui.AppendLine("\t\tminWidth: 300,  //界面最小宽高，每个弹出页面必须设置");
                ui.AppendLine("\t\tminHeight: 190, //");
                ui.AppendLine("\t\ticonCls: Sys.App.Icon.addrecord,");
                ui.AppendLine("\t\titems: " + lowertablename + "editform,");
                ui.AppendLine("\t\tbuttons: [");
                ui.AppendLine("\t\t\t{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },");
                ui.AppendLine("\t\t\t{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }");
                ui.AppendLine("\t\t],");
                ui.AppendLine("\t\tlisteners: {");
                ui.AppendLine("\t\t\t'show': function () {");
                ui.AppendLine("\t\t\t\tvar editform = " + lowertablename + "editform.getForm();");
                ui.AppendLine("\t\t\t\tif (!isadd) {");
                ui.AppendLine("\t\t\t\t\teditform.setValues(currentrows[0].data);");
                ui.AppendLine("\t\t\t\t\tthis.setIconCls(Sys.App.Icon.editrecord);");
                ui.AppendLine("\t\t\t\t}");
                ui.AppendLine("\t\t\t\telse {");

                ui.AppendLine("\t\t\t\t\teditform.setValues({ " + this.getSetValuesParams(tablename, dsPKDs) + " });");

                ui.AppendLine("\t\t\t\t}");
                ui.AppendLine("\t\t\t}");
                ui.AppendLine("\t\t}");
                ui.AppendLine("\t});");
                /*
                ui.AppendLine("\t//定义快捷键（回车键为“保存”，ESC默认为关闭该窗口）");
                ui.AppendLine("\tvar keymap = new Ext.util.KeyMap({");
                ui.AppendLine("\t\ttarget: Ext.get(document),");
                ui.AppendLine("\t\tbinding: [{");
                ui.AppendLine("\t\t\tkey: 13,");
                ui.AppendLine("\t\t\tfn: edithandler.buttonsave");
                ui.AppendLine("\t\t}]");
                ui.AppendLine("\t});");
                 * */
                ui.AppendLine("\t" + lowertablename + "topwindow.show();");
                ui.AppendLine("}");
                #endregion
            }
            if (isQuery)
            {
                #region 查询条件界面
                ui.AppendLine("/// 查询条件界面的定义");
                ui.AppendLine("/// <param name=\"" + lowertablename + "grid\">引用了列表框对象</param>");
                ui.AppendLine(nSpace + "." + tablename + "Query = function (" + lowertablename + "grid) {");
                ui.AppendLine("\tvar " + lowertablename + " = Sys.DB." + tablename + ";");
                ui.AppendLine("\tvar queryhandler = {");
                ui.AppendLine("\t\tbuttonclose : function () {");
                ui.AppendLine("\t\t\t" + lowertablename + "topwindow.close();");
                ui.AppendLine("\t\t},");

                ui.AppendLine("\t\tbuttonquery : function () {");
                ui.AppendLine("\t\t\tvar queryform = " + lowertablename + "queryform.getForm();");
                ui.AppendLine("\t\t\tvar getvalue = function (fieldName) {");
                ui.AppendLine("\t\t\t\treturn queryform.findField(fieldName).getValue();");
                ui.AppendLine("\t\t\t}");
                ui.AppendLine("\t\t\tExt.apply(" + lowertablename + "grid.store.proxy.extraParams, {");
                this.insertQueryCondition(ui, colds.Tables[0].Rows, lowertablename);
                ui.AppendLine("\t\t\t});");
                ui.AppendLine("\t\t\t" + lowertablename + "grid.down('#pagingToolbar').moveFirst();");
                ui.AppendLine("\t\t\t" + lowertablename + "topwindow.close();");
                ui.AppendLine("\t\t}");
                ui.AppendLine("\t}");

                ui.AppendLine("\tvar " + lowertablename + "queryform = Ext.create('Sys.App.TopForm', {");
                ui.AppendLine("\t\tfieldDefaults: {");
                ui.AppendLine("\t\t\tlabelWidth: 100, //可微调，以适应不同的界面。");
                ui.AppendLine("\t\t\tanchor: '90%',  //控件所占宽度比例，可微调。");
                ui.AppendLine("\t\t\tlabelAlign: 'right', //标签内容靠左\\右");
                ui.AppendLine("\t\t\tmsgTarget: 'side'");
                ui.AppendLine("\t\t},");
                ui.AppendLine("\t\titems: [");
                this.insertFormField(ui, colds.Tables[0].Rows, lowertablename);
                ui.AppendLine("\t\t]");
                ui.AppendLine("\t});");

                ui.AppendLine("\tvar " + lowertablename + "topwindow = Ext.create('Sys.App.TopWindow', {");
                ui.AppendLine("\t\ttitle: '" + queryTitle + "',    //窗口名称");
                ui.AppendLine("\t\ticonCls: Sys.App.Icon.queryrecord,");
                ui.AppendLine("\t\twidth: 400, //界面初始化时宽、高");
                ui.AppendLine("\t\theight: 220,    //");
                ui.AppendLine("\t\tminWidth: 300,  //界面最小宽高，每个弹出页面必须设置");
                ui.AppendLine("\t\tminHeight: 190, //");
                ui.AppendLine("\t\titems: " + lowertablename + "queryform,");
                ui.AppendLine("\t\tbuttons: [");
                ui.AppendLine("\t\t\t{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },");
                ui.AppendLine("\t\t\t{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }");
                ui.AppendLine("\t\t]");
                ui.AppendLine("\t});");
                /*
                ui.AppendLine("\t//定义快捷键（回车键为“开始查询”，ESC默认为关闭该窗口）");
                ui.AppendLine("\tvar keymap = new Ext.util.KeyMap({");
                ui.AppendLine("\t\ttarget: Ext.get(document),");
                ui.AppendLine("\t\tbinding: [{");
                ui.AppendLine("\t\t\tkey: 13,");
                ui.AppendLine("\t\t\tfn: queryhandler.buttonquery");
                ui.AppendLine("\t\t}]");
                ui.AppendLine("\t});");
                */ 
                ui.AppendLine("\t" + lowertablename + "topwindow.show();");
                ui.AppendLine("}");
                #endregion
            }

            #region 查询界面
            ui.AppendLine("/// 查询界面的定义");
            ui.AppendLine("/// <param name=\"mainPanel\">父容器（本业务界面所在的容器）</param>");
            ui.AppendLine("/// <param name=\"node\">所关联的左边树形节点</param>");
            ui.AppendLine(nSpace + "." + tablename + "Main = function (mainPanel, node) {");
            ui.AppendLine("\tvar " + lowertablename + " = Sys.DB." + tablename + ";");
            ui.AppendLine("\tvar handerurl = " + nSpace + "." + tablename + "Common.handlerUrl;");

            ui.AppendLine("\tvar tbarhandler = {");
            if (isNewEdit)
            {
                ui.AppendLine("\t\taddrecord : function () {");
                ui.AppendLine("\t\t\t" + nSpace + "." + tablename + "Edit(true, " + lowertablename + "data);");
                ui.AppendLine("\t\t},");
                ui.AppendLine("\t\tupdaterecord : function () {");
                ui.AppendLine("\t\t\t" + nSpace + "." + tablename + "Edit(false, " + lowertablename + "data, " + lowertablename + "grid.getSelectionModel().getSelection());");
                ui.AppendLine("\t\t},");
            }
            if (isDelete)
            {
                ui.AppendLine("\t\tdeleterecord : function () {");
                ui.AppendLine("\t\t\tSys.App.Confirm(\"" + deleteInformation + "\", function (btn) {");

                ui.AppendLine("\t\t\t\tif (btn == 'yes') {");
                ui.AppendLine("\t\t\t\t\tvar currentselectrows = " + lowertablename + "grid.getSelectionModel().getSelection();");
                ui.AppendLine("\t\t\t\t\tExt.Ajax.request({");
                ui.AppendLine("\t\t\t\t\t\turl: handerurl + 'delete',");
                ui.AppendLine("\t\t\t\t\t\tparams: { " + this.getdeleteparams(tablename, dsPKDs) + " },");
                ui.AppendLine("\t\t\t\t\t\tsuccess: function (response) {");
                ui.AppendLine("\t\t\t\t\t\t\tvar result = Ext.decode(response.responseText);");
                ui.AppendLine("\t\t\t\t\t\t\tif (result.success == 'true') {");
                ui.AppendLine("\t\t\t\t\t\t\t\tSys.App.MsgSuccess('删除成功！');");
                ui.AppendLine("\t\t\t\t\t\t\t\t" + lowertablename + "data.reload();");
                ui.AppendLine("\t\t\t\t\t\t\t}");
                ui.AppendLine("\t\t\t\t\t\t\telse {");
                ui.AppendLine("\t\t\t\t\t\t\t\tif (result.msg != null)");
                ui.AppendLine("\t\t\t\t\t\t\t\t\tSys.App.MsgFailure(result.msg);");
                ui.AppendLine("\t\t\t\t\t\t\t}");
                ui.AppendLine("\t\t\t\t\t\t},");
                ui.AppendLine("\t\t\t\t\t\tfailure: function (response, opts) {");
                ui.AppendLine("\t\t\t\t\t\t\tSys.App.MsgFailure('\"服务端失败，状态码：\" ' + response.status);");
                ui.AppendLine("\t\t\t\t\t\t}");
                ui.AppendLine("\t\t\t\t\t});");
                ui.AppendLine("\t\t\t\t}");
                ui.AppendLine("\t\t\t});");
                ui.AppendLine("\t\t},");
            }
            if (isQuery)
            {
                ui.AppendLine("\t\tqueryrecord : function () {");
                ui.AppendLine("\t\t\t" + nSpace + "." + tablename + "Query(" + lowertablename + "grid);");
                ui.AppendLine("\t\t},");
            }
            ui.AppendLine("\t\trefreshrecord : function () {");
            ui.AppendLine("\t\t\t" + lowertablename + "data.reload();");
            ui.AppendLine("\t\t}");
            ui.AppendLine("\t};");

            ui.AppendLine("\tExt.define('" + tablename + "Model', {");
            ui.AppendLine("\t\textend: 'Ext.data.Model',");
            ui.AppendLine("\t\tfields: [");
            this.insertModel(ui, colds.Tables[0].Rows, lowertablename);
            ui.AppendLine("\t\t]");
            ui.AppendLine("\t});");
            ui.AppendLine("\tvar " + lowertablename + "data = Ext.create('Ext.data.Store', {");
            ui.AppendLine("\t\tmodel: '" + tablename + "Model',");
            ui.AppendLine("\t\tdefaultPageSize: " + nSpace + "." + tablename + "Common.listPagesize,");
            ui.AppendLine("\t\tproxy: {");
            ui.AppendLine("\t\t\ttype: 'ajax',");
            ui.AppendLine("\t\t\turl: handerurl + 'list',");
            ui.AppendLine("\t\t\tactionMethods: { read: 'POST' },");
            ui.AppendLine("\t\t\treader: { type: 'json', root: 'topics', totalProperty: 'total' }");
            ui.AppendLine("\t\t},");
            ui.AppendLine("\t\tlisteners: {");
            ui.AppendLine("\t\t\tbeforeload: function () {");
            ui.AppendLine("\t\t\t\tExt.apply(this.proxy.extraParams, this.lastOptions.params);");
            ui.AppendLine("\t\t\t}");
            ui.AppendLine("\t\t},");
            ui.AppendLine("\t\tautoLoad: true");
            ui.AppendLine("\t});");
            ui.AppendLine("\tvar " + lowertablename + "grid = Ext.create('Sys.App.TabInnerGrid', {");
            ui.AppendLine("\t\tstore: " + lowertablename + "data,");
            ui.AppendLine("\t\tcolumns: [");
            ui.AppendLine("\t\t\t{ xtype: 'rownumberer', width: 35 },");
            this.insertColumn(ui, colds.Tables[0].Rows, lowertablename);
            ui.AppendLine("\t\t],");
            ui.AppendLine("\t\ttbar: [");
            if(isQuery)
                ui.AppendLine("\t\t\t{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',");
            if (isNewEdit)
            {
                ui.AppendLine("\t\t\t{ text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',");
                ui.AppendLine("\t\t\t{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',");
            }
            if (isDelete)
                ui.AppendLine("\t\t\t{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }, '-',");
            ui.AppendLine("\t\t\t{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }");
            ui.AppendLine("\t\t],");
            ui.AppendLine("\t\tbbar: Ext.create('Ext.PagingToolbar', {");
            ui.AppendLine("\t\t\titemId: 'pagingToolbar',");
            ui.AppendLine("\t\t\tstore: " + lowertablename + "data,");
            ui.AppendLine("\t\t\tdisplayInfo: true,");
            ui.AppendLine("\t\t\tdisplayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',");
            ui.AppendLine("\t\t\temptyMsg: '没有内容可显示',");
            ui.AppendLine("\t\t\tplugins: [new Sys.App.PageSizePlugin()]");
            ui.AppendLine("\t\t})");
            ui.AppendLine("\t});");
            ui.AppendLine("\t//注册侦听选择单行时按钮可用的事件");
            ui.AppendLine("\t" + lowertablename + "grid.getSelectionModel().on('selectionchange',");
            ui.AppendLine("\t\tfunction (sm) {");
            if (isNewEdit)
                ui.AppendLine("\t\t\t" + lowertablename + "grid.down('#editBtn').setDisabled(sm.getCount() != 1);");
            if (isDelete)
            {
                ui.AppendLine("\t\t\t//可删多行");
                ui.AppendLine("\t\t\t" + lowertablename + "grid.down('#removeBtn').setDisabled(sm.getCount() < 1);");
            }
            ui.AppendLine("\t\t}");
            ui.AppendLine("\t);");
            ui.AppendLine("\tmainPanel.viewContent(node, " + lowertablename + "grid);");
            ui.AppendLine("}");
            #endregion

            return ui;
            #endregion
        }
        /// <summary>
        /// 获取代码头部注释部分
        /// </summary>
        /// <returns></returns>
        private StringBuilder getNote()
        {
            #region
            StringBuilder note = new StringBuilder();
            note.AppendLine("/****************************************");
            note.AppendLine("***生成器版本：V" + base.AppVersion);
            note.AppendLine("***创建人：" + base.UserName);
            note.AppendLine("***创建时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            note.AppendLine("***公司：" + base.Company);
            note.AppendLine("***修改人：");
            note.AppendLine("***修改时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            note.AppendLine("***文件描述：。");
            note.AppendLine("*****************************************/\r\n");

            /*
            note.AppendLine("/// <reference path=\"../../../ext/ext-all.js\" />");
            note.AppendLine("/// <reference path=\"../base/Namespace.js\" />");
            note.AppendLine("/// <reference path=\"../base/UIObjects.js\" />");
            note.AppendLine("/// <reference path=\"../base/Error.js\" />");
            note.AppendLine("/// <reference path=\"../base/Msg.js\" />\r\n");
            */
            note.AppendLine("/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。");
            //note.AppendLine("/// 相应属性更改完成后，可将后面提示性质的注释删掉。");            
            return note;
            #endregion
        }
        private string getdeleteparams(string tableName, DataSet dsPKDs)
        {
            #region
            string deleteparamslist = "";
            int pkCount = dsPKDs.Tables[0].Rows.Count;
            for (int i = 0; i < pkCount; i++)
            {
                DataRow dr = dsPKDs.Tables[0].Rows[i];
                deleteparamslist += dr["COLUMN_NAME"].ToString() + ": currentselectrows[0].data." + dr["COLUMN_NAME"].ToString() + ",";
            }
            if (pkCount > 0)
                deleteparamslist = deleteparamslist.Remove(deleteparamslist.Length - 1, 1);

            return deleteparamslist;
            #endregion
        }
        private string getSetValuesParams(string tableName, DataSet dsPKDs)
        {
            #region
            string deleteparamslist = "";
            int pkCount = dsPKDs.Tables[0].Rows.Count;
            for (int i = 0; i < pkCount; i++)
            {
                DataRow dr = dsPKDs.Tables[0].Rows[i];
                deleteparamslist += dr["COLUMN_NAME"].ToString() + ": '1',";
            }
            if (pkCount > 0)
                deleteparamslist = deleteparamslist.Remove(deleteparamslist.Length - 1, 1);

            return deleteparamslist;
            #endregion
        }
        private void insertQueryCondition(StringBuilder code, DataRowCollection drCollect, string lowerTablename)
        {
            #region
            for (int i = 0; i < drCollect.Count; i++)
            {
                string row = "";
                row = drCollect[i]["name"].ToString() + ": getvalue(" + lowerTablename + "." + drCollect[i]["name"].ToString() + ")";
                if (i != drCollect.Count - 1)
                    row += ",";

                code.AppendLine("\t\t\t\t" + row);
            }
            #endregion
        }
        /// <summary>
        /// 为code插入store的Column数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="drCollect">“列”数据集</param>
        /// <param name="lowerTablename">表名的小写格式</param>
        private void insertFormField(StringBuilder code, DataRowCollection drCollect, string lowerTablename)
        {
            #region
            for (int i = 0; i < drCollect.Count; i++)
            {
                string row = "";
                string append = "";
                string xtype = "textfield";
                string type = drCollect[i]["xtype"].ToString();
                if (type == "61")
                {
                    append += "format: Sys.App.Config.dateFormat,";
                    xtype = "datefield";
                }
                if (type == "231")
                    append += "maxLength:" + drCollect[i]["maxlength"].ToString()+","; 

                row = "{ fieldLabel: '" + drCollect[i]["value"].ToString() + "', name: " + lowerTablename + "." + drCollect[i]["name"].ToString() + "," + append + " xtype: '" + xtype + "' }";
                if (i != drCollect.Count - 1)
                    row += ",";

                code.AppendLine("\t\t\t" + row);
            }
            #endregion
        }
        /// <summary>
        /// 获取编辑界面的模块代码
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colDs"></param>
        /// <returns></returns>
        private StringBuilder getEdit( string tablename, DataSet colDs)
        {
            #region
            string lowertablename = tablename.ToLower();
            StringBuilder code = new StringBuilder();
            DataRowCollection drcollect = colDs.Tables[0].Rows;

            code.AppendLine("\tvar handerurl = '../handler/" + tablename + ".ashx?action='; //后台交互的文件名");
            code.AppendLine("\tif (isadd)");
            code.AppendLine("\t\thanderurl += 'add';");
            code.AppendLine("\telse");
            code.AppendLine("\t\thanderurl += 'update';\r\n");

            code.AppendLine("\tvar close = function () {");
            code.AppendLine("\t\t" + lowertablename + "topwindow.close();");
            code.AppendLine("\t};");
            code.AppendLine("\tvar save = function () {");
            code.AppendLine("\t\t//此处只要form提交，会默认传输到服务端界面上元素的值。");
            code.AppendLine("\t\t" + lowertablename + "editform.getForm().submit({");
            code.AppendLine("\t\t\turl: handerurl,");
            code.AppendLine("\t\t\tmethod: 'post',");
            code.AppendLine("\t\t\tsuccess: function (frm, action) {");
            code.AppendLine("\t\t\t\tvar result = action.result;");

            code.AppendLine("\t\t\t\tif (result.success == 'true') {");
            code.AppendLine("\t\t\t\t\tSys.App.MsgSuccess('哈哈，成功！');");
            code.AppendLine("\t\t\t\t}");
            code.AppendLine("\t\t\t\telse {");
            code.AppendLine("\t\t\t\t\tif (result.msg != null)");
            code.AppendLine("\t\t\t\t\t\tSys.App.MsgFailure(result.msg);");
            code.AppendLine("\t\t\t\t}");
            code.AppendLine("\t\t\t},");
            code.AppendLine("\t\t\tfailure: function (frm, action) {");
            code.AppendLine("\t\t\t\tSys.App.Error(action);");
            code.AppendLine("\t\t\t}");
            code.AppendLine("\t\t});");
            code.AppendLine("\t};\r\n");
            code.AppendLine("\tvar " + lowertablename + "editform = Ext.create('Sys.App.TopForm', {");
            code.AppendLine("\t\tfieldDefaults: {");
            code.AppendLine("\t\tlabelWidth: 70, //可微调，以适应不同的界面。");
            code.AppendLine("\t\tanchor: '90%',  //控件所占宽度比例，可微调。");
            code.AppendLine("\t\tlabelAlign: 'right' //标签内容靠左\\右");
            code.AppendLine("\t\t},");
            code.AppendLine("\t\titems: [");

            this.insertFormField(code, drcollect, lowertablename);
            code.AppendLine("\t\t]");
            code.AppendLine("\t});");

            code.AppendLine("\tvar " + lowertablename + "topwindow = Ext.create('Sys.App.TopWindow', {");
            code.AppendLine("\t\ttitle: 'Compose message',    //窗口名称");
            code.AppendLine("\t\twidth: 400, //界面初始化时宽、高");
            code.AppendLine("\t\theight: 300,    //");
            code.AppendLine("\t\tminWidth: 300,  //界面最小宽高，每个弹出页面必须设置");
            code.AppendLine("\t\tminHeight: 190, //");
            code.AppendLine("\t\titems: " + lowertablename + "editform,");
            code.AppendLine("\t\tbuttons: [");
            code.AppendLine("\t\t\t{ minWidth: 80, text: '保存', handler: save },");
            code.AppendLine("\t\t\t{ minWidth: 80, text: '关闭', handler: close }");
            code.AppendLine("\t\t]");
            code.AppendLine("\t});");

            return code;
            #endregion
        }
        /// <summary>
        /// 获取列表界面的代码
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colDs"></param>
        /// <returns></returns>
        private StringBuilder getList(string nSpace, string tablename, DataSet colDs)
        {
            #region
            string lowertablename = tablename.ToLower();
            StringBuilder code = new StringBuilder();
            DataRowCollection drcollect = colDs.Tables[0].Rows;

            code.AppendLine("\tvar refresh = function () {");
            code.AppendLine("\t\t" + lowertablename + "data.reload();");
            code.AppendLine("\t};\r\n");

            code.AppendLine("\tvar addrecord = function () {");
            code.AppendLine("\t\t" + nSpace + "." + tablename + "Edit(true, " + lowertablename + "data);");
            code.AppendLine("\t};\r\n");

            code.AppendLine("\tvar updaterecord = function () {");
            code.AppendLine("\t\t" + nSpace + "." + tablename + "Edit(false, " + lowertablename + "data);");
            code.AppendLine("\t};\r\n");

            code.AppendLine("\tvar deleterecord = function () {");
            code.AppendLine("\t\t" + lowertablename + "data.reload();");
            code.AppendLine("\t};\r\n");

            code.AppendLine("\t/*查询界面相关元素*/");
            code.AppendLine("\tExt.define('" + tablename + "Model', {");
            code.AppendLine("\t\textend: 'Ext.data.Model',");
            code.AppendLine("\t\tfields: [");

            this.insertModel(code, drcollect, lowertablename);

            code.AppendLine("\tvar " + lowertablename + "data = Ext.create('Ext.data.Store', {");
            code.AppendLine("\t\tmodel: '" + tablename + "Model',");
            code.AppendLine("\t\tproxy: {");
            code.AppendLine("\t\t\ttype: 'ajax',");
            code.AppendLine("\t\t\turl: '../handler/" + tablename + ".ashx',"); //hander路径统一设置
            code.AppendLine("\t\t\treader: {");
            code.AppendLine("\t\t\t\ttype: 'json',");
            code.AppendLine("\t\t\t\troot: 'topics',");
            code.AppendLine("\t\t\t\ttotalProperty: 'total'");
            code.AppendLine("\t\t\t}");
            code.AppendLine("\t\t},");
            code.AppendLine("\t\tautoLoad: true");
            code.AppendLine("\t});");

            code.AppendLine("\tvar " + lowertablename + "grid = Ext.create('Sys.App.TabInnerGrid', {");
            code.AppendLine("\t\tstore: " + lowertablename + "data,");
            code.AppendLine("\t\tcolumns: [");
            code.AppendLine("\t\t\t{ xtype: 'rownumberer' },");

            this.insertColumn(code, drcollect, lowertablename);
            code.AppendLine("\t\t],");

            code.AppendLine("\t\ttbar: [");
            code.AppendLine("\t\t\t{ text: '新增', tooltip: '新增', iconCls: 'icon-addRecord', handler: addrecord }, '-',");
            code.AppendLine("\t\t\t{ text: '编辑', tooltip: '编辑', iconCls: 'icon-editRecord', handler: updaterecord }, '-',");
            code.AppendLine("\t\t\t{ text: '删除', tooltip: '删除', iconCls: 'icon-deleteRecord', handler: deleterecord }, '-',");
            code.AppendLine("\t\t\t{ text: '刷新', tooltip: '重新从服务器获取数据', iconCls: 'icon-refreshRecord', handler: refresh }");
            code.AppendLine("\t\t\t],");
            code.AppendLine("\t\tbbar: Ext.create('Ext.PagingToolbar', {");
            code.AppendLine("\t\t\tstore: " + lowertablename + "data,");
            code.AppendLine("\t\t\tdisplayInfo: true,");
            code.AppendLine("\t\t\tdisplayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',");
            code.AppendLine("\t\t\temptyMsg: '没有内容可显示'");
            code.AppendLine("\t\t})");
            code.AppendLine("\t});");

            return code;
            #endregion
        }
        /// <summary>
        /// 为code插入store的Model数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="drCollect">“列”数据集</param>
        /// <param name="lowerTablename">表名的小写格式</param>
        private void insertModel(StringBuilder code, DataRowCollection drCollect, string lowerTablename)
        {
            #region
            for (int i = 0; i < drCollect.Count; i++)
            {
                string row = "";
                string xtype = drCollect[i]["xtype"].ToString();
                string dateformatstring = "";
                if (xtype == "61")
                    dateformatstring = ", dateFormat: Sys.App.Config.datetimeFormat";

                row = "{ name: " + lowerTablename + "." + drCollect[i]["name"].ToString() + ", type: '" + XType.getUIModelTypeName(xtype) + "'" + dateformatstring + " }";
                if (i != drCollect.Count - 1)
                    row += ",";

                code.AppendLine("\t\t\t" + row);
            }
            //code.AppendLine("\t\t]");
            //code.AppendLine("\t});");
            #endregion
        }
        /// <summary>
        /// 为code插入store的Column数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="drCollect">“列”数据集</param>
        /// <param name="lowerTablename">表名的小写格式</param>
        private void insertColumn(StringBuilder code, DataRowCollection drCollect, string lowerTablename)
        {
            #region
            for (int i = 0; i < drCollect.Count; i++)
            {
                string row = "";
                string append = "";
                string type =drCollect[i]["xtype"].ToString();
                if (type == "61")
                    append = " renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat),";

                row = "{ text: \"" + drCollect[i]["value"].ToString() + "\", dataIndex: " + lowerTablename + "." + drCollect[i]["name"].ToString() + "," + append + " sortable: true }";
                if (i != drCollect.Count - 1)
                    row += ",";

                code.AppendLine("\t\t\t" + row);
            }
            #endregion
        }
        /// <summary>
        /// 查询的弹出界面代码
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colDs"></param>
        /// <returns></returns>
        private StringBuilder getQuery(string tablename, DataSet colDs)
        {
            #region
            StringBuilder code = new StringBuilder();
            return code;
            #endregion
        }
        /// <summary>
        /// 获取一般处理程序的代码
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public StringBuilder getHandle(string tablename)
        {
            #region
            StringBuilder code = new StringBuilder();
            SqlColumn sqlcolClass = new SqlColumn(this._connectString);
            string lowertablename = tablename.ToLower();
            DataSet colds = sqlcolClass.getColumnsOfTable(tablename);
            DataSet dsPKDs = sqlcolClass.getPkOfTable(tablename);

            code.AppendLine("/// <summary>");
            code.AppendLine("/// 获取从前台post来的各参数");
            code.AppendLine("/// </summary>");
            code.AppendLine("/// <param name=\"requestObject\">post来的请求对象</param>");
            for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = colds.Tables[0].Rows[i];
                code.AppendLine("/// <param name=\"" + dr["name"].ToString() + "\">" + dr["value"].ToString() + "</param>");
            }
            code.AppendLine("private void getPostParams(HttpRequest requestObject, " + this.gethandlervar(colds, true, true) + ")");
            code.AppendLine("{");
            code.AppendLine("\t#region");
            for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = colds.Tables[0].Rows[i];
                code.AppendLine("\t" + dr["name"].ToString() + " = requestObject.Params[" + tablename + "Data." + dr["name"].ToString() + "];");
            }
            code.AppendLine("\t#endregion");
            code.AppendLine("}");
            code.AppendLine("/// <summary>");
            code.AppendLine("/// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。");
            code.AppendLine("/// </summary>");
            code.AppendLine("/// <param name=\"context\">上下文</param>");
            code.AppendLine("public void ProcessRequest(HttpContext context)");
            code.AppendLine("{");
            code.AppendLine("\t#region");
            code.AppendLine("\tHttpRequest requestobject = context.Request;");
            code.AppendLine("\tString action = requestobject.QueryString[\"action\"];");
            code.AppendLine("\t//申明post来的参数");
            code.AppendLine("\tString " + this.gethandlervar(colds, false, false) + ";");
            code.AppendLine("\tint start = Convert.ToInt32(context.Request.Params[\"start\"]);");
            code.AppendLine("\tint limit = Convert.ToInt32(context.Request.Params[\"limit\"]);");
            code.AppendLine("\tint pageindex = 0;");
            code.AppendLine("\tif (limit != 0)");
            code.AppendLine("\t\tpageindex = (limit + start) / limit;");
            code.AppendLine("\tString json = \"\";");
            code.AppendLine("\t//同业务层开始交互");
            code.AppendLine("\t" + tablename + "Business " + lowertablename + "class = new " + tablename + "Business();");
            code.AppendLine("\t" + tablename + "Data " + lowertablename + "data = new " + tablename + "Data();");
            code.AppendLine("\tthis.getPostParams(requestobject, " + this.gethandlervar(colds, true, false) + ");");
            code.AppendLine("\tswitch (action)");
            code.AppendLine("\t{");
            code.AppendLine("\t\tcase \"list\":");
            code.AppendLine("\t\t\tjson = " + lowertablename + "class.GetJsonByPage(limit, pageindex, " + this.gethandlervar(colds, false, false) + ");");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t\tcase \"viewall\":");
            code.AppendLine("\t\t\tjson = " + lowertablename + "class.GetJsonByAll();");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t\tcase \"add\":");
            code.AppendLine("\t\t\t" + lowertablename + "class.AddRow(ref " + lowertablename + "data, " + this.gethandlervar(colds, false, false) + ");");
            code.AppendLine("\t\t\tjson = " + lowertablename + "class.Save" + tablename + "(" + lowertablename + "data);");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t\tcase \"update\":");
            code.AppendLine("\t\t\t" + lowertablename + "class.EditRow(ref " + lowertablename + "data, " + this.gethandlervar(colds, false, false) + ");");
            code.AppendLine("\t\t\tjson = " + lowertablename + "class.Save" + tablename + "(" + lowertablename + "data);");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t\tcase \"delete\":");

            string pkStr = "";
            for (int i = 0; i < dsPKDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dsPKDs.Tables[0].Rows[i];

                string pkcolumnname = dr["COLUMN_NAME"].ToString().ToLower();
                pkStr += pkcolumnname + ",";
            }
            if (dsPKDs.Tables[0].Rows.Count > 0)
                pkStr = pkStr.Remove(pkStr.Length - 1, 1);

            code.AppendLine("\t\t\t" + lowertablename + "class.DeleteRow(ref " + lowertablename + "data, " + pkStr + ");");
            code.AppendLine("\t\t\tjson = " + lowertablename + "class.Save" + tablename + "(" + lowertablename + "data);");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t\tdefault:");
            code.AppendLine("\t\t\tbreak;");
            code.AppendLine("\t}");
            code.AppendLine("\tcontext.Response.ContentType = \"text/json\";");
            code.AppendLine("\tcontext.Response.Write(json);");
            code.AppendLine("\t#endregion");
            code.AppendLine("}");
            return code;
            #endregion
        }
        private string gethandlervar(DataSet colDs, bool isout, bool isdefine)
        {
            string varstring = "";
            for (int i = 0; i < colDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = colDs.Tables[0].Rows[i];
                if (isout)
                    varstring += "out ";
                if (isdefine)
                {
                    varstring += "String ";
                    varstring += dr["name"].ToString() + ",";
                }
                else
                    varstring += dr["name"].ToString().ToLower() + ",";
            }
            if (colDs.Tables[0].Rows.Count > 0)
                varstring = varstring.Remove(varstring.Length - 1, 1);
            return varstring;
        }
    }
}