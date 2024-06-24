using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
    public interface IStudentManager
    {
        void AddStudent(Student student);
        void UpdateStudent(Guid id, string name, string gender, int age, double mathScore, double physicsScore, double chemistryScore);
        void DeleteStudent(Guid id);
        void DeleteMultipleStudents(List<Guid> ids);
        List<Student> SortStudents(string criteria);
        List<Student> GetAllStudents();
    }
}
