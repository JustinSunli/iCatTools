/****************************************
###创建人：bhlfy
###创建时间：2012-06-15
###公司：博华科技
###最后修改时间：2012-06-15
###最后修改人：bhlfy
###修改摘要：界面控制显示
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using iCatTools.common;
using System.Reflection;
using System.Collections;
using System.Data;

namespace iCatTools.Frm
{
    class MainView
    {
        private static dlAppendContent appendContent = new dlAppendContent(AppendContent);
        private delegate void dlAppendContent(string textbox, string data);
        private static Form _viewFrm = null;
        private static bool _enableViewCollect = true;
        /// <summary>
        /// 是否显示侦听信息
        /// </summary>
        public static bool EnableViewCollect
        {
            #region
            get
            {
                return _enableViewCollect;
            }
            set
            {
                _enableViewCollect = value;
            }
            #endregion
        }
        /// <summary>
        /// 添加内容到编辑框
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="data"></param>
        private static void AppendContent(string textboxName, string data)
        {
            #region
            //通过反射来获取该对象
            TextBox tb = _viewFrm.GetType().GetField(textboxName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_viewFrm) as TextBox; 
            tb.AppendText(data);
            #endregion
        }
        /// <summary>
        /// 更新com口列表
        /// </summary>
        /// <param name="control"></param>
        /// <param name="datasource"></param>
        public static void UpdateComList(object control, string[] datasource)
        {
            #region
            DataTable dt = new DataTable("tempDT");
            dt.Columns.Add("ID", typeof(System.String));

            DataRow dr;
            for (int i = 0; i < datasource.Length; i++)
            {
                dr = dt.NewRow();
                dr["ID"] = datasource[i];
                dt.Rows.Add(dr);
            }

            ComboBox comlist = (ComboBox)control;
            comlist.DataSource = dt.DefaultView;
            comlist.DisplayMember = "ID";
            comlist.ValueMember = "ID";
            comlist.Update();
            #endregion
        }
        /// <summary>
        /// 异步为控件添加内容
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="content"></param>
        public static void AsyncAppendContent(string textboxName, string content)
        {
            #region
            _viewFrm.BeginInvoke(appendContent, new object[] { textboxName, content });
            #endregion
        }
        /// <summary>
        /// 异步为com口列表更新数据源
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="datasource"></param>
        public static void AsyncUpdateComList(MainForm frm, string[] datasource)
        {
            #region
            //frm.BeginInvoke(updatecomlist, new object[] { frm.cmbComList, datasource });
            #endregion
        }
        /// <summary>
        /// 设置窗体标题
        /// </summary>
        public static void SetTitle()
        {
            #region
            string appFullname = string.Format("{0} V{1}", ApplicationBase.ApplicationName, ApplicationBase.ApplicationVersion);
            _viewFrm.Text = appFullname;
            #endregion
        }
        /// <summary>
        /// 设置窗口状态栏图标
        /// </summary>
        /// <param name="nIcon"></param>
        public static void SetStatusIcon(NotifyIcon nIcon)
        {
            #region
            IconStatus iconStatus = new IconStatus(nIcon, _viewFrm);
            iconStatus.SetIcon();
            #endregion
        }
        /// <summary>
        /// 设置显示窗
        /// </summary>
        /// <param name="frm"></param>
        public static void SetViewForm(Form frm)
        {
            #region
            _viewFrm = frm;
            #endregion
        }

    }
}
