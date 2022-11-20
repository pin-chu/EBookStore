using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Models.ViewModels
{
    public class BookIndexVM
    {
        [DisplayName("書籍id")]
        public int BookId { get; set; }
        [DisplayName("書籍名稱")]
        public string BookName { get; set; }
        [DisplayName("書籍作者")]
        public string Author { get; set; }
        [DisplayName("出版年份")]
        public string PublishYear { get; set; }
        [DisplayName("類別代號")]
        public string CategoryId { get; set; }
        [DisplayName("類別名稱")]
        public string CategoryName { get; set; }
        [DisplayName("價格")]
        public int Price { get; set; }
    }
    public class BookVM
    {
        public int BookId { get; set; }
        public string CategoryId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string PublishYear { get; set; }
        public int Price { get; set; }
    }
}
