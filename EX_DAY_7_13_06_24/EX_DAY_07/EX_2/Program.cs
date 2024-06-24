using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();

            try
            {
                manager.AddProduct(new Phone("iPhone 13", "Điện thoại", 20000000, 50, "Apple", "13"));
                manager.AddProduct(new Laptop("MacBook Pro", "Laptop", 40000000, 30, "Apple", "Pro 2021"));
                manager.AddProduct(new Book("Sách A", "Sách", 100000, 100, "Tác giả A", "Nhà xuất bản B"));
                manager.AddProduct(new ElectronicDevice("Tivi Samsung", "Đồ điện tử", 15000000, 20, "Samsung", "Model X"));

                manager.ListProducts();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
