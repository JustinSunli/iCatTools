using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCatTools.common
{
    class CurrBusiBase
    {
        private static string _commonLibACC = "BaseSqlLibrary";
        private static string _commonLibBusi = "BaseBusiness";
        private static string _commonLibData = "BaseDataLibrary";
        private static string _currentLibAcc = "SnKeyClassLibrary";
        private static string _currentLibBusi = "SnKeyBusiness";
        private static string _currentLibData = "SnKeyDataLibrary";
        /// <summary>
        /// 当前生成数据集库
        /// </summary>
        public static String CurrentLibData
        {
            #region
            get
            {
                return _currentLibData;
            }
            set
            {
                _currentLibData = value;
            }
            #endregion
        }
        /// <summary>
        /// 当前生成业务库
        /// </summary>
        public static String CurrentLibBusi
        {
            #region
            get
            {
                return _currentLibBusi;
            }
            set
            {
                _currentLibBusi = value;
            }
            #endregion
        }
        /// <summary>
        /// 当前生成数据访问库
        /// </summary>
        public static String CurrentLibAcc
        {
            #region
            get
            {
                return _currentLibAcc;
            }
            set
            {
                _currentLibAcc = value;
            }
            #endregion
        }
        /// <summary>
        /// 公共类业务库
        /// </summary>
        public static String CommonLibData
        {
            #region
            get
            {
                return _commonLibData;
            }
            set
            {
                _commonLibData = value;
            }
            #endregion
        }
        /// <summary>
        /// 公共类数据集库
        /// </summary>
        public static String CommonLibBusi
        {
            #region
            get
            {
                return _commonLibBusi;
            }
            set
            {
                _commonLibBusi = value;
            }
            #endregion
        }
        /// <summary>
        /// 公共类访问库
        /// </summary>
        public static String CommonLibACC
        {
            #region
            get
            {
                return _commonLibACC;
            }
            set
            {
                _commonLibACC = value;
            }
            #endregion
        }
        /// <summary>
        /// 业务数据初始化
        /// </summary>
        public static void Init()
        {
            #region
            CurrBusiBase.CommonLibACC = Config.Get("CommonLibACC", CurrBusiBase.CommonLibACC);
            CurrBusiBase.CommonLibBusi = Config.Get("CommonLibBusi", CurrBusiBase.CommonLibBusi);
            CurrBusiBase.CommonLibData = Config.Get("CommonLibData", CurrBusiBase.CommonLibData);
            CurrBusiBase.CurrentLibAcc = Config.Get("CurrentLibAcc", CurrBusiBase.CurrentLibAcc);
            CurrBusiBase.CurrentLibBusi = Config.Get("CurrentLibBusi", CurrBusiBase.CurrentLibBusi);
            CurrBusiBase.CurrentLibData = Config.Get("CurrentLibData", CurrBusiBase.CurrentLibData);
            #endregion
        }
    }
}
