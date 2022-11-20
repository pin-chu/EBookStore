using EBookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBookStore
{
    public partial class BookCategoryForm : Form
    {
        DataTable categories;
        public BookCategoryForm()
        {
            InitializeComponent();

            DisplayBookCatetories();
        }
      
       
        private void DisplayBookCatetories()
        {
            string sql = @"SELECT [CategoryId],[CategoryName] 
            FROM BookCategories ORDER BY CategoryId";

            categories = new SqlDbHelper("default").Select(sql, null);


            BindData(categories);

        }
        private void BindData(DataTable model)
        {
            dataGridView1.DataSource = model;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateBookCategoryForm();

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayBookCatetories();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex < 0) return;

            // BookCategoryIndexVM row = this.categories[rowIndex];

            DataRow row = this.categories.Rows[rowIndex];
            string CategoryId = row.Field<string>("CategoryId");

            var frm = new EditBookCategoryForm(CategoryId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayBookCatetories();
            }
        }
    }
}
