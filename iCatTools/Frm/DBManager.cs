using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCatTools.Frm
{
    public partial class DBManager : Form
    {
        public DBManager()
        {
            InitializeComponent();
        }

        private void DBManager_Load(object sender, EventArgs e)
        {

        }

        public static void TopShow()
        {
            DBManager dbmanager = new DBManager();
            dbmanager.Show();
        } 
    }
}
