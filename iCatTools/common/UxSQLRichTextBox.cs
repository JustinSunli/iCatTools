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
    class UxSQLRichTextBox : RichTextBox
    {
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private static string keyliststring = @"ADD|EXCEPT|PERCENT|ALL|EXEC|PLAN|ALTER|EXECUTE|PRECISION|AND|EXISTS|PRIMARY|ANY|EXIT|PRINT|AS|FETCH|PROC|ASC|FILE|PROCEDURE|AUTHORIZATION|FILLFACTOR|PUBLIC|BACKUP|FOR|RAISERROR|BEGIN|FOREIGN|READ|BETWEEN|FREETEXT|READTEXT|BREAK|FREETEXTTABLE|RECONFIGURE|BROWSE|FROM|REFERENCES|BULK|FULL|REPLICATION|BY|FUNCTION|RESTORE|CASCADE|GOTO|RESTRICT|CASE|GRANT|RETURN|CHECK|GROUP|REVOKE|CHECKPOINT|HAVING|RIGHT|CLOSE|HOLDLOCK|ROLLBACK|CLUSTERED|IDENTITY|ROWCOUNT|COALESCE|IDENTITY_INSERT|ROWGUIDCOL|COLLATE|IDENTITYCOL|RULE|COLUMN|IF|SAVE|COMMIT|IN|SCHEMA|COMPUTE|INDEX|SELECT|CONSTRAINT|INNER|SESSION_USER|CONTAINS|INSERT|SET|CONTAINSTABLE|INTERSECT|SETUSER|CONTINUE|INTO|SHUTDOWN|CONVERT|IS|SOME|CREATE|JOIN|STATISTICS|CROSS|KEY|SYSTEM_USER|CURRENT|KILL|TABLE|CURRENT_DATE|LEFT|TEXTSIZE|CURRENT_TIME|LIKE|THEN|CURRENT_TIMESTAMP|LINENO|TO|CURRENT_USER|LOAD|TOP|CURSOR|NATIONAL|TRAN|DATABASE|NOCHECK|TRANSACTION|DBCC|NONCLUSTERED|TRIGGER|DEALLOCATE|NOT|TRUNCATE|DECLARE|NULL|TSEQUAL|DEFAULT|NULLIF|UNION|DELETE|OF|UNIQUE|DENY|OFF|UPDATE|DESC|OFFSETS|UPDATETEXT|DISK|ON|USE|DISTINCT|OPEN|USER|DISTRIBUTED|OPENDATASOURCE|VALUES|DOUBLE|OPENQUERY|VARYING|DROP|OPENROWSET|VIEW|DUMMY|OPENXML|WAITFOR|DUMP|OPTION|WHEN|ELSE|OR|WHERE|END|ORDER|WHILE|ERRLVL|OUTER|WITH|ESCAPE|OVER|WRITETEXT";
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
        private void ChangeColor(string text, Color color)
        {
            int s = 0;
            while ((-1 + text.Length - 1) != (s = text.Length - 1 + this.Find(text, s, -1, RichTextBoxFinds.WholeWord)))
            {
                this.SelectionColor = color;
            }
        }
    }
}
