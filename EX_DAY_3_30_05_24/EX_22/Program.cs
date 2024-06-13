using System;
using System.Text;

class Program
{
    static void Main()
    {
        double[] array;
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

        int start = 0, end = 0;
        double maxSum = double.MinValue;
        double currentSum = 0;

        for (int i = 0; i < numberOfElements; i++)
        {
            currentSum += array[i];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                end = i;
            }

            if (currentSum < 0)
            {
                currentSum = 0;
                start = i + 1;
            }
        }

        Console.WriteLine("Mảng con có tổng lớn nhất:");
        PrintSubArray(array, start, end);
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

    static void PrintSubArray(double[] array, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
