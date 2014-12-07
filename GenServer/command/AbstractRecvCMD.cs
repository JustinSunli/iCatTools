/****************************************
###创建人：bhlfy
###创建时间：2011-08-21
###公司：博华科技
###最后修改时间：2011-08-21
###最后修改人：bhlfy
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenServer.command
{
    public abstract class AbstractRecvCMD
    {
        protected byte[] _dataBuffer;
        public AbstractRecvCMD()
        {
            
        }
        public AbstractRecvCMD(byte[] dataBuffer)
        {
            this._dataBuffer = dataBuffer;
        }
        /// <summary>
        /// 验证命令字节长是否符合
        /// </summary>
        /// <param name="dataBuffer"></param>
        /// <returns></returns>
        protected virtual bool ValidateLength()
        {
            #region
            int byteLen = (this._dataBuffer[2] << 8) + this._dataBuffer[3];
            if (_dataBuffer.Length == byteLen) //数组长度=数组[1]
                return true;
            else
                return false;
            #endregion
        }
        /// <summary>
        /// 校验数据（异或和校验）
        /// </summary>
        /// <returns></returns>
        protected bool VerifyData()
        {
            #region
            byte[] cmdArr;
            //可更新为Array.Copy
            ArrayList tmpArr = new ArrayList(_dataBuffer);
            tmpArr.RemoveAt(_dataBuffer.Length - 1);//去尾
            tmpArr.RemoveAt(_dataBuffer.Length - 2);//去校验和
            tmpArr.RemoveAt(0);//切头

            cmdArr = (byte[])tmpArr.ToArray(typeof(byte));

            byte xor = CMDCompute.GetXorResult(cmdArr);
            if (_dataBuffer[_dataBuffer.Length - 2] == xor)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 保存原始数据（此处有不做保存的情况，所以设计为空方法）
        /// </summary>
        protected virtual void SaveOriginalData() { }
        /// <summary>
        /// 处理命令(对外接口)
        /// </summary>
        /// <returns></returns>
        public bool SaveCommand(out byte[] responseByte, out string srvView)
        {
            #region
            bool issuccess = false;
            
            if (this.ValidateLength())
            {
                if (this.VerifyData())
                {
                    this.SaveOriginalData();
                    issuccess = true;
                }
            }
            //不符合格式的
            /*
            if (!issuccess)
                this.WriteLog();
            */
            //返回响应
            responseByte = returnAck(issuccess, out srvView);
            return issuccess;
            #endregion
        }
        /// <summary>
        /// 返回响应
        /// </summary>
        /// <returns></returns>
        public virtual byte[] returnAck(bool isSuccess, out string srvView)
        {
            srvView = "";
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /*
        private void WriteLog()
        {
            PerRTLogRecordBusiness logWrite = new PerRTLogRecordBusiness(DateTime.Now.ToString("yyyyMMdd")+".txt","logs");
            logWrite.writeFile(BitConverter.ToString(_dataBuffer));
        }
        */
    }
}
