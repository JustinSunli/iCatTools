using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using iCatTools.Frm;
using GenBusiness;
using iCatTools.common;
using System.Threading;

namespace iCatTools.handle
{
    class AccessLayer
    {
        private string _selPath = "";
        private DataSet _dsAllTableName = null;
        public delegate void dl_DoBatchSaveAcc(object ctrl, ControlView.UpdateRTBControl updateDl, object pb);
        public AccessLayer(string selPath, DataSet dsAllTableName)
        {
            this._selPath = selPath;
            this._dsAllTableName = dsAllTableName;
        }
        public void BatchSave(object ctrl, ControlView.UpdateRTBControl updateDl, object pb)
        {
            #region
            DataRow dr = null;
            TextBox lbl = (TextBox)ctrl;
            ToolStripProgressBar tspb = (ToolStripProgressBar)pb;
            AccessLayerBusiness accLayerClass = new AccessLayerBusiness(MainForm._ConnectionString);
            accLayerClass.Company = ApplicationBase.Company;
            accLayerClass.UserName = ApplicationBase.KeyUser;

            int iPercent = 0;
            for (int i = 0; i < _dsAllTableName.Tables[0].Rows.Count; i++)
            {
                iPercent = (i + 1) * 100 / _dsAllTableName.Tables[0].Rows.Count;
                dr = _dsAllTableName.Tables[0].Rows[i];
                accLayerClass.SetTableName(dr["name"].ToString());
                accLayerClass.SaveAccessFile(_selPath,CurrBusiBase.CurrentLibAcc, CurrBusiBase.CurrentLibData,
                    CurrBusiBase.CommonLibACC, CurrBusiBase.CommonLibBusi);
                lbl.BeginInvoke(updateDl, new object[] { lbl, (i + 1).ToString() + "." + dr["name"].ToString() + "数据访问层文件生成完毕！\r\n", pb, iPercent });
                Thread.Sleep(1);
            }
            #endregion
        }
        public void SaveCallback(IAsyncResult ar)
        {
            #region
            dl_DoBatchSaveAcc dl_do = (dl_DoBatchSaveAcc)ar.AsyncState;
            dl_do.EndInvoke(ar);
            MessageBase.Show("导出成功！");
            #endregion
        }
    }
}
