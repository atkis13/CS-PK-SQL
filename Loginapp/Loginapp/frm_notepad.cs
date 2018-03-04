using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Loginapp
{
    public partial class frm_notepad : Form
    {
        public frm_notepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document");
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
        }

        private RichTextBox getrtb()
        {
            RichTextBox rtb = new RichTextBox();
            TabPage tp = tabControl1.SelectedTab;
            if(tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }

            return rtb;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getrtb().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getrtb().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getrtb().Paste();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream mystream;
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = op.OpenFile()) != null)
                {
                    string afile = op.FileName;
                    string filetext = File.ReadAllText(afile);
                    getrtb().Text = filetext;
                }
                string s = op.FileName;

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            if (svf.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(svf.FileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(getrtb().Text);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = 0;
            string temp = getrtb().Text;
            getrtb().Text = "";
            getrtb().Text = temp;

            while (index < getrtb().Text.LastIndexOf(toolStripTextBox1.Text))
            {
                getrtb().Find(toolStripTextBox1.Text, index, getrtb().TextLength, RichTextBoxFinds.None);
                getrtb().SelectionBackColor = Color.Red;
                index = getrtb().Text.IndexOf(toolStripTextBox1.Text, index) + 1;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl1.SelectedTab;
            tabControl1.TabPages.Remove(tab);
        }
    }
}
