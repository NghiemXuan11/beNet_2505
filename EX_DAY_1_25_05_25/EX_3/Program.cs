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
            // Nhập nhiệt độ độ C từ người dùng
            Console.WriteLine("Nhập nhiệt độ (độ C):");
            double celsius = Convert.ToDouble(Console.ReadLine());

            // Chuyển đổi độ C sang độ K
            double kelvin = CelsiusToKelvin(celsius);
            Console.WriteLine("Nhiệt độ (độ K): " + kelvin);

            // Chuyển đổi độ C sang độ F
            double fahrenheit = CelsiusToFahrenheit(celsius);
            Console.WriteLine("Nhiệt độ (độ F): " + fahrenheit);
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
