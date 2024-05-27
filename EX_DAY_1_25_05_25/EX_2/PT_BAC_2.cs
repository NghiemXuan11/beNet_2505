using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    internal class PT_BAC_2
    {
        public void GIAI_PT_BAC_2()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Giải phương trình bậc 2: ax^2 + bx + c = 0
            Console.WriteLine("Giải phương trình bậc 2: ax^2 + bx + c = 0");

            Console.WriteLine("Nhập a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập c:");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a == 0)
            {
                // Nếu a = 0, phương trình trở thành bậc 1: bx + c = 0
                if (b == 0)
                {
                    if (c == 0)
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
                    double x = -c / b;
                    Console.WriteLine("Nghiệm của phương trình bậc 1 là: x = " + x);
                }
            }
            else
            {
                // Tính delta
                double delta = b * b - 4 * a * c;

                if (delta < 0)
                {
                    Console.WriteLine("Phương trình vô nghiệm.");
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine("Phương trình có nghiệm kép: x1 = x2 = " + x);
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("Phương trình có hai nghiệm phân biệt: x1 = " + x1 + ", x2 = " + x2);
                }
            }
        }

        // Hàm nhập và kiểm tra tính hợp lệ của số
        private double GetValidNumber(string prompt)
        {
            double number;
            string input;
            while (true)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                // Kiểm tra dữ liệu nhập vào không được trống
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Dữ liệu nhập vào không được để trống. Vui lòng thử lại.\n");
                    continue;
                }

                // Kiểm tra dữ liệu nhập vào có phải là số hay không
                if (!double.TryParse(input, out number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là một số. Vui lòng thử lại.\n");
                    continue;
                }

                return number;
            }
        }
    }
}
