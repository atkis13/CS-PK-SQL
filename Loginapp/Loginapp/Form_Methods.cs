using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;



namespace Loginapp
{
    class Form_Methods
    {
        //Defining global variables
        static DBConnection conn;

        

        //Creating the pdf document using the data from the datagridview
        public static void createPDFDocument(DataGridView d)
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
            // The bellow code is for adding a normala table to the pdf 
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

            //loading tha table 
            if (d.Columns.Count == 0)
            {

                MessageBox.Show("load the table first stupid, or it will throw an exception and the table will not be loaded");

            }
            else
            {
                PdfPTable ta = new PdfPTable(d.Columns.Count);
                for (int j = 0; j < d.Columns.Count; j++)
                {
                    ta.AddCell(new Phrase(d.Columns[j].HeaderText));
                }
                ta.HeaderRows = 1;

                for (int i = 0; i < d.Columns.Count; i++)
                {
                    for (int k = 0; k < d.Columns.Count; k++)
                    {
                        if (d[k, i].Value != null)
                        {
                            ta.AddCell(new Phrase(d[k, i].Value.ToString()));
                        }

                    }
                }
                doc.Add(ta);
                //Opening the PDF file
                System.Diagnostics.Process.Start("test.pdf");

            }



            doc.Close();
        }


        //read a pdf file into a rih text field and convert it into a text file
        //open the text file after conversion
        public static void read_pd_file(RichTextBox rt)
        {
            OpenFileDialog op = new OpenFileDialog();
            string pathf;
            op.Filter = "PDF Files(*.PDF)|*.PDF|All files(*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pathf = op.FileName.ToString();



                string strx = string.Empty;

                try
                {
                    //adding the pdf to the rich text box
                    PdfReader reader = new PdfReader(pathf);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        strx = strx + s;
                        rt.Text = strx;
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //converting the pdf to text

            StreamWriter sw = new StreamWriter("pdf_to_text.txt");
            sw.Write(rt.Text);
            sw.Close();
            System.Diagnostics.Process.Start("pdf_to_text.txt");

        }

        

        // Method to add new entries in the database 
        public static void addData(string us, string su, string ge, string date, byte[] img)
        {

            string query = "INSERT INTO table_ati(name, suname, gender,dob, Image) VALUES(@n, @s, @g, @d, @i);";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@n", us);
            cmd.Parameters.AddWithValue("@s", su);
            cmd.Parameters.AddWithValue("@g", ge);
            cmd.Parameters.AddWithValue("@d", date);
            cmd.Parameters.AddWithValue("@i", img); //add the image
            cmd.ExecuteNonQuery();

        }

        //fills the combobox from values from the db
        public static void Fillcombo(ComboBox cb)
        {

            string query = "Select * from  table_ati;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string name = red.GetString("name");
                cb.Items.Add(name);
            }
        }

        //Fetches all the data from the DB based on the name column
        public static void  getDataDb(string names, TextBox name_txt, TextBox surname_txt, PictureBox pic)
        {

            string query = "Select * from  table_ati where name = @names;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@names", names);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {

                string name = red.GetString("name");
                string surname = red.GetString("suname");
                //string gender = red.GetString("gender");
                //string dob = red.GetString("dob");
                name_txt.Text = name;
                surname_txt.Text = surname;

                //retrieve the image from db
                byte[] img = (Byte[])(red["Image"]);
                if (img == null)
                {
                    pic.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    pic.Image = System.Drawing.Image.FromStream(ms);
                    pic.Refresh();
                }


                //comboBox1.Items.Add(name); - obsolete - superseeded by Fillcombo()
            }
        }

        //fills the listbox with values from the DB
        public static void fill_listobox(ListBox lb)
        {

            string query = "Select * from  table_ati;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string name = red.GetString("name");
                lb.Items.Add(name);
            }

        }

        //Method to load the table from the db
        public static  void load_table(DataGridView dg)
        {

            string query = "Select * from  table_ati;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = cmd;
            DataTable db = new DataTable();
            adap.Fill(db);
            BindingSource bsourc = new BindingSource();
            bsourc.DataSource = db;
            dg.DataSource = bsourc;
            adap.Update(db);

        }

        //Close the connection to the database
        public static void close_db()
        {
            conn.Close();
        }

        //Select image and add to picturebox
        public static void addImgPicbox(TextBox txt, PictureBox pic)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                string picloc = op.FileName.ToString();
                txt.Text = picloc;
                pic.ImageLocation = picloc;
            }

        }

        //Search the rich text box for entered keywords
        public static void searchRichText(RichTextBox rt, TextBox txt)
        {
            int index = 0;
            string temp = rt.Text;
            rt.Text = "";
            rt.Text = temp;

            while (index <rt.Text.LastIndexOf(txt.Text))
            {
                rt.Find(txt.Text, index, rt.TextLength, RichTextBoxFinds.None);
                rt.SelectionBackColor = Color.Red;
                index = rt.Text.IndexOf(txt.Text, index) + 1;
            }
        }

        //Create XLS file
        public static  void create_excel_file()
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

        //Create new button method
        public static void create_btn(Button b)
        {
            b = new Button();
            b.Parent = Form.ActiveForm;
            b.Location = new System.Drawing.Point(1120, 273);
            b.Size = new System.Drawing.Size(106, 23);
            b.Name = "btn_created";
            b.Text = "Created Button";
            b.Click += new System.EventHandler(btn_created_Click);

        }

        private static void btn_created_Click( object sender, EventArgs e)
        {
            MessageBox.Show("created");
        }


        //the method toactually load thedirecory specified in the path
        public static void ListDir(TreeView tw, string path)
        {
            tw.Nodes.Clear();
            var rootDir = new DirectoryInfo(path);

            tw.Nodes.Add(CreateDir(rootDir));
        }

        //new directory info to load a directory and its files into a treeview
        public static TreeNode CreateDir(DirectoryInfo di)
        {
            var dirNode = new TreeNode(di.Name);
            foreach (var dir in di.GetDirectories())
            {
                dirNode.Nodes.Add(CreateDir(dir));
            }

            foreach (var file in di.GetFiles())
            {
                dirNode.Nodes.Add(new TreeNode(file.Name));
            }

            return dirNode;


        }

        //fills the suggestion string for textbox
        public static void fill_auto_suggestions(AutoCompleteStringCollection aut)
        {

            string query = "Select * from  table_ati;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string name = red.GetString("name");
                aut.Add(name);
            }
        }



    }

    
}
