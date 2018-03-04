using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web;

namespace Loginapp
{
    public partial class frm_Mail : Form
    {
        public frm_Mail()
        {
            InitializeComponent();

            pass.PasswordChar = '*';
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, richTextBox1.Text);
            SmtpClient client = new SmtpClient(smtp.Text);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(user.Text, pass.Text);
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
