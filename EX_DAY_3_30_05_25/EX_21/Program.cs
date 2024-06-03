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

        double secondLargest = FindSecondLargest(array);
        double secondSmallest = FindSecondSmallest(array);
        Console.WriteLine($"Giá trị lớn thứ hai trong mảng: {secondLargest}");
        Console.WriteLine($"Giá trị nhỏ thứ hai trong mảng: {secondSmallest}");
        Console.ReadKey();
    }

    static double FindSecondLargest(double[] array)
    {
        if (array.Length < 2)
        {
            throw new InvalidOperationException("Mảng phải có ít nhất 2 phần tử.");
        }

        double largest = double.MinValue;
        double secondLargest = double.MinValue;

        foreach (double item in array)
        {
            if (item > largest)
            {
                secondLargest = largest;
                largest = item;
            }
            else if (item > secondLargest && item != largest)
            {
                secondLargest = item;
            }
        }

        return secondLargest;
    }

    static double FindSecondSmallest(double[] array)
    {
        if (array.Length < 2)
        {
            throw new InvalidOperationException("Mảng phải có ít nhất 2 phần tử.");
        }

        double smallest = double.MaxValue;
        double secondSmallest = double.MaxValue;

        foreach (double item in array)
        {
            if (item < smallest)
            {
                secondSmallest = smallest;
                smallest = item;
            }
            else if (item < secondSmallest && item != smallest)
            {
                secondSmallest = item;
            }
        }

        return secondSmallest;
    }

    static void PrintArray(double[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
