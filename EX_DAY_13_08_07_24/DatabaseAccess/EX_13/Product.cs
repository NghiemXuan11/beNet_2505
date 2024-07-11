using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_13
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductVariant
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string Configuration { get; set; }
        public decimal Price { get; set; }
    }
}
