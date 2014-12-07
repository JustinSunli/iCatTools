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

namespace GenAutoUpdate.common
{
    class ApplicationBase
    {
        private static string _logDirName = "logs";
        private static string _appName = "代码生成器";
        private static string _appVersion = "V1.0";
        private static bool _isReg = false;
        private static string _keyUser = "";
        private static string _appKey = "";
        private static string _regMaxDate = "";
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
    }
}
