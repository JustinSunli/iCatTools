using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseBusiness
{
    public class UtilityDateTime
    {
        /// <summary>
        /// 获取当前时间的全格式字符串，yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <returns></returns>
        public static string getAllPart()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
