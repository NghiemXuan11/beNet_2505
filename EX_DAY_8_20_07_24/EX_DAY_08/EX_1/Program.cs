using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace EX_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentManager studentManager = new StudentManager();
            while (true)
            {
                Console.WriteLine("1. Thêm sinh viên từ bàn phím");
                Console.WriteLine("2. Thêm sinh viên từ file Excel");
                Console.WriteLine("3. Sắp xếp sinh viên");
                Console.WriteLine("4. Cập nhật thông tin sinh viên");
                Console.WriteLine("5. Xóa sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudentFromKeyboard(studentManager);
                        break;
                    case 2:
                        AddStudentsFromExcel(studentManager);
                        break;
                    case 3:
                        SortStudents(studentManager);
                        break;
                    case 4:
                        UpdateStudent(studentManager);
                        break;
                    case 5:
                        DeleteStudents(studentManager);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ.");
                        break;
                }
            }
        }

        static void AddStudentFromKeyboard(IStudentManager studentManager)
        {
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            string gender = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            string ageStr = Console.ReadLine();
            Console.Write("Nhập điểm Toán: ");
            string mathScoreStr = Console.ReadLine();
            Console.Write("Nhập điểm Lý: ");
            string physicsScoreStr = Console.ReadLine();
            Console.Write("Nhập điểm Hóa: ");
            string chemistryScoreStr = Console.ReadLine();

            if (!Student.ValidateName(name) || !Student.ValidateGender(gender) || !Student.ValidateAge(ageStr) || !Student.ValidateScore(mathScoreStr) || !Student.ValidateScore(physicsScoreStr) || !Student.ValidateScore(chemistryScoreStr))
            {
                Console.WriteLine("Thông tin sinh viên không hợp lệ.");
                return;
            }

            int age = int.Parse(ageStr);
            double mathScore = double.Parse(mathScoreStr);
            double physicsScore = double.Parse(physicsScoreStr);
            double chemistryScore = double.Parse(chemistryScoreStr);

            var student = new Student(name, gender, age, mathScore, physicsScore, chemistryScore);
            studentManager.AddStudent(student);
            Console.WriteLine("Thêm sinh viên thành công.");
        }

        static void AddStudentsFromExcel(IStudentManager studentManager)
        {
            Console.Write("Nhập đường dẫn file Excel: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File không tồn tại.");
                return;
            }

            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string gender = reader.GetString(1);
                            string ageStr = reader.GetString(2);
                            string mathScoreStr = reader.GetString(3);
                            string physicsScoreStr = reader.GetString(4);
                            string chemistryScoreStr = reader.GetString(5);

                            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(ageStr) || string.IsNullOrWhiteSpace(mathScoreStr) || string.IsNullOrWhiteSpace(physicsScoreStr) || string.IsNullOrWhiteSpace(chemistryScoreStr) ||
                                !Student.ValidateName(name) || !Student.ValidateGender(gender) || !Student.ValidateAge(ageStr) || !Student.ValidateScore(mathScoreStr) || !Student.ValidateScore(physicsScoreStr) || !Student.ValidateScore(chemistryScoreStr))
                            {
                                Console.WriteLine($"Thông tin sinh viên không hợp lệ tại dòng {reader.Depth + 1}");
                                continue;
                            }

                            int age = int.Parse(ageStr);
                            double mathScore = double.Parse(mathScoreStr);
                            double physicsScore = double.Parse(physicsScoreStr);
                            double chemistryScore = double.Parse(chemistryScoreStr);

                            var student = new Student(name, gender, age, mathScore, physicsScore, chemistryScore);
                            studentManager.AddStudent(student);
                        }
                    }
                }
                Console.WriteLine("Thêm sinh viên từ file Excel thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        static void SortStudents(IStudentManager studentManager)
        {
            Console.WriteLine("Chọn tiêu chí sắp xếp (name, academicperformance, averagescore): ");
            string criteria = Console.ReadLine();
            var sortedStudents = studentManager.SortStudents(criteria);
            Console.WriteLine("Danh sách sinh viên sau khi sắp xếp:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Name} - {student.AverageScore} - {student.AcademicPerformance}");
            }
        }

        static void UpdateStudent(IStudentManager studentManager)
        {
            Console.Write("Nhập ID sinh viên cần cập nhật: ");
            Guid id = Guid.Parse(Console.ReadLine());
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            string gender = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            string ageStr = Console.ReadLine();
            Console.Write("Nhập điểm Toán: ");
            string mathScoreStr = Console.ReadLine();
            Console.Write("Nhập điểm Lý: ");
            string physicsScoreStr = Console.ReadLine();
            Console.Write("Nhập điểm Hóa: ");
            string chemistryScoreStr = Console.ReadLine();

            if (!Student.ValidateName(name) || !Student.ValidateGender(gender) || !Student.ValidateAge(ageStr) || !Student.ValidateScore(mathScoreStr) || !Student.ValidateScore(physicsScoreStr) || !Student.ValidateScore(chemistryScoreStr))
            {
                Console.WriteLine("Thông tin sinh viên không hợp lệ.");
                return;
            }

            int age = int.Parse(ageStr);
            double mathScore = double.Parse(mathScoreStr);
            double physicsScore = double.Parse(physicsScoreStr);
            double chemistryScore = double.Parse(chemistryScoreStr);

            studentManager.UpdateStudent(id, name, gender, age, mathScore, physicsScore, chemistryScore);
            Console.WriteLine("Cập nhật sinh viên thành công.");
        }

        static void DeleteStudents(IStudentManager studentManager)
        {
            Console.Write("Nhập ID các sinh viên cần xóa (phân tách bởi dấu phẩy): ");
            string[] idsStr = Console.ReadLine().Split(',');
            List<Guid> ids = new List<Guid>();
            foreach (var idStr in idsStr)
            {
                if (Guid.TryParse(idStr, out Guid id))
                {
                    ids.Add(id);
                }
            }

            studentManager.DeleteMultipleStudents(ids);
            Console.WriteLine("Xóa sinh viên thành công.");
        }
    }
}
