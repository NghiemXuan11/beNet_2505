using System.Text;

namespace EX_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập một số nguyên từ người dùng
            Console.WriteLine("Nhập một số nguyên:");
            int number = Convert.ToInt32(Console.ReadLine());

            // Tính giai thừa của số đã nhập
            long factorial = CalculateFactorial(number);
            Console.WriteLine("Giai thừa của " + number + " là: " + factorial);
        }

        static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Số nhập vào phải là số nguyên không âm.");
            }

            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
