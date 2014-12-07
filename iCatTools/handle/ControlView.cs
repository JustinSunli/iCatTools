using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatTools.handle
{
    class ControlView
    {
        /// <summary>
        /// 定义更新控制台的代理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="value"></param>
        public delegate void UpdateRTBControl(object ctrl, object value, object pbCtrl, object pbValue);
        /// <summary>
        /// 定义更新进度条的代理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="value"></param>
        public delegate void UpdatePBControl(object ctrl, object value);
        /// <summary>
        /// 实体更新空间的方法
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="value"></param>
        public void UpdateRTB_Method(object ctrl, object value, object pbCtrl, object pbValue)
        {
            #region
            int iPbValue = Int16.Parse(pbValue.ToString());
            TextBox lbl = (TextBox)ctrl;
            lbl.AppendText(value.ToString());
            ToolStripProgressBar pb = (ToolStripProgressBar)pbCtrl;
            pb.Value = iPbValue;
            if(iPbValue == 100)
                pb.Visible = false;
            #endregion
        }
        /// <summary>
        /// 实体进度条的方法
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="value"></param>
        public void UpdatePB_Method(object ctrl, object value)
        {
            #region
            ToolStripProgressBar lbl = (ToolStripProgressBar)ctrl;
            lbl.Value = Int16.Parse(value.ToString());
            #endregion
        }

    }
}
