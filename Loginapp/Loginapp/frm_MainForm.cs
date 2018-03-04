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
using System.Text;
using System.IO;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using System.Diagnostics;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Loginapp
{
    public partial class frm_MainForm : Form
    {
        //Defining global variablse

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue); 

        string username;
        string password;
        public frm_MainForm()
        {
            
            InitializeComponent();
            
            try
            {
                Form_Methods.Fillcombo(comboBox1);
                Form_Methods.fill_listobox(listBox1);
                timer1.Start();
                AutoComplete_text();
                
                

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Form_Methods.close_db();
            }

        }

        public string gender;
        DataTable db;
        Button btn;
        String path1 = "D:\\root\\youtube";

        //Gracefully exit the application
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        //Add new entry to the database
        private void btn_Add_Click(object sender, EventArgs e)
        {
           
            string uname = textBox1.Text;
            string useu = textBox2.Text;
            string dat = dateTimePicker1.Text;

            //add the image, covert the image into bytes and add as blob in the sql database
            byte[] imageBt = null;
            FileStream fs = new FileStream(textBox8.Text, FileMode.Open, FileAccess.Read);
            BinaryReader b = new BinaryReader(fs);
            imageBt = b.ReadBytes((int)fs.Length);

            
            
            try
            {
                Form_Methods.addData(uname, useu, gender, dat, imageBt);
                MessageBox.Show("Added");
                textBox1.Text = "";
                textBox2.Text = "";



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Form_Methods.close_db();
            }

        }

        public string user
        {

            set { username = value; }
        }

        public string pass
        {

            set { password = value; }
        }

        public string setUserLabel
        {
            set { label9.Text = value; }
        }

       

        //Opens the form to update (alter the database)
        private void btn_update_Click(object sender, EventArgs e)
        {
           
            
            frm_Update f3 = new frm_Update();           
            f3.user = username;
            f3.pass = password;
            f3.ShowDialog();
        }

        //adds items form the textbox 2 into the combobox;
        //code obsolete, superseeded by Fillcombo() method to fill the combobox with values from the database
        private void btn_add_co_Click(object sender, EventArgs e)
        {
            
            string a = textBox2.Text;
            comboBox1.Items.Add(a);
        }

        //textBox1.Text = comboBox1.Text; - obsolete code
        //superseeded by code to get the details from the database when inde is changes
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                Form_Methods.getDataDb(comboBox1.Text, textBox1, textBox2, pictureBox1);
               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Form_Methods.close_db();
            }
        } 
             
               

        // see comments on comboBox1_SelectedIndexChanged
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                Form_Methods.getDataDb(listBox1.Text, textBox1, textBox2, pictureBox1);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

            finally
            {
                Form_Methods.close_db();
            }
        }

        //Loads the table from the database
        private void btn_load_db_Click(object sender, EventArgs e)
        {
           
            try
            {
                Form_Methods.load_table(dataGridView1);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Form_Methods.close_db();
            }

        }

       
        //adds the current date and time
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DateTime d = DateTime.Now;
            label3.Text = d.ToString();
        }


        private void btn_progress_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            
        }

        //at the closing of the main form the application asks if the user really wants to quit
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("really exit", "Exit", MessageBoxButtons.YesNo);
            if(dl == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //Adds ( Should add) the values from the column name and surname to the specified textbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
           // {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["name"].Value.ToString();
                textBox2.Text = row.Cells["suname"].Value.ToString();


           // }
        }

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton1.Text.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton2.Text.ToString();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog() == DialogResult.OK)
            {
                string s = op.FileName;
                MessageBox.Show(s);
            }
        }

        
        //Open txt file
        private void btn_open_txt_Click(object sender, EventArgs e)
        {
            Stream mystream;
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                if((mystream = op.OpenFile()) != null)
                {
                    string afile = op.FileName;
                    string filetext = File.ReadAllText(afile);
                    richTextBox1.Text = filetext;
                }
                string s = op.FileName;
                
            }
        }

        //Search the rich text box for entered keywords
        private void btn_search_txt_Click(object sender, EventArgs e)
        {
            Form_Methods.searchRichText(richTextBox1, textBox3);
            
        }

        //Write text file to disk
        private void btn_create_txt_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("test_file.txt");
                sw.Write("this is a test");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        //Create XLS file
        private void btn_create_excel_Click(object sender, EventArgs e)
        {
            Form_Methods.create_excel_file();
            
        }


        //Opens pdf file
        private void btn_open_pdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if(op.ShowDialog() == DialogResult.OK)
            {
                pdf1.src = op.FileName;
            }
        }

        //Opens the selected EXE file
        private void btn_open_exe_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                string pathf = op.FileName;
                Process.Start(pathf);
            }
        }


        //Plays 5 beeps
        private void btn_beep_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<6; i++)
            {
                Console.Beep();
            }
        }

        private void btn_select_audio_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = op.FileName;
            }
        }

        private void btn_play_audio_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = textBox4.Text;
                player.Load();
                player.PlaySync();
            }
            catch(Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //random number generator
        private void btn_rand_gen_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(textBox5.Text);
            int max = Convert.ToInt32(textBox6.Text);
            Random r = new Random();
            textBox7.Text = r.Next(min, max).ToString();
        }

        //Opens the Media Player form
        private void btn_media_player_Click(object sender, EventArgs e)
        {

            frm_MediaPlayer f4 = new frm_MediaPlayer();
            f4.Show();
        }

       
        //Select image and add to picturebox
        private void btn_select_img_Click(object sender, EventArgs e)
        {
            Form_Methods.addImgPicbox(textBox8, pictureBox1);

        }

        //Create pdfDocument using ITextSharp
        //adding lists to the document
        //adding the database table to the document ( table must be laoded first)
        private void btn_create_pdf_Click(object sender, EventArgs e)
        {

            Form_Methods.createPDFDocument(dataGridView1);
                      
        }


        private void btn_enc_Click(object sender, EventArgs e)
        {
            frm_Encryption f5 = new frm_Encryption();
            f5.Show();
        }

        
        private void btn_read_pdf_Click(object sender, EventArgs e)
        {
            Form_Methods.read_pd_file(richTextBox1);
         }

        //Clear rich text box
        private void btn_clear_pdf_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Text = "";
        }

        //Creates GUID
        private void btn_guid_Click(object sender, EventArgs e)
        {
            
            string NGuid = System.Guid.NewGuid().ToString();//.Replace("-", "").ToUpper(); - extra stuff            
            MessageBox.Show(NGuid);
        }

        //Open HTML editor
        private void btn_html_Click(object sender, EventArgs e)
        {
            frm_HTML fh = new frm_HTML();
            fh.Show();
        }

        //Search/filter the database in the datagridview
        private void txt_search_db_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(db);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", txt_search_db.Text);
            dataGridView1.DataSource = dv;
        }


        //NUmbers only textfield
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Open the Browser window
        private void btn_browser_Click(object sender, EventArgs e)
        {
            frm_Browser br = new frm_Browser();
            br.Show();
        }


        //Create new button method
        private void btn_create_btn_Click(object sender, EventArgs e)
        {
            Form_Methods.create_btn(btn);
            

        }

        

        private void btn_scrn_Click(object sender, EventArgs e)
        {
            frm_Screenshot scr = new frm_Screenshot();
            scr.Show();
        }

        private void btn_ip_Click(object sender, EventArgs e)
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString()== "InterNetwork")
                {
                    localIP = ip.ToString();
                    //MessageBox.Show(localIP);
                    listBox2.Items.Add(localIP);
                }
            }
        }

        private void btn_txt_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            if(svf.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(svf.FileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_notepad n = new frm_notepad();
            n.Show();
        }

        private void btn_nodes_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("test1");
            treeView1.Nodes.Add("test1");
            treeView1.Nodes.Add("test1");
            treeView1.Nodes.Add("test1");

            treeView1.Nodes[0].Nodes.Add("test2");
        }

        private void btn_remove_nod_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();

            //remove all nodes
            treeView1.Nodes.Clear();
        }

        private void btn_directory_Click(object sender, EventArgs e)
        {
            Form_Methods.ListDir(treeView1, path1);

        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            string TreeNodeName = treeView1.SelectedNode.ToString().Replace("TreeNode: ",String.Empty);
            System.Diagnostics.Process.Start(path1 + "\\" + TreeNodeName);
        }

        private void btn_change_font_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            if(fd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.SelectionFont = fd.Font;
                richTextBox1.SelectionColor = fd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex ex = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");
            if (!ex.IsMatch(txt_mail.Text))
            {
                MessageBox.Show("inavlid email format");
            }
            else
            {
                MessageBox.Show("valid e-mail format");
            }


        }

        private void btn_mdi_Click(object sender, EventArgs e)
        {
            frm_MDI mdi = new frm_MDI();
            mdi.Show();
        }

        public void AutoComplete_text()
        {
            txt_suggest_db.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_suggest_db.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            try
            {
                Form_Methods.fill_auto_suggestions(coll);


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txt_suggest_db.AutoCompleteCustomSource = coll;
        }

        private void btn_speech_Click(object sender, EventArgs e)
        {
            frm_Speech sp = new frm_Speech();
            sp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_getHTML sc = new frm_getHTML();
            sc.Show();
        }

        private void btn_net_Click(object sender, EventArgs e)
        {
            int desc;
            MessageBox.Show(InternetGetConnectedState(out desc,0).ToString());
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forgeroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                btn_add.ForeColor = dlg.Color;
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btn_add.BackColor = dlg.Color;
            }
        }
    }
}
