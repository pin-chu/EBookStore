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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBookStore
{
    public partial class CreateBookForm : Form
    {
        public CreateBookForm()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            // 設定 categoryIdComboBox property
            categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


            var sql = "SELECT * FROM BookCategories ORDER BY categoryId";
            var dbHelper = new SqlDbHelper("default");

            List<BookCategoryVM> categories = dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => ToCategoryVM(row))
                .Prepend(new BookCategoryVM { CategoryId = "0", CategoryName = String.Empty })
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            // 取得表單的各欄位值
            string CategoryId = ((BookCategoryVM)this.categoryIdComboBox.SelectedItem).CategoryId;
            string BookName = BookNameTextBox.Text;
            string Author = AuthorTextBox.Text;
            string PublishYear = PublishYearTextBox.Text;
            int Price = PriceTextBox.Text.ToInt(-1);

            // 將它們繫結到ViewModel
            BookVM model = new BookVM
            {
                CategoryId = CategoryId,
                BookName = BookName,
                Author = Author,
                PublishYear = PublishYear,
                Price = Price
            };

            // 如果通過驗證,就新增記錄
            string sql = @"INSERT INTO Books
(CategoryId,BookName, Author,PublishYear,Price)
VALUES
(@CategoryId,@BookName, @Author,@PublishYear,@Price)";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("CategoryId",1, model.CategoryId)
                .AddNVarchar("BookName", 50, model.BookName)
                .AddNVarchar("Author", 50, model.Author)
                .AddNVarchar("PublishYear", 4, model.PublishYear)
                .AddInt("Price", Price)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
