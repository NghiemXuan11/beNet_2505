using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (employees.Exists(e => e.Name == employee.Name))
                throw new ArgumentException("Tên nhân viên đã tồn tại.");

            employees.Add(employee);
        }

        public void ListEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Tên: {employee.Name}, Giới tính: {employee.Gender}, Tuổi: {employee.Age}, Lương: {employee.CalculateSalary()}");
            }
        }
    }
}
