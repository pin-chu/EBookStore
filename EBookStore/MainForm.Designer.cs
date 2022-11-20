namespace EBookStore
{
    partial class MainForm
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
            this.維護商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.維護商品類別ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.維護使用者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.維護商品ToolStripMenuItem,
            this.維護商品類別ToolStripMenuItem,
            this.維護使用者ToolStripMenuItem,
            this.登出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 維護商品ToolStripMenuItem
            // 
            this.維護商品ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.維護商品ToolStripMenuItem.Name = "維護商品ToolStripMenuItem";
            this.維護商品ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.維護商品ToolStripMenuItem.Text = "維護書籍";
            this.維護商品ToolStripMenuItem.Click += new System.EventHandler(this.維護書籍ToolStripMenuItem_Click);
            // 
            // 維護商品類別ToolStripMenuItem
            // 
            this.維護商品類別ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.維護商品類別ToolStripMenuItem.Name = "維護商品類別ToolStripMenuItem";
            this.維護商品類別ToolStripMenuItem.Size = new System.Drawing.Size(118, 25);
            this.維護商品類別ToolStripMenuItem.Text = "維護書籍類別";
            this.維護商品類別ToolStripMenuItem.Click += new System.EventHandler(this.維護書籍類別ToolStripMenuItem_Click);
            // 
            // 維護使用者ToolStripMenuItem
            // 
            this.維護使用者ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.維護使用者ToolStripMenuItem.Name = "維護使用者ToolStripMenuItem";
            this.維護使用者ToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.維護使用者ToolStripMenuItem.Text = "維護使用者";
            this.維護使用者ToolStripMenuItem.Click += new System.EventHandler(this.維護使用者ToolStripMenuItem_Click);
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.登出ToolStripMenuItem.Text = "登出";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.登出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 維護商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 維護商品類別ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 維護使用者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
    }
}