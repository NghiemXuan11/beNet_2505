using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, string category, decimal price, int stock)
        {
            if (!IsValidName(name))
                throw new ArgumentException("Tên không hợp lệ.");
            if (!IsValidCategory(category))
                throw new ArgumentException("Danh mục không hợp lệ.");
            if (!IsValidPrice(price))
                throw new ArgumentException("Giá không hợp lệ.");
            if (!IsValidStock(stock))
                throw new ArgumentException("Số lượng tồn không hợp lệ.");

            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }

        // Abstract method to calculate sale price
        public abstract decimal CalculateSalePrice();

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        private bool IsValidCategory(string category)
        {
            return !string.IsNullOrWhiteSpace(category);
        }

        private bool IsValidPrice(decimal price)
        {
            return price > 0;
        }

        private bool IsValidStock(int stock)
        {
            return stock >= 0;
        }
    }
}
