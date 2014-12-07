using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenBusiness;
using iCatTools.common;

namespace iCatTools.Frm
{
    public partial class GenTableImage : Form
    {
        private Bitmap tableStructureBmp = null;
        public string TableName = "";
        public GenTableImage()
        {
            InitializeComponent();
        }

        private void GenTableImage_Load(object sender, EventArgs e)
        {
            this.Text = "表名：" + this.TableName;
            TableBmp tablebmp = new TableBmp(MainForm._ConnectionString);
            tablebmp.SetTableName(this.TableName);
            Size frmsize = tablebmp.GetSize();
            this.Size = new Size(frmsize.Width + 10, frmsize.Height);
            tableStructureBmp = tablebmp.GetSingle();
            this.picbTableBmpContainer.Image = tableStructureBmp;
            //MessageBase.Show(this.Size.Width.ToString());
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + this.TableName;
            sfd.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
                tableStructureBmp.Save(sfd.FileName);

        }
    }
}
