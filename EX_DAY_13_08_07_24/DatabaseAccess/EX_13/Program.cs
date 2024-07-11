using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_13
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();

            while (true)
            {
                Console.WriteLine("Chọn thao tác:");
                Console.WriteLine("1. Thêm Sản phẩm");
                Console.WriteLine("2. Sửa Sản phẩm");
                Console.WriteLine("3. Xóa Sản phẩm");
                Console.WriteLine("4. Thêm Biến thể Sản phẩm");
                Console.WriteLine("5. Sửa Biến thể Sản phẩm");
                Console.WriteLine("6. Xóa Biến thể Sản phẩm");
                Console.WriteLine("7. Hiển thị danh sách Sản phẩm");
                Console.WriteLine("8. Hiển thị danh sách Biến thể Sản phẩm");
                Console.WriteLine("9. Thoát");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        productService.AddProduct();
                        break;
                    case "2":
                        productService.UpdateProduct();
                        break;
                    case "3":
                        productService.DeleteProduct();
                        break;
                    case "4":
                        productService.AddProductVariant();
                        break;
                    case "5":
                        productService.UpdateProductVariant();
                        break;
                    case "6":
                        productService.DeleteProductVariant();
                        break;
                    case "7":
                        productService.DisplayProducts();
                        break;
                    case "8":
                        productService.DisplayProductVariants();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
