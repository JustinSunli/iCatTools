using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace iCatTools.Frm
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Stream manifestResourceStream = null;
            manifestResourceStream = asm.GetManifestResourceStream("iCatTools.doc.about.txt");


            this.label2.Text = "当前版本：V"+Assembly.GetEntryAssembly().GetName().Version.ToString();
            //this.richTextBox1.Text = "如需学习讨论，请联系QQ：330669393";
            StreamReader SReader = new StreamReader(manifestResourceStream, Encoding.UTF8);
            this.richTextBox1.Text = SReader.ReadToEnd();
        }
    }
}