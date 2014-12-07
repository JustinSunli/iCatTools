using iCatTools.business;
using iCatTools.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatTools.Frm
{
    public partial class NotRegister : Form
    {
        public NotRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotRegister_Load(object sender, EventArgs e)
        {
            #region
            this.tbDiskID.Text = HardDisk.GetSerialNumber();
            #endregion

        }

        private void btnCopyIDToClipBorad_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.tbDiskID.Text.Trim());
            MessageBase.Show("已经复制到剪贴板！");
        }
    }
}
