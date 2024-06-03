using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        double[] array;

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

        array = new double[numberOfElements];

        Console.WriteLine("Nhập các phần tử của mảng:");

        for (int i = 0; i < numberOfElements; i++)
        {
            while (true)
            {
                Console.Write($"Nhập phần tử thứ {i + 1}: ");
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

                array[i] = number;
                break;
            }
        }

        Console.WriteLine("Mảng đã nhập:");
        PrintArray(array);

        double sum = CalculateSum(array);
        Console.WriteLine($"Tổng các phần tử trong mảng: {sum}");
        Console.ReadKey();
    }

    static void PrintArray(double[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static double CalculateSum(double[] array)
    {
        double sum = 0;
        foreach (var item in array)
        {
            sum += item;
        }
        return sum;
    }
}
