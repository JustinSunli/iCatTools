using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace GenAutoUpdate.common
{
    class IconStatus
    {
        private NotifyIcon _nIconSystem = null;
        private Form _mainFrm = null;
        public IconStatus(NotifyIcon nIconSystem, Form mainFrm)
        {
            this._nIconSystem = nIconSystem;
            this._mainFrm = mainFrm;
        }
        /// <summary>
        /// 托盘弹出菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nIconMenuItem_Click(object sender, System.EventArgs e)
        {
            #region
            //终结线程，以防UI销毁后线程调用UI
            /*
            if (thdViewResponse != null)
                thdViewResponse.Abort();
            if (thdStartListen != null)
                thdStartListen.Abort();
            */
            this._nIconSystem.Visible = false;

            System.Environment.Exit(0);
            #endregion
        }
        /// <summary>
        /// 双击托盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nIconSystem_DoubleClick(object sender, System.EventArgs e)
        {
            #region
            if (this._mainFrm.Visible == true)
            {
                this._mainFrm.Hide();
            }
            else
            {
                this._mainFrm.Show();
                this._mainFrm.WindowState = FormWindowState.Normal;
                this._mainFrm.Activate();
            }
            #endregion
        }
        /// <summary>
        /// 配置右下角图标
        /// </summary>
        public void SetIcon()
        {
            #region
            //设置右下角托盘图标
            //获取资源文件，如若系统中调用资源较多，则需封装此函数
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Stream manifestResourceStream = null;
            manifestResourceStream = asm.GetManifestResourceStream("GenerateCode.16Status.ico");

            Icon m_IconSystem = new Icon(manifestResourceStream);
            this._nIconSystem.Icon = m_IconSystem;
            this._nIconSystem.Visible = true;
            this._nIconSystem.Text = ApplicationBase.ApplicationName;

            //设置托盘菜单事件
            MenuItem nIconMenuItem = new MenuItem("退出本软件");
            nIconMenuItem.Click += new EventHandler(this.nIconMenuItem_Click);

            this._nIconSystem.ContextMenu = new ContextMenu(new MenuItem[] { nIconMenuItem });
            this._nIconSystem.DoubleClick += new EventHandler(this.nIconSystem_DoubleClick);
            #endregion
        }
    }
}
