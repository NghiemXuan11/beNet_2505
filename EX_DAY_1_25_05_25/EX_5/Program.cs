using System.Text;

namespace EX_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập số nguyên dương n từ người dùng
            Console.WriteLine("Nhập số nguyên dương n:");
            int n = Convert.ToInt32(Console.ReadLine());

            // Kiểm tra tính hợp lệ của n
            if (n <= 1)
            {
                Console.WriteLine("Không có số nguyên tố nào nhỏ hơn " + n);
            }
            else
            {
                // Liệt kê các số nguyên tố nhỏ hơn n
                Console.WriteLine("Các số nguyên tố nhỏ hơn " + n + " là:");
                for (int i = 2; i < n; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        //Hàm kiểm tra số nguyên tố
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
