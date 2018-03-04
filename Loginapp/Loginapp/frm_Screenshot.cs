using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Loginapp
{
    public partial class frm_Screenshot : Form
    {
        Bitmap btmp;
        Graphics grph;
        public frm_Screenshot()
        {
            InitializeComponent();
        }

        private void btn_screensh_Click(object sender, EventArgs e)
        {
            screen_shot();
            save_scr();
            open_pic("test.jpg");
            
            
        }

        public void screen_shot()
        {
            
            
             btmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

             grph = Graphics.FromImage(btmp as Image);
             grph.CopyFromScreen(0, 0, 0, 0, btmp.Size);
             btn_web.SizeMode = PictureBoxSizeMode.StretchImage;
             btn_web.Image = btmp;             

        }

        public void save_scr()
        {
            btmp.Save("test.jpg");
        }

        public void open_pic(string picloc)
        {
            System.Diagnostics.Process.Start(picloc);

        }

        private void frm_Screenshot_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "the form is minimized";
                notifyIcon1.ShowBalloonTip(1000);
            }

            else if(this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.BalloonTipText = "back to normal";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com");
        }

        private void btn_age_Click(object sender, EventArgs e)
        {
            DateTime bday = new DateTime(1989, 06, 13);
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            MessageBox.Show(age.ToString());
        }
    }
}
