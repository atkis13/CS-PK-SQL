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

namespace Loginapp
{
    public partial class frm_Update : Form
    {
        MySqlConnection myconn;
        string username;
        string password;
        public frm_Update()
        {
            InitializeComponent();
        }

        public string user
        {

            set { username = value; }
        }

        public string pass
        {

            set { password = value; }
        }

        public void updateData(int id, string us, string su)
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=" + username + ";PASSWORD=" + password;
            string query = "update table_ati set name=@n, suname=@s  Where ID = @id;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            cmd.Parameters.AddWithValue("@n", us);
            cmd.Parameters.AddWithValue("@s", su);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id1 = int.Parse(txt_id.Text);
            string name = txt_name.Text;
            string surname = txt_surname.Text;
            try
            {
                updateData(id1, name, surname);
                MessageBox.Show("updated");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myconn.Close();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id1 = int.Parse(txt_id.Text);
           
            try
            {
                deleteData(id1);
                MessageBox.Show("deleted");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myconn.Close();
            }

        }

        public void deleteData(int id)
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=" + username + ";PASSWORD=" + password;
            string query = "delete from table_ati where ID = @id;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);            
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
