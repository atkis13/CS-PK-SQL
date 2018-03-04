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
namespace Loginapp
{
    public partial class Form2 : Form
    {
        MySqlConnection myconn;
        string username;
        string password;
        public Form2()
        {
            InitializeComponent();
            try
            {
                Fillcombo();
                fill_listobox();
                timer1.Start();

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

        public string gender;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string useu = textBox2.Text;
            string dat = dateTimePicker1.Text;

            //add the image, covert tha image into bytes and add as blob in the sql database
            byte[] imageBt = null;
            FileStream fs = new FileStream(textBox8.Text, FileMode.Open, FileAccess.Read);
            BinaryReader b = new BinaryReader(fs);
            imageBt = b.ReadBytes((int)fs.Length);

            
            
            try
            {
                addData(uname, useu, gender, dat, imageBt);
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
                myconn.Close();
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

        public void addData( string us, string su, string ge, string date, byte[] img)
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=" + username + ";PASSWORD=" + password; //to be moved in connection.cs
            string query = "INSERT INTO table_ati(name, suname, gender,dob, Image) VALUES(@n, @s, @g, @d, @i);";
            myconn = new MySqlConnection();   //to be moved in connection.cs used as myconn = new MySqlConnection(mycons);
            myconn.ConnectionString = mycons;   //to be moved in connection.cs
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            cmd.Parameters.AddWithValue("@n", us);
            cmd.Parameters.AddWithValue("@s", su);
            cmd.Parameters.AddWithValue("@g", ge);
            cmd.Parameters.AddWithValue("@d", date);
            cmd.Parameters.AddWithValue("@i", img); //add the image
            cmd.ExecuteNonQuery();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();           
            f3.user = username;
            f3.pass = password;
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text;
            comboBox1.Items.Add(a);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.Text;
            try
            {
                getDataDb(comboBox1.Text);
               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void Fillcombo()
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=Ati;PASSWORD=test";
            string query = "Select * from  table_ati;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string name = red.GetString("name");
                comboBox1.Items.Add(name);
            }
        }

        public void getDataDb(string names)
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=Ati;PASSWORD=test";
            string query = "Select * from  table_ati where name = @names;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            cmd.Parameters.AddWithValue("@names", names);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                
                string name = red.GetString("name");
                string surname = red.GetString("suname");
                //string gender = red.GetString("gender");
                //string dob = red.GetString("dob");
                textBox1.Text = name;
                textBox2.Text = surname;

                //retrieve the image from db
                byte[] img = (Byte[])(red["Image"]);
                if(img == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    pictureBox1.Refresh();
                }
                
                
                //comboBox1.Items.Add(name);
            }
        }

        public void fill_listobox()
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=Ati;PASSWORD=test";
            string query = "Select * from  table_ati;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string name = red.GetString("name");
                listBox1.Items.Add(name);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getDataDb(listBox1.Text);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                load_table();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        public void load_table()
        {
            string mycons = "SERVER=192.168.14.29;PORT=3306;DATABASE=ati;UID=Ati;PASSWORD=test";
            string query = "Select * from  table_ati;";
            myconn = new MySqlConnection();
            myconn.ConnectionString = mycons;
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(query, myconn);
            MySqlDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = cmd;
            DataTable db = new DataTable();
            adap.Fill(db);
            BindingSource bsourc = new BindingSource();
            bsourc.DataSource = db;
            dataGridView1.DataSource = bsourc;
            adap.Update(db);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label3.Text = d.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            
        }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
           // {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["name"].Value.ToString();
                textBox2.Text = row.Cells["suname"].Value.ToString();


           // }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton1.Text.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton2.Text.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog() == DialogResult.OK)
            {
                string s = op.FileName;
                MessageBox.Show(s);
            }
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            int index = 0;
            string temp = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = temp;

            while(index < richTextBox1.Text.LastIndexOf(textBox3.Text))
            {
                richTextBox1.Find(textBox3.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Red;
                index = richTextBox1.Text.IndexOf(textBox3.Text, index) + 1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("test_file.txt");
            sw.Write("this is a test");
            sw.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //create new xls 
            string file = "newdoc.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");
            worksheet.Cells[0, 1] = new Cell((short)1);
            worksheet.Cells[2, 0] = new Cell(9999999);
            worksheet.Cells[3, 3] = new Cell((decimal)3.45);
            worksheet.Cells[2, 2] = new Cell("Text string");
            worksheet.Cells[2, 4] = new Cell("Second string");
            worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
            worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD");
            worksheet.Cells.ColumnWidth[0, 1] = 3000; workbook.Worksheets.Add(worksheet); workbook.Save(file);

            // open xls file 
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if(op.ShowDialog() == DialogResult.OK)
            {
                pdf1.src = op.FileName;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                string pathf = op.FileName;
                Process.Start(pathf);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<=6; i++)
            {
                Console.Beep();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = op.FileName;
            }
        }

        private void button16_Click(object sender, EventArgs e)
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

        private void button17_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(textBox5.Text);
            int max = Convert.ToInt32(textBox6.Text);
            Random r = new Random();
            textBox7.Text = r.Next(min, max).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                string picloc = op.FileName.ToString();
                textBox8.Text = picloc;
                pictureBox1.ImageLocation = picloc;
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("pic.jpg");
            //png.ScalePercent(200);//sizing
            png.ScaleToFit(50f, 70f);
            png.Border = iTextSharp.text.Rectangle.BOX;
            png.BorderColor = iTextSharp.text.BaseColor.YELLOW;
            png.BorderWidth = 3;

            //png.SetAbsolutePosition(doc.PageSize.Width - 36f - 72f, doc.PageSize.Width - 40f - 72f);//positioning
            doc.Add(png);

            Paragraph p = new Paragraph("This is my test document");
            doc.Add(p);

            //create and add a list to the pdf file
            List list = new List(List.UNORDERED);
            //other list type: RomanList
            list.IndentationLeft = 30f;
            list.Add("one");
            list.Add("twoo");
            list.Add("three");
            list.Add("four");

            RomanList rl = new RomanList(true, 20);
            rl.Add("one");
            rl.Add("twoo");
            rl.Add("List");
            rl.Add(list);
            rl.Add("four");


            doc.Add(rl);
            PdfPTable t = new PdfPTable(3);

            //PdfPCell cell = new PdfPCell(new Phrase("this is a phare"));
            //cell.Colspan = 3;
            //cell.HorizontalAlignment = 1; // 0-left, 1-centre, 2 right
            //cell.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 0);
            //t.AddCell(cell);
            //t.AddCell("col 2 row 1");
            //t.AddCell("col 3 row 1");
            //t.AddCell("col 1 row 2");
            //t.AddCell("col 2 row 2");
            //t.AddCell("col 3 row 2");
            //doc.Add(t);

            if (dataGridView1.Columns.Count == 0)
            {
                
                    MessageBox.Show("load the table first stupid, or it will throw an exception and the table will not be loaded");
                
            }
            else
            {
                PdfPTable ta = new PdfPTable(dataGridView1.Columns.Count);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ta.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                }
                ta.HeaderRows = 1;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            ta.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }

                    }
                }
                doc.Add(ta);

            }
            
            

            doc.Close();
            System.Diagnostics.Process.Start("test.pdf");


        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
