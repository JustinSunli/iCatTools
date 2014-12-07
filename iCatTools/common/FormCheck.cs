/****************************************
###创建人：lify
###创建时间：2012-03-02
###公司：Cat Studio
###最后修改时间：2012-03-02
###最后修改人：lify
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatTools.common
{
    class FormCheck
    {
        /// <summary>
        /// 检验提交框中控件
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="lb"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckValid(TextBox tb, Label lb, EnumCheck type, ref object value)
        {
            #region
            string tbValue = tb.Text.Trim();
            if (type == EnumCheck.IsEmpty)
            {
                if (tbValue != string.Empty)
                {
                    value = tbValue;
                    return true;
                }
                else
                {
                    MessageBase.NotAllowEmpty(lb);
                    tb.Focus();
                    return false;
                }
            }
            else if (type == EnumCheck.IsNumber)
            {
                try
                {
                    value = Int32.Parse(tbValue);
                    return true;
                }
                catch
                {
                    MessageBase.IsNotNum(lb);
                    tb.Focus();
                    return false;
                }
            }
            else
            {
                return false;
            }
            #endregion
        }
    }
}
