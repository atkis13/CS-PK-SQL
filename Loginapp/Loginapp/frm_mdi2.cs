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
    public partial class frm_mdi2 : Form
    {
        public frm_mdi2()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string street = txt_city.Text;
            string city = txt_street.Text;


            try
            {
                StringBuilder queryadress = new StringBuilder();
                queryadress.Append("http://maps.google.com/maps?q=");
                if (street != String.Empty)
                {
                    queryadress.Append(street + "," + "+");
                }
                if (city != String.Empty)
                {
                    queryadress.Append(city + "," + "+");
                }

                webBrowser1.Navigate(queryadress.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
