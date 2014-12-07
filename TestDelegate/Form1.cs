using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int m_t = 0;

        public delegate void DLTest();
        public void testdelegate()
        {
            m_t = 2;
            Thread.Sleep(5000);
        }

        public delegate void DLSetValue();
        public void setValue()
        {
            this.textBox1.Text = m_t.ToString();
        }

        public void callback(IAsyncResult ar)
        {
            DLTest dl_do = (DLTest)ar.AsyncState;
            dl_do.EndInvoke(ar);

            this.BeginInvoke(new DLSetValue(this.setValue));
            //this.textBox1.Text = m_t.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DLTest dltest = new DLTest(this.testdelegate);
            AsyncCallback clbk = new AsyncCallback(this.callback);
            dltest.BeginInvoke(clbk, dltest);
        }
    }
}
