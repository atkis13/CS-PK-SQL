namespace Loginapp
{
    partial class frm_MDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDI1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDI2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDI1ToolStripMenuItem,
            this.mDI2ToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // mDI1ToolStripMenuItem
            // 
            this.mDI1ToolStripMenuItem.Name = "mDI1ToolStripMenuItem";
            this.mDI1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mDI1ToolStripMenuItem.Text = "MDI 1";
            this.mDI1ToolStripMenuItem.Click += new System.EventHandler(this.mDI1ToolStripMenuItem_Click);
            // 
            // mDI2ToolStripMenuItem
            // 
            this.mDI2ToolStripMenuItem.Name = "mDI2ToolStripMenuItem";
            this.mDI2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mDI2ToolStripMenuItem.Text = "MDI 2";
            this.mDI2ToolStripMenuItem.Click += new System.EventHandler(this.mDI2ToolStripMenuItem_Click);
            // 
            // frm_MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 404);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_MDI";
            this.Text = "frm_MDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDI1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDI2ToolStripMenuItem;
    }
}