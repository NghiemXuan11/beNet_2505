using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        int numberOfElements;
        while (true)
        {
            Console.Write("Nhập số lượng phần tử trong mảng: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input, out numberOfElements) || numberOfElements <= 0)
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên dương. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        Console.WriteLine("Nhập các số nguyên hoặc số thực:");

        for (int i = 0; i < numberOfElements; i++)
        {
            while (true)
            {
                Console.Write($"Nhập số thứ {i + 1}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                    continue;
                }

                if (!double.TryParse(input, out double number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số thực. Vui lòng nhập lại.");
                    continue;
                }

                numbers.Add(number);
                break;
            }
        }

        double sum = CalculateSum(numbers);
        Console.WriteLine($"Tổng của dãy số là: {sum}");
        Console.ReadKey();
    }

    static double CalculateSum(List<double> numbers)
    {
        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }
        return sum;
    }
}
