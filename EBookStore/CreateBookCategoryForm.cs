using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EBookStore.Infra.Extenstions;

namespace EBookStore
{
    public partial class CreateBookCategoryForm : Form
    {
        public CreateBookCategoryForm()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string categoryName = CNTextBox.Text;


            string categoryId = CITextBox.Text;

            string sql = @"INSERT INTO BookCategories
(CategoryName, categoryId)
VALUES
(@CategoryName, @categoryId)";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("CategoryName", 50, categoryName)
                .AddNVarchar("categoryId",1, categoryId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            // MessageBox.Show("記錄已新增");
            this.DialogResult = DialogResult.OK;
        }
    }
}
