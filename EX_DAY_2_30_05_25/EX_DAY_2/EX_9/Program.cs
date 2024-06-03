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

        // Sắp xếp mảng theo thứ tự tăng dần
        List<int> sortedAscending = new List<int>(numbers);
        sortedAscending.Sort();

        // Sắp xếp mảng theo thứ tự giảm dần
        List<int> sortedDescending = new List<int>(numbers);
        sortedDescending.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine("Mảng sắp xếp tăng dần: " + string.Join(", ", sortedAscending));
        Console.WriteLine("Mảng sắp xếp giảm dần: " + string.Join(", ", sortedDescending));
    }
}
