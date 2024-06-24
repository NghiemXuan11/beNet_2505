using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EX_1
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public int Age { get; private set; }
        public double MathScore { get; private set; }
        public double PhysicsScore { get; private set; }
        public double ChemistryScore { get; private set; }
        public double AverageScore { get; private set; }
        public string AcademicPerformance { get; private set; }

        public Student(string name, string gender, int age, double mathScore, double physicsScore, double chemistryScore)
        {
            Id = Guid.NewGuid();
            Name = name;
            Gender = gender;
            Age = age;
            MathScore = mathScore;
            PhysicsScore = physicsScore;
            ChemistryScore = chemistryScore;
            AverageScore = CalculateAverageScore();
            AcademicPerformance = DetermineAcademicPerformance();
        }

        private double CalculateAverageScore()
        {
            return (MathScore + PhysicsScore + ChemistryScore) / 3.0;
        }

        private string DetermineAcademicPerformance()
        {
            if (AverageScore >= 8)
                return "Giỏi";
            if (AverageScore >= 6.5)
                return "Khá";
            if (AverageScore >= 5)
                return "Trung Bình";
            return "Yếu";
        }

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        public static bool ValidateGender(string gender)
        {
            return gender == "Nam" || gender == "Nữ";
        }

        public static bool ValidateAge(string ageStr)
        {
            return int.TryParse(ageStr, out _);
        }

        public static bool ValidateScore(string scoreStr)
        {
            if (double.TryParse(scoreStr, out double score))
            {
                return score >= 0 && score <= 10;
            }
            return false;
        }
    }
}
