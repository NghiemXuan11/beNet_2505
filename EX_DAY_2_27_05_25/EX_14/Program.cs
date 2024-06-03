using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        int a, b;

        // Nhập số thứ nhất
        while (true)
        {
            Console.Write("Nhập số thứ nhất: ");
            string input1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input1))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input1, out a))
            {
                Console.WriteLine("Dữ liệu nhập vào không phải là số nguyên. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        // Nhập số thứ hai
        while (true)
        {
            Console.Write("Nhập số thứ hai: ");
            string input2 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input2))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input2, out b))
            {
                Console.WriteLine("Dữ liệu nhập vào không phải là số nguyên. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        Console.WriteLine($"Trước khi hoán đổi: a = {a}, b = {b}");

        SwapWithOut(a, b, out a, out b);

        Console.WriteLine($"Sau khi hoán đổi: a = {a}, b = {b}");
        Console.ReadKey();
    }

    static void SwapWithOut(int x, int y, out int resultX, out int resultY)
    {
        resultX = y;
        resultY = x;
    }
}
