using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBookStore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }
        public void close_form()
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }
        private void 維護書籍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close_form();
            var frm = new BookForm();
            //this.MdiParent.Hide();
            frm.MdiParent = this;
            frm.Show();
       
        }

        private void 維護書籍類別ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close_form();
            var frm = new BookCategoryForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 維護使用者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close_form();
            var frm = new UsersForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("您確定要登出嗎?",
                "登出",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                var frm = new Loginform();
                frm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
