using System;
using System.Text;

namespace EX_6
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập một số nguyên từ người dùng với kiểm tra đầu vào
            int number = GetValidInteger("Nhập một số nguyên:");

            // Kiểm tra số chẵn hay số lẻ và hiển thị kết quả
            if (IsEven(number))
            {
                Console.WriteLine(number + " là số chẵn.");
            }
            else
            {
                Console.WriteLine(number + " là số lẻ.");
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

        // Hàm kiểm tra số chẵn
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Hàm kiểm tra số lẻ
        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
