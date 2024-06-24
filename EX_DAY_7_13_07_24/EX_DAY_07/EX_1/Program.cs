using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            try
            {
                manager.AddEmployee(new FullTimeEmployee("Nguyen Van A", "Nam", 30, 5000000));
                manager.AddEmployee(new PartTimeEmployee("Tran Thi B", "Nữ", 25, 200000, 80));
                manager.AddEmployee(new InternEmployee("Le Van C", "Nam", 22, 1000000));

                manager.ListEmployees();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
