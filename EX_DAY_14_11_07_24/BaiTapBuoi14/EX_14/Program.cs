using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=11112001NGHIEM\NGHIEMXUAN;Initial Catalog=BaiTapBuoi14;Integrated Security=True";

            DatabaseHelper dbHelper = new DatabaseHelper(connectionString);
            ProductService productService = new ProductService(dbHelper);
            GroupAttributeService groupAttributeService = new GroupAttributeService(dbHelper);
            AttributeService attributeService = new AttributeService(dbHelper);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Add Group Attribute");
                Console.WriteLine("5. Update Group Attribute");
                Console.WriteLine("6. Delete Group Attribute");
                Console.WriteLine("7. Add Attribute");
                Console.WriteLine("8. Update Attribute");
                Console.WriteLine("9. Delete Attribute");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Product ID: ");
                            int productId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Product Name: ");
                            string productName = Console.ReadLine();
                            productService.AddProduct(productId, productName);
                            Console.WriteLine("Product added successfully.");
                            break;
                        case "2":
                            Console.Write("Enter Product ID: ");
                            productId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Product Name: ");
                            productName = Console.ReadLine();
                            productService.UpdateProduct(productId, productName);
                            Console.WriteLine("Product updated successfully.");
                            break;
                        case "3":
                            Console.Write("Enter Product ID: ");
                            productId = int.Parse(Console.ReadLine());
                            productService.DeleteProduct(productId);
                            Console.WriteLine("Product deleted successfully.");
                            break;
                        case "4":
                            Console.Write("Enter Group ID: ");
                            int groupId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Group Name: ");
                            string groupName = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            string price = Console.ReadLine();
                            groupAttributeService.AddGroupAttribute(groupId, groupName, price);
                            Console.WriteLine("Group attribute added successfully.");
                            break;
                        case "5":
                            Console.Write("Enter Group ID: ");
                            groupId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Group Name: ");
                            groupName = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            price = Console.ReadLine();
                            groupAttributeService.UpdateGroupAttribute(groupId, groupName, price);
                            Console.WriteLine("Group attribute updated successfully.");
                            break;
                        case "6":
                            Console.Write("Enter Group ID: ");
                            groupId = int.Parse(Console.ReadLine());
                            groupAttributeService.DeleteGroupAttribute(groupId);
                            Console.WriteLine("Group attribute deleted successfully.");
                            break;
                        case "7":
                            Console.Write("Enter Attribute ID: ");
                            int attributeId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Attribute Name: ");
                            string attributeName = Console.ReadLine();
                            Console.Write("Enter Attribute Value: ");
                            string attributeValue = Console.ReadLine();
                            Console.Write("Enter Group ID: ");
                            groupId = int.Parse(Console.ReadLine());
                            attributeService.AddAttribute(attributeId, attributeName, attributeValue, groupId);
                            Console.WriteLine("Attribute added successfully.");
                            break;
                        case "8":
                            Console.Write("Enter Attribute ID: ");
                            attributeId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Attribute Name: ");
                            attributeName = Console.ReadLine();
                            Console.Write("Enter Attribute Value: ");
                            attributeValue = Console.ReadLine();
                            Console.Write("Enter Group ID: ");
                            groupId = int.Parse(Console.ReadLine());
                            attributeService.UpdateAttribute(attributeId, attributeName, attributeValue, groupId);
                            Console.WriteLine("Attribute updated successfully.");
                            break;
                        case "9":
                            Console.Write("Enter Attribute ID: ");
                            attributeId = int.Parse(Console.ReadLine());
                            attributeService.DeleteAttribute(attributeId);
                            Console.WriteLine("Attribute deleted successfully.");
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}
