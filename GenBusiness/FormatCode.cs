using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBusiness
{
    class FormatCode
    {
        public static string AddTab(StringBuilder strBuilder, int tabCount)
        {
            string strCode = "";
            string tabStr = "";
            for (int i = 0; i < tabCount; i++)
                tabStr += "\t";
            string[] strRows = strBuilder.ToString().Split('\n');
            for (int i = 0; i < strRows.Length; i++)
            {
                if (i != strRows.Length - 1)
                    strCode += tabStr + strRows[i];
                else
                    strCode += "\r\n";
            }
            return strCode;
        }
    }
}
