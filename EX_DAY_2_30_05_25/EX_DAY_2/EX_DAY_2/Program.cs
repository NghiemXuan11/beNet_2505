using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_DAY_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<int> numbers = new List<int>();

            Console.WriteLine("Nhập các số nguyên (nhập 'done' để kết thúc):");
            int i = 0;
            while (true)
            {
                Console.Write("Nhập số" + " thứ " + i + " : ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

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
                i++;
            }

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }

            Console.WriteLine("Mảng số chẵn: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Mảng số lẻ: " + string.Join(", ", oddNumbers));
            Console.ReadKey();
        }
    }
}
