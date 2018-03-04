using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginapp
{
    public partial class frm_MediaPlayer : Form
    {
        public frm_MediaPlayer()
        {
            InitializeComponent();
        }

        string[] files, paths;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player1.URL = textBox1.Text;
            player1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player1.Ctlcontrols.stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                files = op.SafeFileNames;
                paths = op.FileNames;
                for(int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            player1.URL = paths[listBox1.SelectedIndex];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player1.Ctlcontrols.pause();
        }
    }
}
