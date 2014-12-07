using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iCatTools.common;
using SnKeyGen;

namespace iCatTools.business
{
    class Register
    {
        /// <summary>
        /// 检测注册密钥的合法性
        /// </summary>
        public static void Check()
        {
            #region
            ApplicationBase.IsReg = Config.Get("IsReg", ApplicationBase.IsReg.ToString()) == "true" ? true : false;
            if (!ApplicationBase.IsReg)
            {
                PopupRegKey();
            }
            else
            {
                //验证当前key是否合法

                try
                {
                    DateTime dtStart, dtEnd;
                    ApplicationBase.AppKey = Config.Get("AppKey", ApplicationBase.AppKey);
                    ApplicationBase.KeyUser = Config.Get("KeyUser", ApplicationBase.KeyUser);
                    string[] strArr = Encrypt.DecryptString(ApplicationBase.AppKey.ToString()).Split(';');
                    if (strArr[0] != ApplicationBase.KeyUser)
                    {
                        MessageBase.Show("用户名和密钥不匹配！");
                        PopupRegKey();
                    }
                    if (strArr[1] != HardDisk.GetSerialNumber())
                    {
                        MessageBase.Show(string.Format("此软件绑定了硬件，请重新申请！", strArr[1]));
                        PopupRegKey();
                    }
                    dtStart = Convert.ToDateTime(strArr[2]);
                    dtEnd = Convert.ToDateTime(strArr[3]);
                    if (dtStart <= DateTime.Now && dtEnd >= DateTime.Now)
                    {
                        //MessageBase.Show("注册成功！\r\n有效期从" + dtStart.ToString() + "到" + dtEnd.ToString());
                        //成功后写CONFIG
                        //this.Close();
                        ApplicationBase.RegMaxDate = dtEnd.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBase.Show("密钥过期，请重新申请！");
                        PopupRegKey();
                    }
                }
                catch
                {
                    MessageBase.Show("密钥错误，请重新注册！");
                    PopupRegKey();
                }
            }
            #endregion
        }
        /// <summary>
        /// 弹出注册密钥框
        /// </summary>
        private static void PopupRegKey()
        {
            #region
            ApplicationBase.IsReg = false;
            Frm.Register regFrm = new Frm.Register();
            regFrm.ShowDialog();
            #endregion
        }
    }
}
