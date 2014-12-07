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
    public partial class CodeEditor : Form
    {
        public CodeEditor()
        {
            
            InitializeComponent();
        }

        private void CodeEditor_Load(object sender, EventArgs e)
        {
            //TextEditor textEditorControl1 = new TextEditor();
            //TextEditorOptions textoptions = new TextEditorOptions();
            
            //UIElementCollection
            //textEditorControl1.Options = textoptions;
            /*
            textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditorControl1.IsReadOnly = false;
            textEditorControl1.Location = new System.Drawing.Point(0, 0);
            textEditorControl1.Name = "textEditorControl1";
            textEditorControl1.Size = new System.Drawing.Size(628, 471);
            textEditorControl1.TabIndex = 0;
            textEditorControl1.Text = "textEditorControl1";
            */

            //this.Controls.Add(textEditorControl1);
            //textEditorControl1.SetHighlighting("C#");
            //textEditorControl1.Font = new Font("menlo", 8);
        }

        public static void CodeEditorShow()
        {
            CodeEditor codeeditor = new CodeEditor();
            codeeditor.Show();
        }
    }
}
