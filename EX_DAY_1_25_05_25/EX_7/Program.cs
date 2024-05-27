using System;
using System.Text;

namespace EX_7
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập một số nguyên từ người dùng với kiểm tra đầu vào
            int number = GetValidInteger("Nhập một số nguyên:");

            // Kiểm tra số nguyên tố và hiển thị kết quả
            if (IsPrime(number))
            {
                Console.WriteLine(number + " là số nguyên tố.");
            }
            else
            {
                Console.WriteLine(number + " không phải là số nguyên tố.");
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
