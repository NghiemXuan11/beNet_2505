using System;
using System.Text;

class Program
{
    static void Main()
    {
        int[] array;
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

        array = new int[numberOfElements];

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

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số nguyên. Vui lòng nhập lại.");
                    continue;
                }

                array[i] = number;
                break;
            }
        }

        Console.WriteLine("Mảng đã nhập:");
        PrintArray(array);

        Console.WriteLine("Các số lẻ trong mảng:");
        PrintOddNumbers(array);

        Console.WriteLine("Các số chẵn trong mảng:");
        PrintEvenNumbers(array);
        Console.ReadKey();
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void PrintOddNumbers(int[] array)
    {
        foreach (var item in array)
        {
            if (item % 2 != 0)
            {
                Console.Write(item + " ");
            }
        }
        Console.WriteLine();
    }

    static void PrintEvenNumbers(int[] array)
    {
        foreach (var item in array)
        {
            if (item % 2 == 0)
            {
                Console.Write(item + " ");
            }
        }
        Console.WriteLine();
    }
}
