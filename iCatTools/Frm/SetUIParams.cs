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
    public partial class SetUIParams : Form
    {
        public Boolean Finished = false;

        public SetUIParams()
        {
            InitializeComponent();
        }

        private void btniCatTools_Click(object sender, EventArgs e)
        {
            #region
            object Namespace = null;
            object Startrecord = null;
            object NewEditTitle = null;
            object QueryTitle = null;
            object HandlerName = null;
            object DeleteInformation = null;
            if (!FormCheck.CheckValid(this.tbUINamespace, this.lbNamespace, EnumCheck.IsEmpty, ref Namespace))
                return;
            if (!FormCheck.CheckValid(this.tbHandlerName, this.lbHandlerName, EnumCheck.IsEmpty, ref HandlerName))
                return;
            if (!FormCheck.CheckValid(this.tbStartrecord, this.lbStartrecord, EnumCheck.IsEmpty, ref Startrecord))
                return;
            if (!FormCheck.CheckValid(this.tbDeleteInformation, this.lbDeleteInformation, EnumCheck.IsEmpty, ref DeleteInformation))
                return;
            if (!FormCheck.CheckValid(this.tbNewEditTitle, this.lbNewEditTitle, EnumCheck.IsEmpty, ref NewEditTitle))
                return;
            if (!FormCheck.CheckValid(this.tbQueryTitle, this.lbQueryTitle, EnumCheck.IsEmpty, ref QueryTitle))
                return;
            ApplicationBase.UINamespace = Config.Update("UINamespace", Namespace.ToString());
            ApplicationBase.UIHandlerName = Config.Update("UIHandlerName", HandlerName.ToString());
            ApplicationBase.UIStartrecord = Config.Update("UIStartrecord", Startrecord.ToString());
            ApplicationBase.UINewEditTitle = Config.Update("UINewEditTitle", NewEditTitle.ToString());
            ApplicationBase.UIQueryTitle = Config.Update("UIQueryTitle", QueryTitle.ToString());
            ApplicationBase.UIDeleteInformation = Config.Update("UIDeleteInformation", DeleteInformation.ToString());
            ApplicationBase.UIPerpageRecord = Config.Update("UIPerpageRecord", (this.cbPerpageRecord.SelectedItem == null) ? "15" : this.cbPerpageRecord.SelectedItem.ToString());
            ApplicationBase.UIIsQuery = Boolean.Parse(Config.Update("UIIsQuery", this.cbQuery.Checked.ToString()));
            ApplicationBase.UIIsNewEdit = Boolean.Parse(Config.Update("UIIsNewEdit", this.cbNewEdit.Checked.ToString()));
            ApplicationBase.UIIsDelete = Boolean.Parse(Config.Update("UIIsDelete", this.cbDelete.Checked.ToString()));
            this.Close();
            this.Finished = true;
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            #region
            this.Close();
            #endregion
        }

        private void SetUIParams_Load(object sender, EventArgs e)
        {
            this.Finished = false;
            this.tbUINamespace.Text = ApplicationBase.UINamespace;
            this.tbStartrecord.Text = ApplicationBase.UIStartrecord;
            this.tbQueryTitle.Text = ApplicationBase.UIQueryTitle;
            this.tbNewEditTitle.Text = ApplicationBase.UINewEditTitle;
            this.tbHandlerName.Text = ApplicationBase.UIHandlerName;
            this.tbDeleteInformation.Text = ApplicationBase.UIDeleteInformation;

            this.cbPerpageRecord.SelectedItem = ApplicationBase.UIPerpageRecord;
            this.cbQuery.Checked = ApplicationBase.UIIsQuery;
            this.cbNewEdit.Checked = ApplicationBase.UIIsNewEdit;
            this.cbDelete.Checked = ApplicationBase.UIIsDelete;
        }
    }
}
