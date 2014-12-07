using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using GenBusiness;
using iCatTools.Frm;
using System.Drawing;
using System.Threading;
using iCatTools.common;
using System.IO;

namespace iCatTools.handle
{
    class DBImage
    {
        private string _selPath = "";
        private DataSet _dsAllTableName = null;
        public delegate void dl_DoBatchSaveAcc(object ctrl, ControlView.UpdateRTBControl updateDl, object pb);
        public DBImage(string selPath, DataSet dsAllTableName)
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

            //this.picbTableBmpContainer.Image = tableStructureBmp;
            TableBmp tablebmp = new TableBmp(MainForm._ConnectionString);

            int iPercent = 0;
            string filepath = "";
            string savedir = this._selPath + "\\" + MainForm._DatabaseName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (!Directory.Exists(savedir))
                Directory.CreateDirectory(savedir);

            for (int i = 0; i < _dsAllTableName.Tables[0].Rows.Count; i++)
            {
                iPercent = (i + 1) * 100 / _dsAllTableName.Tables[0].Rows.Count;
                dr = _dsAllTableName.Tables[0].Rows[i];

                tablebmp.SetTableName(dr["name"].ToString());
                tablebmp.GetSize();
                Bitmap tableStructureBmp = tablebmp.GetSingle();
                filepath = savedir + "\\" + tablebmp.GetTablename() + ".jpg";
                tableStructureBmp.Save(filepath);
                lbl.BeginInvoke(updateDl, new object[] { lbl, (i + 1).ToString() + "." + dr["name"].ToString() + "表结构图像生成完毕！\r\n", pb, iPercent });
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