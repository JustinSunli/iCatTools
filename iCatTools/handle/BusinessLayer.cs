using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using GenBusiness;
using iCatTools.common;
using System.Threading;
using iCatTools.Frm;

namespace iCatTools.handle
{
    class BusinessLayer
    {
        private string _selPath = "";
        private DataSet _dsAllTableName = null;
        public delegate void dl_DoBatchSaveBusi(object ctrl, ControlView.UpdateRTBControl updateDl, object pb);
        public BusinessLayer(string selPath, DataSet dsAllTableName)
        {
            this._selPath = selPath;
            this._dsAllTableName = dsAllTableName;
        }
        public void BatchSave(object rtb, ControlView.UpdateRTBControl updateDl, object pb)
        {
            #region
            DataRow dr = null;
            TextBox lbl = (TextBox)rtb;
            //ToolStripProgressBar tspb = (ToolStripProgressBar)pb;
            BusiLayerBusiness busiLayerClass = new BusiLayerBusiness(MainForm._ConnectionString);
            busiLayerClass.Company = ApplicationBase.Company;
            busiLayerClass.UserName = ApplicationBase.KeyUser;

            int iPercent = 0;
            for (int i = 0; i < _dsAllTableName.Tables[0].Rows.Count; i++)
            {
                iPercent = (i+1)*100 / _dsAllTableName.Tables[0].Rows.Count;
                dr = _dsAllTableName.Tables[0].Rows[i];
                busiLayerClass.SetTableName(dr["name"].ToString());
                busiLayerClass.SaveBusiFile(_selPath, CurrBusiBase.CurrentLibData,
                    CurrBusiBase.CommonLibBusi, CurrBusiBase.CurrentLibAcc, CurrBusiBase.CurrentLibBusi);
                lbl.BeginInvoke(updateDl, new object[] { lbl, (i + 1).ToString() + "." + dr["name"].ToString() + "业务文件生成完毕！\r\n" , pb ,iPercent });
                Thread.Sleep(1);
            }
            #endregion
        }
        public void SaveCallback(IAsyncResult ar)
        {
            #region
            dl_DoBatchSaveBusi dl_do = (dl_DoBatchSaveBusi)ar.AsyncState;
            dl_do.EndInvoke(ar);
            MessageBase.Show("导出成功！");
            #endregion
        }
    }
}
