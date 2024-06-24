using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public class StudentManager : IStudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (students.Any(s => s.Name == student.Name))
            {
                throw new Exception("Sinh viên đã tồn tại.");
            }
            students.Add(student);
        }

        public void UpdateStudent(Guid id, string name, string gender, int age, double mathScore, double physicsScore, double chemistryScore)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new Exception("Không tìm thấy sinh viên.");
            }
            students.Remove(student);
            students.Add(new Student(name, gender, age, mathScore, physicsScore, chemistryScore));
        }

        public void DeleteStudent(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }

        public void DeleteMultipleStudents(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                DeleteStudent(id);
            }
        }

        public List<Student> SortStudents(string criteria)
        {
            switch (criteria.ToLower())
            {
                case "name":
                    return students.OrderBy(s => s.Name).ToList();
                case "academicperformance":
                    return students.OrderByDescending(s => s.AverageScore).ToList();
                case "averagescore":
                    return students.OrderByDescending(s => s.AverageScore).ToList();
                default:
                    throw new Exception("Tiêu chí sắp xếp không hợp lệ.");
            }
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students);
        }
    }
}
