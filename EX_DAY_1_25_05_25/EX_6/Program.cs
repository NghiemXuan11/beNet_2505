using System.Text;

namespace EX_6
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập một số nguyên từ người dùng
            Console.WriteLine("Nhập một số nguyên:");
            int number = Convert.ToInt32(Console.ReadLine());

            // Kiểm tra số chẵn hay số lẻ
            if (IsEven(number))
            {
                Console.WriteLine(number + " là số chẵn.");
            }
            else
            {
                Console.WriteLine(number + " là số lẻ.");
            }
        }

        // Hàm kiểm tra số chẵn
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Hàm kiểm tra số lẻ
        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
