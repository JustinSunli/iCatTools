using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCatTools.common
{
    class UxRichTextbox : RichTextBox
    {
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private static string keyliststring = "using|public|private|namespace|class|set|get|void|int|string|float|double|for|foreach|in|object|if|else|while|do|partial|switch|case|default|continue|break|return|new|bool|null|false|true|catch|finally|try|enum|extern|inline|char|byte|const|long|protected|short|signed|unsigned|struct|static|this|throw|union|virtual|abstract|event|as|explicit|base|operator|out|params|typeof|uint|ulong|checked|goto|unchecked|readonly|unsafe|implicit|ref|ushort|decimal|sbyte|interface|sealed|volatile|delegate|internal|is|sizeof|lock|stackalloc|var|value|yield|#region|#endregion";
        private static string[] keylist = keyliststring.Split('|');        

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            SendMessage(base.Handle, 0xB, 0, IntPtr.Zero);
            int sIndex = this.SelectionStart;
            this.SelectAll();
            this.SelectionColor = Color.Black;
            this.Select(sIndex, 0);

            for (int i = 0; i < keylist.Length; i++)
                ChangeColor(keylist[i], Color.Blue);

            this.Select(sIndex, 0);
            this.SelectionColor = Color.Black;
            SendMessage(base.Handle, 0xB, 1, IntPtr.Zero);
            this.Refresh();

        }
        
        protected override void OnFontChanged(EventArgs e)
        {

            base.OnFontChanged(e);
            
            SendMessage(base.Handle, 0xB, 0, IntPtr.Zero);
            int sIndex = this.SelectionStart;
            this.SelectAll();
            this.SelectionColor = Color.Black;
            this.Select(sIndex, 0);

            for (int i = 0; i < keylist.Length; i++)
                ChangeColor(keylist[i], Color.Blue);
            /*
            for (int i = 0; i < keylist.Length; i++)
            {
                DLChangeColor changecolor = new DLChangeColor(this.ChangeColor);
                changecolor.BeginInvoke(keylist[i], Color.Blue, null, null);
            }
             * */
            this.Select(sIndex, 0);
            this.SelectionColor = Color.Black;
            SendMessage(base.Handle, 0xB, 1, IntPtr.Zero);
            this.Refresh();
        }

        private void ChangeAllColor(string[] keylist)
        {
            for (int i = 0; i < keylist.Length; i++)
                ChangeColor(keylist[i], Color.Blue);
        }
        private delegate void DLChangeColor(string text, Color color);
        private void ChangeColor(string text, Color color)
        {
            int s = 0;
            while ((-1 + text.Length - 1) != (s = text.Length - 1 + this.Find(text, s, -1, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord)))
            {
                this.SelectionColor = color;
            }
        }


    }
}
