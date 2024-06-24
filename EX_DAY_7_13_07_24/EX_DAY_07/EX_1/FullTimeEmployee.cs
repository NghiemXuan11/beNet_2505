using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, string gender, int age, int salary)
            : base(name, gender, age, salary)
        {
        }

        public override int CalculateSalary()
        {
            return Salary; 
        }
    }
}
