using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (products.Exists(p => p.Name == product.Name))
                throw new ArgumentException("Tên sản phẩm đã tồn tại.");

            products.Add(product);
        }

        public void ListProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Tên: {product.Name}, Danh mục: {product.Category}, Giá: {product.Price:C}, Tồn kho: {product.Stock}, Giá bán: {product.CalculateSalePrice():C}");
            }
        }
    }
}
