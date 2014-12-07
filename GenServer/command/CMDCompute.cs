/****************************************
###创建人：bhlfy
###创建时间：2011-09-02
###公司：博华科技
###最后修改时间：2011-09-02
###最后修改人：bhlfy
###修改摘要：本类实现各种命令数据格式转换，各种校验计算等
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenServer.command
{
    class CMDCompute
    {
        /// <summary>
        /// 计算异或和
        /// </summary>
        /// <param name="cmdArr">切头去尾后不包括校验和的数据字节数组</param>
        /// <returns>返回单字节</returns>
        public static byte GetXorResult(byte[] cmdArr) {
            byte result = 0;

            for (int i = 0; i < cmdArr.Length; i++)
                result ^= cmdArr[i];

            return result;
        }
        /// <summary>
        /// 计算异或和
        /// </summary>
        /// <param name="cmdArr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static byte GetXorResult(byte[] cmdArr,int startIndex,int endIndex)
        {
            byte result = 0;
            int xorLength = endIndex;

            if (xorLength > cmdArr.Length)
                xorLength = cmdArr.Length;
            for (int i = startIndex; i < xorLength; i++)
                result ^= cmdArr[i];

            return result;
        }

        public static DateTime GetDateTimeFromCMD(byte[] cmdArr, int startIndex)
        {
            int year, month, day, hour, minute, second;
            year = int.Parse("20"+cmdArr[startIndex++].ToString("X2"));
            month = int.Parse(cmdArr[startIndex++].ToString("X2"));
            day = int.Parse(cmdArr[startIndex++].ToString("X2"));
            hour = int.Parse(cmdArr[startIndex++].ToString("X2"));
            minute = int.Parse(cmdArr[startIndex++].ToString("X2"));
            second = int.Parse(cmdArr[startIndex++].ToString("X2"));
            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
