using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_13
{
    public class ProductService
    {
        public void AddProduct()
        {
            Console.WriteLine("Nhập tên sản phẩm:");
            string productName = Console.ReadLine();
            Console.WriteLine("Nhập ID danh mục:");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("ID danh mục phải là số nguyên.");
                return;
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Tên sản phẩm không được để trống.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@ProductName", productName)
            };

            DatabaseHelper.ExecuteNonQuery("AddProduct", parameters);
            Console.WriteLine("Sản phẩm đã được thêm thành công.");
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Nhập ID sản phẩm cần sửa:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("ID sản phẩm phải là số nguyên.");
                return;
            }

            Console.WriteLine("Nhập tên mới của sản phẩm:");
            string productName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Tên sản phẩm không được để trống.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@ProductName", productName)
            };

            DatabaseHelper.ExecuteNonQuery("UpdateProduct", parameters);
            Console.WriteLine("Sản phẩm đã được cập nhật thành công.");
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Nhập ID sản phẩm cần xóa:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("ID sản phẩm phải là số nguyên.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@ProductID", productId)
            };

            DatabaseHelper.ExecuteNonQuery("DeleteProduct", parameters);
            Console.WriteLine("Sản phẩm đã được xóa thành công.");
        }

        public void AddProductVariant()
        {
            Console.WriteLine("Nhập ID sản phẩm:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("ID sản phẩm phải là số nguyên.");
                return;
            }

            Console.WriteLine("Nhập cấu hình sản phẩm:");
            string configuration = Console.ReadLine();
            Console.WriteLine("Nhập giá sản phẩm:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Giá sản phẩm phải là số thực.");
                return;
            }

            if (string.IsNullOrWhiteSpace(configuration))
            {
                Console.WriteLine("Cấu hình sản phẩm không được để trống.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@Configuration", configuration),
                new SqlParameter("@Price", price)
            };

            DatabaseHelper.ExecuteNonQuery("AddProductVariant", parameters);
            Console.WriteLine("Biến thể sản phẩm đã được thêm thành công.");
        }

        public void UpdateProductVariant()
        {
            Console.WriteLine("Nhập ID biến thể cần sửa:");
            if (!int.TryParse(Console.ReadLine(), out int variantId))
            {
                Console.WriteLine("ID biến thể phải là số nguyên.");
                return;
            }

            Console.WriteLine("Nhập cấu hình mới:");
            string configuration = Console.ReadLine();
            Console.WriteLine("Nhập giá mới:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Giá sản phẩm phải là số thực.");
                return;
            }

            if (string.IsNullOrWhiteSpace(configuration))
            {
                Console.WriteLine("Cấu hình sản phẩm không được để trống.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@VariantID", variantId),
                new SqlParameter("@Configuration", configuration),
                new SqlParameter("@Price", price)
            };

            DatabaseHelper.ExecuteNonQuery("UpdateProductVariant", parameters);
            Console.WriteLine("Biến thể sản phẩm đã được cập nhật thành công.");
        }

        public void DeleteProductVariant()
        {
            Console.WriteLine("Nhập ID biến thể cần xóa:");
            if (!int.TryParse(Console.ReadLine(), out int variantId))
            {
                Console.WriteLine("ID biến thể phải là số nguyên.");
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@VariantID", variantId)
            };

            DatabaseHelper.ExecuteNonQuery("DeleteProductVariant", parameters);
            Console.WriteLine("Biến thể sản phẩm đã được xóa thành công.");
        }

        public void DisplayProducts()
        {
            DataTable dataTable = DatabaseHelper.ExecuteQuery("GetAllProducts");
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"ProductID: {row["ProductID"]}, CategoryID: {row["CategoryID"]}, ProductName: {row["ProductName"]}");
            }
        }

        public void DisplayProductVariants()
        {
            DataTable dataTable = DatabaseHelper.ExecuteQuery("GetAllProductVariants");
            Console.WriteLine("Danh sách biến thể sản phẩm:");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"VariantID: {row["VariantID"]}, ProductID: {row["ProductID"]}, Configuration: {row["Configuration"]}, Price: {row["Price"]}");
            }
        }
    }
}
