using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public class Laptop : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Laptop(string name, string category, decimal price, int stock, string brand, string model)
            : base(name, category, price, stock)
        {
            Brand = brand;
            Model = model;
        }

        public override decimal CalculateSalePrice()
        {
            // giả sử giảm giá 15% cho laptops
            return Price * 0.85m;
        }
    }
}
