using System.Text;

namespace EX_7
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

            // Kiểm tra số nguyên tố
            if (IsPrime(number))
            {
                Console.WriteLine(number + " là số nguyên tố.");
            }
            else
            {
                Console.WriteLine(number + " không phải là số nguyên tố.");
            }
        }

        // Hàm kiểm tra số nguyên tố 
        static bool IsPrime(int number)
        {
            if (number < 2) 
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
