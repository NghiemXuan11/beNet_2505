using System;
using System.Text;

namespace EX_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập nhiệt độ độ C từ người dùng với kiểm tra đầu vào
            double celsius = GetValidNumber("Nhập nhiệt độ (độ C):");

            // Chuyển đổi độ C sang độ K
            double kelvin = CelsiusToKelvin(celsius);
            Console.WriteLine("Nhiệt độ (độ K): " + kelvin);

            // Chuyển đổi độ C sang độ F
            double fahrenheit = CelsiusToFahrenheit(celsius);
            Console.WriteLine("Nhiệt độ (độ F): " + fahrenheit);
        }

        // Hàm nhập và kiểm tra tính hợp lệ của số
        static double GetValidNumber(string prompt)
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
                    Console.WriteLine("Dữ liệu nhập vào không được để trống. Vui lòng thử lại.");
                    continue;
                }

                // Kiểm tra dữ liệu nhập vào có phải là số hay không
                if (!double.TryParse(input, out number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là một số. Vui lòng thử lại.");
                    continue;
                }

                return number;
            }
        }

        // Hàm chuyển đổi độ C sang độ K
        static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273;
        }

        // Hàm chuyển đổi độ C sang độ F
        static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 18 / 10 + 32;
        }
    }
}
