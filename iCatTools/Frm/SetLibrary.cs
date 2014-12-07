using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCatTools.common;

namespace iCatTools.Frm
{
    public partial class SetLibrary : Form
    {
        public SetLibrary()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            #region
            object commonLibACC = null;
            object commonLibBusi = null;
            object commonLibData = null;
            object currentLibAcc = null;
            object currentLibBusi = null;
            object currentLibData = null;
            if (!FormCheck.CheckValid(this.tbCommonLibACC, this.lbCommonLibACC, EnumCheck.IsEmpty, ref commonLibACC))
                return;
            if (!FormCheck.CheckValid(this.tbCommonLibBusi, this.lbCommonLibBusi, EnumCheck.IsEmpty, ref commonLibBusi))
                return;
            if (!FormCheck.CheckValid(this.tbCommonLibData, this.lbCommonLibData, EnumCheck.IsEmpty, ref commonLibData))
                return;
            if (!FormCheck.CheckValid(this.tbCurrentLibAcc, this.lbCurrentLibAcc, EnumCheck.IsEmpty, ref currentLibAcc))
                return;
            if (!FormCheck.CheckValid(this.tbCurrentLibBusi, this.lbCurrentLibBusi, EnumCheck.IsEmpty, ref currentLibBusi))
                return;
            if (!FormCheck.CheckValid(this.tbCurrentLibData, this.lbCurrentLibData, EnumCheck.IsEmpty, ref currentLibData))
                return;
            CurrBusiBase.CommonLibACC = Config.Update("CommonLibACC", commonLibACC.ToString());
            CurrBusiBase.CommonLibBusi = Config.Update("CommonLibBusi", commonLibBusi.ToString());
            CurrBusiBase.CommonLibData = Config.Update("CommonLibData", commonLibData.ToString());
            CurrBusiBase.CurrentLibAcc = Config.Update("CurrentLibAcc", currentLibAcc.ToString());
            CurrBusiBase.CurrentLibBusi = Config.Update("CurrentLibBusi", currentLibBusi.ToString());
            CurrBusiBase.CurrentLibData = Config.Update("CurrentLibData", currentLibData.ToString());
            MessageBase.Show("修改成功！");
            this.Close();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            #region
            this.Close();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetLibrary_Load(object sender, EventArgs e)
        {
            #region
            this.tbCommonLibACC.Text = CurrBusiBase.CommonLibACC;
            this.tbCommonLibBusi.Text = CurrBusiBase.CommonLibBusi;
            this.tbCommonLibData.Text = CurrBusiBase.CommonLibData;
            this.tbCurrentLibAcc.Text = CurrBusiBase.CurrentLibAcc;
            this.tbCurrentLibBusi.Text = CurrBusiBase.CurrentLibBusi;
            this.tbCurrentLibData.Text = CurrBusiBase.CurrentLibData;
            #endregion
        }
    }
}
