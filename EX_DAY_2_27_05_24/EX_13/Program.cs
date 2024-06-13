using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        List<double> numbers = new List<double>();

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

        Console.WriteLine("Nhập các số thực:");

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

        double[] numbersArray = numbers.ToArray();

        double max;
        FindMaxValue(numbersArray, out max);
        Console.WriteLine($"Giá trị lớn nhất trong mảng là: {max}");

        Console.ReadKey();
    }

    static void FindMaxValue(double[] array, out double maxValue)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Mảng không được rỗng");
        }

        maxValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
        }
    }
}
