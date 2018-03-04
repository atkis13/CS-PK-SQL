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
    public partial class frm_MDI : Form
    {
        public frm_MDI()
        {
            InitializeComponent();
        }

        frm_mdi1 md1;

        private void mDI1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(md1 == null)
            {
                md1 = new frm_mdi1();
                md1.MdiParent = this;
                md1.FormClosed += new FormClosedEventHandler(md1_closed);
                md1.Show();
            }
            else
            {
                md1.Activate();
            }
        }

        public void md1_closed(object sender, FormClosedEventArgs e)
        {
            md1 = null;
        }

        private void mDI2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_mdi2 md2 = new frm_mdi2();
            md2.MdiParent = this;
            md2.Show();
        }
    }
}
