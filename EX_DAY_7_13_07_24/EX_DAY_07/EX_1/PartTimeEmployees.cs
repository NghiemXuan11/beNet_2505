using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class PartTimeEmployee : Employee
    {
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }

        public PartTimeEmployee(string name, string gender, int age, int hourlyRate, int hoursWorked)
            : base(name, gender, age, hourlyRate * hoursWorked)
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        public override int CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
}
