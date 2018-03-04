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
    public partial class frm_mdi1 : Form
    {
        public frm_mdi1()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Clear();
            for(int i = listBox1.Items.Count-1; i>=0; i--)
            {
                if (listBox1.Items[i].ToString().ToLower().Contains(txt_search.Text.ToLower()))
                {
                    listBox1.SetSelected(i, true);
                }
            }

            label1.Text = listBox1.SelectedItems.Count.ToString() + " items found";
        }
    }
}
