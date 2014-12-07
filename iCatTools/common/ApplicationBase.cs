/****************************************
###创建人：lify
###创建时间：2012-02-26
###公司：Cat Studio
###最后修改时间：2012-02-26
###最后修改人：lify
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using BaseBusiness;

namespace iCatTools.common
{
    class ApplicationBase
    {
        private static string _logDirName = "logs";
        private static string _appName = App.GetName();
        private static string _appVersion = "V1.0";
        private static string _company = "山西博华科技有限公司";
        private static bool _isReg = false;
        private static bool _isViewLog = false;
        private static string _keyUser = "";
        private static string _appKey = "";
        private static string _regMaxDate = "";
        public static String _consoleFontFamily = "Menlo";
        public static String _consoleFontSize = "8";
        public static String UINamespace = "Sys.App.Book";
        public static String UIPerpageRecord = "15";
        public static String UIStartrecord = "0";
        public static String UINewEditTitle = "（主题）信息维护界面";
        public static String UIQueryTitle = "（主题）信息查询界面";
        public static String UIHandlerName = "handler.ashx";
        public static String UIDeleteInformation = "您确认要删除该记录吗？";
        public static Boolean UIIsQuery = true;
        public static Boolean UIIsDelete = true;
        public static Boolean UIIsNewEdit = true;
        /// <summary>
        /// 是否显示日志
        /// </summary>
        public static bool IsViewLog
        {
            #region
            get
            {
                return _isViewLog;
            }
            set
            {
                _isViewLog = value;
            }
            #endregion
        }
        /// <summary>
        /// 密钥最大使用日期
        /// </summary>
        public static String RegMaxDate
        {
            #region
            get
            {
                return _regMaxDate;
            }
            set
            {
                _regMaxDate = value;
            }
            #endregion
        }
        /// <summary>
        /// 密钥
        /// </summary>
        public static String AppKey
        {
            #region
            get
            {
                return _appKey;
            }
            set
            {
                _appKey = value;
            }
            #endregion
        }
        /// <summary>
        /// 密钥用户
        /// </summary>
        public static String KeyUser
        {
            #region
            get
            {
                return _keyUser;
            }
            set
            {
                _keyUser = value;
            }
            #endregion
        }
        /// <summary>
        /// 软件是否注册
        /// </summary>
        public static bool IsReg
        {
            #region
            get
            {
                return _isReg;
            }
            set
            {
                _isReg = value;
            }
            #endregion
        }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static String ApplicationName
        {
            #region
            get
            {
                return _appName;
            }
            set
            {
                _appName = value;
            }
            #endregion
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public static String Company
        {
            #region
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
            #endregion
        }
        /// <summary>
        /// 应用程序版本
        /// </summary>
        public static String ApplicationVersion
        {
            #region
            get
            {
                return _appVersion;
            }
            set
            {
                _appVersion = value;
            }
            #endregion
        }
        /// <summary>
        /// 日志文件名称
        /// </summary>
        public static String LogFileName
        {
            #region
            get
            {
                return DateTime.Now.ToString("yyyyMMdd") + ".txt";
            }
            #endregion
        }
        /// <summary>
        /// 日志目录名
        /// </summary>
        public static String LogDirName
        {
            #region
            get
            {
                return _logDirName;
            }
            set {
                _logDirName = value;
            }
            #endregion
        }
        /// <summary>
        /// 控制台字体
        /// </summary>
        public static String ConsoleFontFamily
        {
            #region
            get
            {
                return _consoleFontFamily;
            }
            set
            {
                _consoleFontFamily = value;
            }
            #endregion
        }
        /// <summary>
        /// 控制台字体大小
        /// </summary>
        public static String ConsoleFontSize
        {
            #region
            get
            {
                return _consoleFontSize;
            }
            set
            {
                _consoleFontSize = value;
            }
            #endregion
        }
    }
}
