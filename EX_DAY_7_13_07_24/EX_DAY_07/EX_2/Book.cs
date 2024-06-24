using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public class Book : Product
    {
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Book(string name, string category, decimal price, int stock, string author, string publisher)
            : base(name, category, price, stock)
        {
            Author = author;
            Publisher = publisher;
        }

        public override decimal CalculateSalePrice()
        {
            // giả sử giảm 5% cho sách
            return Price * 0.95m;
        }
    }
}
