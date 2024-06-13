using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        List<int> numbers = new List<int>();

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

        Console.WriteLine("Nhập các số nguyên:");

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

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số nguyên. Vui lòng nhập lại.");
                    continue;
                }

                numbers.Add(number);
                break;
            }
        }

        List<int> oddNumbers = new List<int>();
        int sumOddNumbers = 0;

        foreach (int number in numbers)
        {
            if (number % 2 != 0)
            {
                oddNumbers.Add(number);
                sumOddNumbers += number;
            }
        }

        Console.WriteLine("Các số lẻ trong mảng là: " + string.Join(", ", oddNumbers));
        Console.WriteLine($"Tổng các số lẻ là: {sumOddNumbers}");
        Console.ReadKey();
    }
}
