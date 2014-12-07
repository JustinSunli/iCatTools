using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCatTools.common;
using SnKeyGen;

namespace iCatTools.Frm
{
    public partial class GenKey : Form
    {
        public GenKey()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            object username = null;
            string dtStart = this.dtpStartTime.Value.ToString("yyyy-MM-dd");
            string dtEnd = this.dtpEndTime.Value.ToString("yyyy-MM-dd");
            if(!FormCheck.CheckValid(this.tbUsername, this.lbUsername, EnumCheck.IsEmpty, ref username))
                return;
            string src = string.Format("{0};{1};{2}", username, dtStart, dtEnd);

            this.tbKey.Text = Encrypt.EncryptString(src);
        }
    }
}
