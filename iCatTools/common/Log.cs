/****************************************
###创建人：lify
###创建时间：2012-06-29
###公司：山西博华科技有限公司
###最后修改时间：2012-06-29
###最后修改人：lify
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogLibrary;
using System.Windows.Forms;
using iCatTools.Frm;

namespace iCatTools.common
{
    class Log
    {
        private static bool _viewConsole = false;
        private static readonly object LogLockObject = true;
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="error"></param>
        public static void Write(string error)
        {
            #region
            lock (LogLockObject)
            {
                LogBusiness log = new LogBusiness(ApplicationBase.LogDirName, ApplicationBase.LogFileName);
                string logTemplate = "Error occurs in {0}\r\n{1}";
                string logContent = String.Format(logTemplate, DateTime.Now.ToString(), error);
                log.writefile(logContent);

                if(_viewConsole)
                    MainView.AsyncAppendContent("tbLogView", error + "\r\n\r\n");
            }
            #endregion
        }
        /// <summary>
        /// 是否显示错误在控制台
        /// </summary>
        /// <param name="enable"></param>
        public static void EnableViewError(bool enable)
        {
            #region
            _viewConsole = enable;
            #endregion
        }
        /// <summary>
        /// 系统错误捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            #region
            Write(e.Exception.ToString());
            #endregion
        }
        /// <summary>
        /// 安排事件侦听错误
        /// </summary>
        public static void Listen()
        {
            #region
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Log.Application_ThreadException);
            #endregion
        }
    }
}
