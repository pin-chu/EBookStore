using EBookStore.Infra.Extenstions;
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
namespace EBookStore
{
    public partial class EditBookCategoryForm : Form
    {
        private string CategoryId;
        public EditBookCategoryForm(string CategoryId)
        {
            InitializeComponent();
            this.CategoryId = CategoryId;
            BindData(CategoryId);
        }
        private void BindData(string CategoryId)
        {
            string sql = "SELECT * FROM BookCategories WHERE CategoryId=@CategoryId";
            var parameters = new SqlParameterBuilder()
                .AddNVarchar("CategoryId",1, CategoryId)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉, 找不到要編輯的記錄");
                this.DialogResult = DialogResult.Abort;

                this.Close();
                return;
            }

            // 將欄位值放入控制項裡
            DataRow row = data.Rows[0];

            categoryNameTextBox.Text = row.Field<string>("CategoryName");
            displayOrderTextBox.Text = row.Field<string>("CategoryId").ToString();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;

            string CategoryId = displayOrderTextBox.Text;

            string sql = @"UPDATE BookCategories
SET CategoryName=@CategoryName, CategoryId=@CategoryId
WHERE  CategoryId=@CategoryId";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("CategoryName", 50, categoryName)
                .AddNVarchar("CategoryId",1, this.CategoryId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox
                .Show("您真的要刪除嗎?",
                        "刪除記錄",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string sql = @"DELETE FROM BookCategories WHERE CategoryId=@CategoryId";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("CategoryId", 1,this.CategoryId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }

    }
}
