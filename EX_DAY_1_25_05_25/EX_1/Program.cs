using System;
using System.Text;
class Program
{
    static void Main()
    {   
        //Nhập, Xuất dữ liệu là tiếng Việt
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        // Nhập hai số từ người dùng
        Console.WriteLine("Nhập số thứ nhất:");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập số thứ hai:");
        double number2 = Convert.ToDouble(Console.ReadLine());

        // Tính tổng hai số
        double sum = number1 + number2;
        Console.WriteLine("Tổng hai số là: " + sum);

        // Tính tích hai số
        double product = number1 * number2;
        Console.WriteLine("Tích hai số là: " + product);

        // Tính hiệu hai số
        double difference = number1 - number2;
        Console.WriteLine("Hiệu hai số là: " + difference);
    }
}