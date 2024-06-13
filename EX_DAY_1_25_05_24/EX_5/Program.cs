using System;
using System.Text;

namespace EX_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập số nguyên dương n từ người dùng với kiểm tra đầu vào
            int n = GetValidInteger("Nhập số nguyên dương n:");

            // Kiểm tra tính hợp lệ của n
            if (n <= 1)
            {
                Console.WriteLine("Không có số nguyên tố nào nhỏ hơn " + n);
            }
            else
            {
                // Liệt kê các số nguyên tố nhỏ hơn n
                Console.WriteLine("Các số nguyên tố nhỏ hơn " + n + " là:");
                for (int i = 2; i < n; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine();
            }
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

        // Hàm kiểm tra số nguyên tố
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
