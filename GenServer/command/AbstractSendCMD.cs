/****************************************
###创建人：bhlfy
###创建时间：2011-09-03
###公司：博华科技
###最后修改时间：2011-09-03
###最后修改人：bhlfy
###修改摘要：发送类指令的抽象类，用于构造最终发送命令
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenServer.command
{
    public abstract class AbstractSendCMD
    {
        protected byte baseStationType = 0x01;
        /// <summary>
        /// 获取数据主体
        /// </summary>
        /// <returns></returns>
        protected abstract byte[] GetDataByte(out CommandType cmdType);
        public byte[] GetSendCMDByte() {
            CommandType cmdtype;
            byte[] sourcedata = this.GetDataByte(out cmdtype);
            return CreateSendCMD(cmdtype, sourcedata);
        }
        /// <summary>
        /// 构造最终欲发送的数据
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateSendCMD(CommandType cmdType,byte[] sourceData)
        {
            #region
            byte[] cmdlenArr = new byte[4];
            cmdlenArr = BitConverter.GetBytes(sourceData.Length + 6);
            byte[] b1 = new byte[sourceData.Length + 4];//sourceData;//this.GetCommandByte();
            b1[0] = (byte)cmdType; //命令字
            b1[1] = cmdlenArr[1];    //字节长
            b1[2] = cmdlenArr[0];    

            for (int i = 0; i < sourceData.Length; i++)
                b1[3 + i] = sourceData[i];
            b1[sourceData.Length + 3] = CMDCompute.GetXorResult(b1, 0, sourceData.Length);

            byte[] b2 = new byte[b1.Length * 2 + 2];
            byte[] b1Asc = getAscCode(b1,0);

            b2[0] = 0x03;
            for (int i = 0; i < b1.Length+3; i++)
                b2[1 + i] = b1Asc[i];
            b2[b1.Length+4] = 0x13;

            return b2;
            #endregion
        }

        public static byte[] getAscCode(byte[] data, int startIndex)
        {
            if (null == data)
            {
                return null;
            }
            int len = data.Length;
            byte[] result = new byte[len+3];//len * 2

            for (int i = 0; i < 3; i++) //len
            {
                result[i * 2] = getAscCode(data[i])[0];
                result[i * 2 + 1] = getAscCode(data[i])[1];
            }
            for (int i = 0; i < len - 3; i++)
                result[6 + i] = data[3 + i];
            return result;
        }

        /// <summary>
        /// 获取单字节的ASCII编码字节数组
        /// </summary>
        /// <param name="sCode">输入一个字节</param>
        /// <returns></returns>
        private static byte[] getAscCode(byte sCode)
        {
            byte[] ascCode = new byte[2];
            ascCode[0] = (byte)((sCode >> 4) <= 9 ? (sCode >> 4) + 0x30 : (sCode >> 4) + 0x37);
            ascCode[1] = (byte)((sCode & 0xf) <= 9 ? (sCode & 0xf) + 0x30 : (sCode & 0xf) + 0x37);

            return ascCode;
        }

    }
}
