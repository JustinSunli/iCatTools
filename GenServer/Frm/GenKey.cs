using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenServer.common;
using SnKeyGen;

namespace GenServer.Frm
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
            object harddiskid = null;
            string dtStart = this.dtpStartTime.Value.ToString("yyyy-MM-dd");
            string dtEnd = this.dtpEndTime.Value.ToString("yyyy-MM-dd");
            if(!FormCheck.CheckValid(this.tbUsername, this.lbUsername, EnumCheck.IsEmpty, ref username))
                return;
            if (!FormCheck.CheckValid(this.tbHardDiskID, this.lbMachineID, EnumCheck.IsEmpty, ref harddiskid))
                return;

            object[] argument = new object[4];
            argument[0] = username;
            argument[1] = harddiskid;
            argument[2] = dtStart;
            argument[3] = dtEnd;

            string src = string.Format("{0};{1};{2};{3}", argument);

            this.tbKey.Text = Encrypt.EncryptString(src);
        }
    }
}
