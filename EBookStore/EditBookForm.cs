using EBookStore.Infra.Extenstions;
using EBookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBookStore
{
    public partial class EditBookForm : Form
    {
        private  int BookId;
        public EditBookForm(int BookId)
        {
            InitializeComponent();
            this.BookId = BookId;
            InitForm();
            BindData(BookId);
        }
        private void EditBookForm_Load(object sender, EventArgs e)
        {
            BindData(BookId);
        }

        private void BindData(int BookId)
        {
            string sql = "SELECT * FROM Books WHERE BookId=@BookId";
            var parameters = new SqlParameterBuilder()
                .AddInt("BookId", this.BookId)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉, 找不到要編輯的記錄");
                this.DialogResult = DialogResult.Abort;

                this.Close();
                return;
            }


            BookVM model = ToBookVM(data.Rows[0]);

            categoryIdComboBox.SelectedItem = ((List<BookCategoryVM>)categoryIdComboBox.DataSource)
                                         .Where(x=>x.CategoryId == model.CategoryId)
                                         .FirstOrDefault();
            BookNameTextBox.Text = model.BookName;
            AuthorTextBox.Text = model.Author.ToString();
            PublishYearTextBox.Text = model.PublishYear;
            PriceTextBox.Text = model.Price.ToString();

        }
        private BookVM ToBookVM(DataRow row)
        {
            return new BookVM
            {
                BookId = row.Field<int>("BookId"),
                CategoryId = row.Field<string>("CategoryId"),
                BookName = row.Field<string>("BookName"),
                Author = row.Field<string>("Author"),
                PublishYear = row.Field<string>("PublishYear"),
                Price = row.Field<int>("Price")
            };
        }
        private void InitForm()
        {
            // 設定 categoryIdComboBox property
            categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            var sql = "SELECT * FROM BookCategories ORDER BY CategoryId";
            var dbHelper = new SqlDbHelper("default");

            List<BookCategoryVM> categories = dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => ToCategoryVM(row))
                .Prepend(new BookCategoryVM { CategoryId = "", CategoryName = String.Empty })
                .ToList();

            this.categoryIdComboBox.DataSource = categories;

        }

        private BookCategoryVM ToCategoryVM(DataRow row)
        {
            return new BookCategoryVM
            {
                CategoryId = row.Field<string>("CategoryId"),
                CategoryName = row.Field<string>("CategoryName"),
              
            };
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string CategoryId = ((BookCategoryVM)this.categoryIdComboBox.SelectedItem).CategoryId;
            string BookName = BookNameTextBox.Text;
            string Author = AuthorTextBox.Text;
            string PublishYear = PublishYearTextBox.Text;
            int Price = PriceTextBox.Text.ToInt(-1);

            BookVM model = new BookVM
            { 
                BookName = BookName,
                Author = Author,
                PublishYear = PublishYear,
                Price = Price
            };

        // 針對ViewModel進行欄位驗證
        string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(model.BookName)) errorMsg += "商品名稱必填\r\n";
            if (model.Price < 0) errorMsg += "牌價必需輸入大於或等於零的整數\r\n";

            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                //表示至少一欄有錯誤
                MessageBox.Show(errorMsg);
                return; // 不再向下執行
            }

            string sql = @"UPDATE Books
SET BookName = @BookName, CategoryId = @CategoryId, Author = @Author,PublishYear = @PublishYear,Price = @Price
WHERE  BookId = @BookId";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("BookName", 50, BookName)
                .AddNVarchar("CategoryId", 1, CategoryId)
                .AddNVarchar("Author", 50,Author)
                .AddNVarchar("PublishYear", 4, PublishYear)
                .AddInt("BookId", this.BookId)
                .AddInt("Price", Price)
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

            string sql = @"DELETE FROM Books WHERE BookId=@BookId";

            var parameters = new SqlParameterBuilder()
                .AddInt("BookId",this.BookId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }

    }
}
