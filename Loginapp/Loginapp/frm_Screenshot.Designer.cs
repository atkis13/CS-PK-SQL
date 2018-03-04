namespace Loginapp
{
    partial class frm_Screenshot
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
            this.components = new System.ComponentModel.Container();
            this.btn_web = new System.Windows.Forms.PictureBox();
            this.btn_screensh = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btn_age = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_web)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_web
            // 
            this.btn_web.Location = new System.Drawing.Point(12, 95);
            this.btn_web.Name = "btn_web";
            this.btn_web.Size = new System.Drawing.Size(1037, 504);
            this.btn_web.TabIndex = 0;
            this.btn_web.TabStop = false;
            // 
            // btn_screensh
            // 
            this.btn_screensh.Location = new System.Drawing.Point(13, 55);
            this.btn_screensh.Name = "btn_screensh";
            this.btn_screensh.Size = new System.Drawing.Size(112, 23);
            this.btn_screensh.TabIndex = 1;
            this.btn_screensh.Text = "Take screenshot";
            this.btn_screensh.UseVisualStyleBackColor = true;
            this.btn_screensh.Click += new System.EventHandler(this.btn_screensh_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open Web";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_age
            // 
            this.btn_age.Location = new System.Drawing.Point(236, 55);
            this.btn_age.Name = "btn_age";
            this.btn_age.Size = new System.Drawing.Size(75, 23);
            this.btn_age.TabIndex = 3;
            this.btn_age.Text = "Show Age";
            this.btn_age.UseVisualStyleBackColor = true;
            this.btn_age.Click += new System.EventHandler(this.btn_age_Click);
            // 
            // frm_Screenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 611);
            this.Controls.Add(this.btn_age);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_screensh);
            this.Controls.Add(this.btn_web);
            this.Name = "frm_Screenshot";
            this.Text = "frm_Screenshot";
            this.SizeChanged += new System.EventHandler(this.frm_Screenshot_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.btn_web)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_web;
        private System.Windows.Forms.Button btn_screensh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_age;
    }
}