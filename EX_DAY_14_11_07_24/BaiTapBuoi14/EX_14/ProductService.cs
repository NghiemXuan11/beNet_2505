using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EX_14
{
    public class ProductService
    {
        private DatabaseHelper db;

        public ProductService(DatabaseHelper db)
        {
            this.db = db;
        }

        public void AddProduct(int productId, string productName)
        {
            ValidateProduct(productId, productName);
            SqlParameter[] parameters = {
            new SqlParameter("@product_id", productId),
            new SqlParameter("@product_name", productName)
        };
            db.ExecuteNonQuery("AddProduct", parameters);
        }

        public void UpdateProduct(int productId, string productName)
        {
            ValidateProduct(productId, productName);
            SqlParameter[] parameters = {
            new SqlParameter("@product_id", productId),
            new SqlParameter("@product_name", productName)
        };
            db.ExecuteNonQuery("UpdateProduct", parameters);
        }

        public void DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be a positive integer.");
            }

            SqlParameter[] parameters = {
            new SqlParameter("@product_id", productId)
        };
            db.ExecuteNonQuery("DeleteProduct", parameters);
        }

        private void ValidateProduct(int productId, string productName)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be a positive integer.");
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name must not be empty.");
            }
        }
    }
}
