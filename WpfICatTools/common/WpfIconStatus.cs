using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace WpfICatTools.common
{
    class WpfIconStatus
    {
        private NotifyIcon _nIconSystem = null;
        private Window _mainFrm = null;
        public WindowState _LastFrmState = WindowState.Maximized;
        public WpfIconStatus(Window mainFrm)
        {
            this._nIconSystem = new NotifyIcon();
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
            if (this._mainFrm.IsVisible == true)
            {
                _LastFrmState = this._mainFrm.WindowState;
                this._mainFrm.Hide();
            }
            else
            {
                this._mainFrm.Show();

                this._mainFrm.WindowState = _LastFrmState;
                this._mainFrm.Activate();
            }
            #endregion
        }
        /// <summary>
        /// 窗口大小变更时记录窗口状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            #region
            //try
            //{
                if (_mainFrm.WindowState == WindowState.Minimized)
                    _mainFrm.Hide();
                else
                    _LastFrmState = _mainFrm.WindowState;
            //}
            //catch (Exception ex)
            //{
            //    Log.Write(ex.ToString());
            //}
            #endregion
        }
        /// <summary>
        /// 主窗体在加入状态栏图标功能后绑定的窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, CancelEventArgs e)
        {
            #region
            e.Cancel = true;
            _LastFrmState = _mainFrm.WindowState;
            
            _mainFrm.WindowState = WindowState.Minimized;
            #endregion
        }

        private void MainForm_StateChange(object sender, EventArgs e)
        {
            #region
            if (_mainFrm.WindowState == WindowState.Minimized)
                _mainFrm.Hide();
            #endregion
        }
        /// <summary>
        /// 配置右下角图标
        /// </summary>
        public void SetIcon()
        {
            #region
            _mainFrm.SizeChanged += new SizeChangedEventHandler(this.MainForm_SizeChanged);
            _mainFrm.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_FormClosing);
            _mainFrm.StateChanged += new EventHandler(this.MainForm_StateChange);
            //设置右下角托盘图标
            //获取资源文件，如若系统中调用资源较多，则需封装此函数
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Stream manifestResourceStream = null;
            manifestResourceStream = asm.GetManifestResourceStream("WpfICatTools.newicon.ico");

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
