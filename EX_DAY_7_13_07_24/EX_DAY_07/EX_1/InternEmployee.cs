using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class InternEmployee : Employee
    {
        public InternEmployee(string name, string gender, int age, int stipend)
            : base(name, gender, age, stipend)
        {
        }

        public override int CalculateSalary()
        {
            return Salary;
        }
    }
}
