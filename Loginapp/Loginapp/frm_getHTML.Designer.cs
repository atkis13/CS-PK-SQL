namespace Loginapp
{
    partial class frm_getHTML
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_get_source = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_download = new System.Windows.Forms.TextBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_opendir = new System.Windows.Forms.Button();
            this.btn_covert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(315, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(317, 166);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // bt_get_source
            // 
            this.bt_get_source.Location = new System.Drawing.Point(44, 20);
            this.bt_get_source.Name = "bt_get_source";
            this.bt_get_source.Size = new System.Drawing.Size(75, 23);
            this.bt_get_source.TabIndex = 1;
            this.bt_get_source.Text = "Get Source Code";
            this.bt_get_source.UseVisualStyleBackColor = true;
            this.bt_get_source.Click += new System.EventHandler(this.bt_get_source_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(44, 49);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(184, 20);
            this.txt_url.TabIndex = 2;
            // 
            // txt_download
            // 
            this.txt_download.Location = new System.Drawing.Point(44, 127);
            this.txt_download.Name = "txt_download";
            this.txt_download.Size = new System.Drawing.Size(184, 20);
            this.txt_download.TabIndex = 3;
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(44, 98);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(90, 23);
            this.btn_download.TabIndex = 4;
            this.btn_download.Text = "Download File";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(315, 234);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(317, 199);
            this.listBox1.TabIndex = 5;
            // 
            // btn_opendir
            // 
            this.btn_opendir.Location = new System.Drawing.Point(315, 205);
            this.btn_opendir.Name = "btn_opendir";
            this.btn_opendir.Size = new System.Drawing.Size(98, 23);
            this.btn_opendir.TabIndex = 6;
            this.btn_opendir.Text = "Open Directory";
            this.btn_opendir.UseVisualStyleBackColor = true;
            this.btn_opendir.Click += new System.EventHandler(this.btn_opendir_Click);
            // 
            // btn_covert
            // 
            this.btn_covert.Location = new System.Drawing.Point(44, 179);
            this.btn_covert.Name = "btn_covert";
            this.btn_covert.Size = new System.Drawing.Size(123, 23);
            this.btn_covert.TabIndex = 7;
            this.btn_covert.Text = "Covert Image Format";
            this.btn_covert.UseVisualStyleBackColor = true;
            this.btn_covert.Click += new System.EventHandler(this.btn_covert_Click);
            // 
            // frm_getHTML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 562);
            this.Controls.Add(this.btn_covert);
            this.Controls.Add(this.btn_opendir);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.txt_download);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.bt_get_source);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frm_getHTML";
            this.Text = "frm_getHTML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bt_get_source;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_download;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_opendir;
        private System.Windows.Forms.Button btn_covert;
    }
}