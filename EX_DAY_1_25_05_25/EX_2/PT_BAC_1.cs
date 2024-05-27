using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public class PT_BAC_1
    {
        public void GIAI_PT_BAC_1()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Giải phương trình bậc 1: ax + b = 0
            Console.WriteLine("Giải phương trình bậc 1: ax + b = 0");

            Console.WriteLine("Nhập a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập b:");
            double b = Convert.ToDouble(Console.ReadLine());

            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Phương trình vô số nghiệm.");
                }
                else
                {
                    Console.WriteLine("Phương trình vô nghiệm.");
                }
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("Nghiệm của phương trình là: x = " + x);
            }
        }
    }
}

