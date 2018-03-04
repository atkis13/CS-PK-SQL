using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Loginapp
{
    public partial class frm_getHTML : Form
    {

        WebClient wc = new WebClient();
        public frm_getHTML()
        {
            InitializeComponent();
        }

        private void bt_get_source_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imgurl = new Uri(txt_download.Text);
            wc.DownloadFileAsync(imgurl, "myimagedwl.png");

        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Downlaod Completed");
        }

        private void btn_opendir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath);

                foreach (string file in files)
                {
                    listBox1.Items.Add(file);//Path.GetFileName(file); - to get the names only
                }

                foreach (string dir in dirs)
                {
                    listBox1.Items.Add(dir);
                }


            }
        }

        private void btn_covert_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\Aty\Desktop\convertImage.jpg");
            img.Save(@"C:\Users\Aty\Desktop\convertedImage.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
