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

namespace ThreadTest
{
    public partial class Form1 : Form
    {
        Thread thdPerSendCommand = null;
        private delegate void AssignControl(object ctrl, Bitmap img);
        private static AssignControl _assignImage = new AssignControl(AssignImage);

        private static void AssignImage(object picCtrl, Bitmap img)
        {
            #region
            PictureBox pic = (PictureBox)picCtrl;
            pic.Image = img;
            #endregion
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.thdPerSendCommand = new Thread(new ThreadStart(StatusMonitor));
            this.thdPerSendCommand.IsBackground = true;
            this.thdPerSendCommand.Start();
        }

        private void StatusMonitor()
        {
            #region
            Bitmap stopBmp = ThreadTest.Properties.Resources.stop;
            Bitmap goBmp = ThreadTest.Properties.Resources.go;
            Random ran = new Random();
            while (true)
            {
                try
                {
                    int intran = ran.Next(10) % 2;
                    this.pictureBox1.Image = (intran == 1) ? stopBmp : goBmp;
                    //this.BeginInvoke(_assignImage, new object[2] { this.pictureBox1, (intran == 1) ? stopBmp : goBmp });
                    intran = ran.Next(10) % 2;
                    this.pictureBox2.Image = (intran == 1) ? stopBmp : goBmp;
                    //this.BeginInvoke(_assignImage, new object[2] { this.pictureBox2, (intran == 1) ? stopBmp : goBmp });
                    intran = ran.Next(10) % 2;
                    this.pictureBox3.Image = (intran == 1) ? stopBmp : goBmp;
                    //this.BeginInvoke(_assignImage, new object[2] { this.pictureBox3, (intran == 1) ? stopBmp : goBmp });
                    intran = ran.Next(10) % 2;
                    this.pictureBox4.Image = (intran == 1) ? stopBmp : goBmp;
                    //this.BeginInvoke(_assignImage, new object[2] { this.pictureBox4, (intran == 1) ? stopBmp : goBmp });
                    intran = ran.Next(10) % 2;
                    this.pictureBox5.Image = (intran == 1) ? stopBmp : goBmp;
                    //this.BeginInvoke(_assignImage, new object[2] { this.pictureBox5, (intran == 1) ? stopBmp : goBmp });
                }
                catch (Exception e)
                {
                    //throw;
                }
                Thread.Sleep(10);
            }
            #endregion
        }
    }
}
