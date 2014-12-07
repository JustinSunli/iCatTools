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
using iCatTools.business;

namespace iCatTools.Frm
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private bool _isFirstLoad = true;
        /// <summary>
        /// 注册本软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            #region
            object username = null;
            object key = null;
            DateTime dtStart, dtEnd;

            if (!FormCheck.CheckValid(this.tbRegUsername, this.lbUsername, EnumCheck.IsEmpty, ref username))
                return;
            if (!FormCheck.CheckValid(this.tbPwd, this.lbPwd, EnumCheck.IsEmpty, ref key))
                return;

            try
            {
                string[] strArr = Encrypt.DecryptString(key.ToString()).Split(';');
                if (strArr[0] != username.ToString())
                {
                    MessageBase.Show("用户名和密钥不匹配，请支持正版！");
                    return;
                }
                if (strArr[1] != HardDisk.GetSerialNumber())
                {
                    MessageBase.Show("密钥非法使用，请支持正版！");
                    return;
                }
                dtStart = Convert.ToDateTime(strArr[2]);
                dtEnd = Convert.ToDateTime(strArr[3]);
                if (dtStart <= DateTime.Now && dtEnd >= DateTime.Now)
                {
                    MessageBase.Show("注册成功！\r\n有效期从" + dtStart.ToString("yyyy-MM-dd") + "到" + dtEnd.ToString("yyyy-MM-dd"));
                    //成功后写CONFIG
                    if (!ApplicationBase.IsReg)
                    {
                        ApplicationBase.KeyUser = Config.Save("KeyUser", strArr[0]);
                        ApplicationBase.AppKey = Config.Save("AppKey", key.ToString());
                    }
                    else
                    {
                        ApplicationBase.KeyUser = Config.Update("KeyUser", strArr[0]);
                        ApplicationBase.AppKey = Config.Update("AppKey", key.ToString());
                    }
                    ApplicationBase.IsReg = Config.Update("IsReg", "true") == "true" ? true : false;
                    ApplicationBase.RegMaxDate = dtEnd.ToString("yyyy-MM-dd");
                    this.Close();
                }
                else
                {
                    MessageBase.Show("密钥过期，请重新申请！");
                    return;
                }
            }
            catch
            {
                MessageBase.Show("注册失败！");
                return;
            }
            #endregion
        }
        /// <summary>
        /// 注册框加载（此界面用于注册和显示）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Load(object sender, EventArgs e)
        {
            #region
            if (!ApplicationBase.IsReg)
            {
                this.lbRegLimit.Visible = false;
                this.btnReg.Visible = true;
                this.btnClose.Visible = false;
                this.ControlBox = false;
                this.btnExit.Visible = true;
                this.btnReg.Enabled = true;
                this.btnNotRegister.Enabled = true;
            }
            else
            {
                this.ControlBox = true;
                this.lbRegLimit.Visible = true;
                this.btnClose.Visible = true;
                this.btnExit.Visible = false;
                this.lbRegLimit.Text = "有效期限至" + ApplicationBase.RegMaxDate;
                this.tbRegUsername.Text = ApplicationBase.KeyUser;
                this.tbPwd.Text = ApplicationBase.AppKey;
                this._isFirstLoad = false;
            }
            #endregion
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 禁止Alt+f4
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region
            switch (keyData)
            {
                case Keys.F4 | Keys.Alt:
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
            #endregion
        }
        /// <summary>
        /// 退出本软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            #region
            //this.nIconSystem.Visible = false;
            System.Environment.Exit(0);
            #endregion
        }
        /// <summary>
        /// 注册信息变更后启动注册按钮可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRegUsername_TextChanged(object sender, EventArgs e)
        {
            #region
            if (ApplicationBase.IsReg && !this._isFirstLoad)
            {
                string username = "";
                string key = "";

                username = this.tbRegUsername.Text.Trim();
                key = this.tbPwd.Text.Trim();
                if (username != ApplicationBase.KeyUser || key != ApplicationBase.AppKey)
                    this.btnReg.Enabled = true;
            }
            #endregion
        }

        private void btnNotRegister_Click(object sender, EventArgs e)
        {
            NotRegister noregister = new NotRegister();
            noregister.ShowDialog();
        }
    }
}
