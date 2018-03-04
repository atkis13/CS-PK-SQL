namespace Loginapp
{
    partial class frm_Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Browser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_back = new System.Windows.Forms.ToolStripButton();
            this.btn_forward = new System.Windows.Forms.ToolStripButton();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_stop = new System.Windows.Forms.ToolStripButton();
            this.txt_url = new System.Windows.Forms.ToolStripTextBox();
            this.btn_go = new System.Windows.Forms.ToolStripButton();
            this.btn_home = new System.Windows.Forms.ToolStripButton();
            this.prg_progress = new System.Windows.Forms.ToolStripProgressBar();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_back,
            this.btn_forward,
            this.btn_refresh,
            this.btn_stop,
            this.txt_url,
            this.btn_go,
            this.btn_home,
            this.prg_progress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(591, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_back
            // 
            this.btn_back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_back.Image = ((System.Drawing.Image)(resources.GetObject("btn_back.Image")));
            this.btn_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(23, 22);
            this.btn_back.Text = "toolStripButton2";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_forward
            // 
            this.btn_forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_forward.Image = ((System.Drawing.Image)(resources.GetObject("btn_forward.Image")));
            this.btn_forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(23, 22);
            this.btn_forward.Text = "toolStripButton1";
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(23, 22);
            this.btn_refresh.Text = "toolStripButton3";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_stop.Image = ((System.Drawing.Image)(resources.GetObject("btn_stop.Image")));
            this.btn_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(23, 22);
            this.btn_stop.Text = "toolStripButton4";
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_url
            // 
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(100, 25);
            // 
            // btn_go
            // 
            this.btn_go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_go.Image = ((System.Drawing.Image)(resources.GetObject("btn_go.Image")));
            this.btn_go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(23, 22);
            this.btn_go.Text = "toolStripButton5";
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // btn_home
            // 
            this.btn_home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_home.Image = ((System.Drawing.Image)(resources.GetObject("btn_home.Image")));
            this.btn_home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(23, 22);
            this.btn_home.Text = "toolStripButton6";
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // prg_progress
            // 
            this.prg_progress.Name = "prg_progress";
            this.prg_progress.Size = new System.Drawing.Size(100, 22);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 49);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(591, 378);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showHelpToolStripMenuItem
            // 
            this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
            this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showHelpToolStripMenuItem.Text = "Show Help";
            this.showHelpToolStripMenuItem.Click += new System.EventHandler(this.showHelpToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // frm_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 427);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Browser";
            this.Text = "frm_Browser";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_forward;
        private System.Windows.Forms.ToolStripButton btn_back;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.ToolStripButton btn_stop;
        private System.Windows.Forms.ToolStripTextBox txt_url;
        private System.Windows.Forms.ToolStripButton btn_go;
        private System.Windows.Forms.ToolStripButton btn_home;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripProgressBar prg_progress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
    }
}