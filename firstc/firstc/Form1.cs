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

namespace firstc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string mycons = "SERVER=192.168.14.236;PORT=3306;DATABASE=ati;UID=Ati;PASSWORD=test";
                MySqlConnection myconn = new MySqlConnection();
                myconn.ConnectionString = mycons;
                myconn.Open();
                MessageBox.Show("connected");
                

            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            

            


        }
    }
}
