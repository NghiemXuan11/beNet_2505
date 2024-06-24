using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EX_1
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Employee(string name, string gender, int age, int salary)
        {
            if (!IsValidName(name))
                throw new ArgumentException("Tên không hợp lệ.");
            if (!IsValidGender(gender))
                throw new ArgumentException("Giới tính không hợp lệ.");
            if (!IsValidAge(age))
                throw new ArgumentException("Tuổi không hợp lệ.");
            if (!IsValidSalary(salary))
                throw new ArgumentException("Tiền lương không hợp lệ.");

            Name = name;
            Gender = gender;
            Age = age;
            Salary = salary;
        }

        // Abstract method to calculate salary
        public abstract int CalculateSalary();

        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        private bool IsValidGender(string gender)
        {
            return gender == "Nam" || gender == "Nữ";
        }

        private bool IsValidAge(int age)
        {
            return age > 0;
        }

        private bool IsValidSalary(int salary)
        {
            return salary > 0;
        }
    }
}
