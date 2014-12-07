using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using iCatTools.Frm;
using GenBusiness;
using System.Threading;

namespace iCatTools.handle
{
    class SqlGen
    {
        private DataSet _dsAllTableName = null;
        public SqlGen(DataSet dsAllTableName)
        {
            this._dsAllTableName = dsAllTableName;
        }
        public void GetAllTableRowCount(object ctrl, ControlView.UpdateRTBControl updateDl, object pb)
        {
            DataRow dr = null;
            TextBox lbl = (TextBox)ctrl;
            ToolStripProgressBar tspb = (ToolStripProgressBar)pb;
            SqlGenBusiness sqlgenclass = new SqlGenBusiness(MainForm._ConnectionString);
            int iPercent = 0;
            for (int i = 0; i < _dsAllTableName.Tables[0].Rows.Count; i++)
            {
                iPercent = (i + 1) * 100 / _dsAllTableName.Tables[0].Rows.Count;
                dr = _dsAllTableName.Tables[0].Rows[i];
                lbl.BeginInvoke(updateDl, new object[] { lbl, (i + 1).ToString() + "." + sqlgenclass.GetTableRowCount(dr["name"].ToString()), pb, iPercent });
                Thread.Sleep(1);
            }
        }
    }
}
