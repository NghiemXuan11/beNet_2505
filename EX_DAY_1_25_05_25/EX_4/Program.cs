using System;
using System.Text;

namespace EX_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập một số nguyên từ người dùng với kiểm tra đầu vào
            int number = GetValidInteger("Nhập một số nguyên:");

            // Tính giai thừa của số đã nhập
            long factorial = CalculateFactorial(number);
            Console.WriteLine("Giai thừa của " + number + " là: " + factorial);
        }

        // Hàm nhập và kiểm tra tính hợp lệ của số nguyên
        static int GetValidInteger(string prompt)
        {
            int number;
            string input;
            while (true)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                // Kiểm tra dữ liệu nhập vào không được trống
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Dữ liệu nhập vào không được để trống. Vui lòng thử lại.");
                    continue;
                }

                // Kiểm tra dữ liệu nhập vào có phải là số nguyên hay không
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là một số nguyên. Vui lòng thử lại.");
                    continue;
                }

                return number;
            }
        }

        static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Số nhập vào phải là số nguyên không âm.");
            }

            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
