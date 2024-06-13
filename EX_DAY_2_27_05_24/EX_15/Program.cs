using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        int[] array;

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

        int index;
        while (true)
        {
            Console.Write("Nhập chỉ số của phần tử cần thay đổi (từ 0 đến {0}): ", array.Length - 1);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input, out index) || index < 0 || index >= array.Length)
            {
                Console.WriteLine("Chỉ số không hợp lệ. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        int newValue;
        while (true)
        {
            Console.Write("Nhập giá trị mới: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input, out newValue))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        ChangeArrayElement(array, index, newValue, out int updatedValue);

        Console.WriteLine($"Phần tử đã được thay đổi: {updatedValue}");
        Console.WriteLine("Mảng sau khi thay đổi:");
        PrintArray(array);
        Console.ReadKey();
    }

    static void ChangeArrayElement(int[] array, int index, int newValue, out int updatedValue)
    {
        if (array == null || index < 0 || index >= array.Length)
        {
            throw new ArgumentException("Mảng hoặc chỉ số không hợp lệ.");
        }

        updatedValue = array[index] = newValue;
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
