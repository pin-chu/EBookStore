using EBookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBookStore
{
    public partial class BookForm : Form
    {
        private BookIndexVM[] books = null;
        public BookForm()
        {
            InitializeComponent();

            InitForm();


            DisplayBooks();
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
                CategoryName = row.Field<string>("CategoryName")
            };
        }
        private void DisplayBooks()
        {
            string sql = @"SELECT B.BookId, B.BookName,B.Author, B.PublishYear,B.CategoryId,B.Price, C.CategoryName
FROM Books B
INNER JOIN BookCategories C ON B.CategoryId = C.CategoryId";

            #region 加入 where 
            sql += " WHERE 1=1 ";
           SqlParameter[] parameters = new SqlParameter[] { };
            //取得篩選值
            //類別
            string categoryId = ((BookCategoryVM)categoryIdComboBox.SelectedItem).CategoryId;
            if (!string.IsNullOrEmpty(categoryId))
            {
                sql += " AND B.CategoryId=@CategoryId";
            }
            //書名
            string book_name = BookNameTextBox.Text;
            if (!string.IsNullOrEmpty(book_name))
            {
                sql += " AND B.BookName LIKE '%'+@BookName+'%'";
            }
            //作者
            string author = AuthorTextBox.Text;
            if (!string.IsNullOrEmpty(author))
            {
                sql += " AND B.Author LIKE '%'+@Author+'%'";
            }
            //年分
            string publish_year = PublishYearTextBox.Text;
            if (!string.IsNullOrEmpty(publish_year))
            {
                sql += " AND B.PublishYear = @PublishYear";
            }
            parameters = new SqlParameterBuilder()
               .AddNVarchar("CategoryId",1, categoryId)
               .AddNVarchar("BookName", 50, book_name)
               .AddNVarchar("Author", 50, author)
               .AddNVarchar("PublishYear", 4, publish_year)
               .Build();

            #endregion
            sql += " ORDER BY B.BookId";
            var dbHelper = new SqlDbHelper("default");

            books = dbHelper.Select(sql, parameters)
                .AsEnumerable()
                .Select(row => ParseToIndexVM(row))
                .ToArray();
            BindData(books);

        }
   
        private void BindData(BookIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }
        private BookIndexVM ParseToIndexVM(DataRow row)
        {
            return new BookIndexVM
            {
                BookId = row.Field<int>("BookId"),
                BookName = row.Field<string>("BookName"),
                Author = row.Field<string>("Author"),
                PublishYear = row.Field<string>("PublishYear"),
                CategoryId = row.Field<string>("CategoryId"),
                CategoryName = row.Field<string>("CategoryName"),
                Price = row.Field<int>("Price")
            };
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            DisplayBooks();
        }
       
        private void addnewButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateBookForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayBooks();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            BookIndexVM row = this.books[rowIndx];

            int BookId = row.BookId;

            var frm = new EditBookForm(BookId);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayBooks();
            }

        }

    }
}
