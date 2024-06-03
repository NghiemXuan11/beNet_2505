using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        int number;
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        while (true)
        {
            Console.Write("Nhập một số nguyên: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Dữ liệu nhập vào không được trống. Vui lòng nhập lại.");
                continue;
            }

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        string numberInWords = NumberToWords(number);
        Console.WriteLine($"Số {number} bằng chữ: {numberInWords}");
        Console.ReadKey();
    }

    static string NumberToWords(int number)
    {
        if (number == 0)
            return "không";

        if (number < 0)
            return "âm " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " triệu ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " nghìn ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " trăm ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "và ";

            var unitsMap = new[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            var tensMap = new[] { "không", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

            if (number < 10)
                words += unitsMap[number];
            else if (number < 20)
                words += "mười " + unitsMap[number - 10];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }

        return words.Trim(); 
    }
}

