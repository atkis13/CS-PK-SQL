using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Loginapp
{
    public partial class frm_LoginForm : Form
    {
        DBConnection conn;
        public frm_LoginForm()
        {
            Thread t = new Thread(new ThreadStart(splash_screen));
            t.Start();
            InitializeComponent();
            Thread.Sleep(5000);
            t.Abort();

           
        }

        public void btn_login_Click(object sender, EventArgs e)
        {
            string user = txt_user.Text;
            string pass = txt_pass.Text;
            
            try
            {
                conn = new DBConnection();
                if(user == conn.Username && pass == conn.Password)
                {
                    conn.Open();
                    MessageBox.Show("Connected");
                    this.Hide();
                    frm_MainForm f = new frm_MainForm();
                    f.user = user;
                    f.setUserLabel = user;
                    
                    f.ShowDialog();

                }
                


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        public void splash_screen()
        {
            Application.Run(new frm_splash_screen());
        }

        
    }
}
