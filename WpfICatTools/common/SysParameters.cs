using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WpfICatTools.common
{
    class SysParameters
    {
        /// <summary>
        /// 系统参数初始化
        /// </summary>
        public static void Init()
        {
            #region

            //ApplicationBase.ApplicationName = Config.Get("ApplicationName", ApplicationBase.ApplicationName);
            ApplicationBase.ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ApplicationBase.LogDirName = Config.Get("LogDirName", ApplicationBase.LogDirName);
            ApplicationBase.Company = Config.Get("Company", ApplicationBase.Company);
            ApplicationBase.IsViewLog = bool.Parse(Config.Get("IsViewLog", ApplicationBase.IsViewLog.ToString()));
            ApplicationBase.ConsoleFontSize = Config.Get("ConsoleFontSize", ApplicationBase.ConsoleFontSize);

            ApplicationBase.UINamespace = Config.Get("UINamespace", ApplicationBase.UINamespace);
            ApplicationBase.UIStartrecord = Config.Get("UIStartrecord", ApplicationBase.UIStartrecord);
            ApplicationBase.UIQueryTitle = Config.Get("UIQueryTitle", ApplicationBase.UIQueryTitle);
            ApplicationBase.UINewEditTitle = Config.Get("UINewEditTitle", ApplicationBase.UINewEditTitle);
            ApplicationBase.UIHandlerName = Config.Get("UIHandlerName", ApplicationBase.UIHandlerName);
            ApplicationBase.UIDeleteInformation = Config.Get("UIDeleteInformation", ApplicationBase.UIDeleteInformation);

            ApplicationBase.UIPerpageRecord = Config.Get("UIPerpageRecord", ApplicationBase.UIPerpageRecord);
            ApplicationBase.UIIsQuery = Boolean.Parse(Config.Get("UIIsQuery", ApplicationBase.UIIsQuery.ToString()));
            ApplicationBase.UIIsNewEdit = Boolean.Parse(Config.Get("UIIsNewEdit", ApplicationBase.UIIsNewEdit.ToString()));
            ApplicationBase.UIIsDelete = Boolean.Parse(Config.Get("UIIsDelete", ApplicationBase.UIIsDelete.ToString()));
            #endregion
        }
    }
}
