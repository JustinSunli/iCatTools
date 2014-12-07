using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatTools.socket
{
    class TextBoxView
    {

        public delegate void TextBoxInvoke(object textBox, string msg);

        public static void richTextBoxInvoke(object objrichText, string msg)
        {
            #region
            TextBox richText = (TextBox)objrichText;
            if (richText.InvokeRequired)
            {
                TextBoxInvoke rtbi = richTextBoxInvoke;
                richText.BeginInvoke(rtbi, new object[] { richText, msg+"\r\n" });
            }
            else
            {
                richText.AppendText(msg);
            }
            #endregion
        }
    }
}
