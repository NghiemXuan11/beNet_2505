using System.Text;

namespace EX_1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Nhập số thứ nhất từ người dùng với kiểm tra đầu vào
            double number1 = GetValidNumber("Nhập số thứ nhất:");

            // Nhập số thứ hai từ người dùng với kiểm tra đầu vào
            double number2 = GetValidNumber("Nhập số thứ hai:");

            // Tính tổng hai số
            double sum = number1 + number2;
            Console.WriteLine("Tổng hai số là: " + sum);

            // Tính tích hai số
            double product = number1 * number2;
            Console.WriteLine("Tích hai số là: " + product);

            // Tính hiệu hai số
            double difference = number1 - number2;
            Console.WriteLine("Hiệu hai số là: " + difference);
        }

        // Hàm nhập và kiểm tra tính hợp lệ của số
        static double GetValidNumber(string prompt)
        {
            double number;
            string input;
            while (true)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                // Kiểm tra dữ liệu nhập vào không được trống
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Dữ liệu nhập vào không được để trống. Vui lòng thử lại.\n");
                    continue;
                }

                // Kiểm tra dữ liệu nhập vào có phải là số hay không
                if (!double.TryParse(input, out number))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là một số. Vui lòng thử lại.\n");
                    continue;
                }

                return number;
            }
        }
    
    }    
}
