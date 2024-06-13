using System;
using System.Text;

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

            // Nhập a với kiểm tra đầu vào
            double a = GetValidNumber("Nhập a:");

            // Nhập b với kiểm tra đầu vào
            double b = GetValidNumber("Nhập b:");

            // Kiểm tra và giải phương trình
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