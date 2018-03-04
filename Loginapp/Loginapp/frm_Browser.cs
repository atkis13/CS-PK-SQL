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
    public partial class frm_Browser : Form
    {
        public frm_Browser()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txt_url.Text);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                prg_progress.Value = Convert.ToInt32(e.CurrentProgress);
                prg_progress.Maximum = Convert.ToInt32(e.MaximumProgress);
                            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void showHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C\\User\\help.chm");
        }
    }
}
