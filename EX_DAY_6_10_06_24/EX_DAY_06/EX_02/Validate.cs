using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EX_02
{
    internal class Validate
    {
        public static bool KiemTraID(string input, Dictionary<int, SinhVien> dsSinhVien, out string errorMessage)
        {
            errorMessage = null;

            if (!int.TryParse(input, out int id))
            {
                errorMessage = "ID phải là một số nguyên.";
                return false;
            }

            if (id < 0)
            {
                errorMessage = "ID phải lớn hơn hoặc bằng 0.";
                return false;
            }

            if (dsSinhVien.ContainsKey(id))
            {
                errorMessage = "ID đã tồn tại trong danh sách.";
                return false;
            }

            return true;
        }

        public static bool KiemTraTen(string input, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Tên không được để trống.";
                return false;
            }

            if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            {
                errorMessage = "Tên không được chứa ký tự đặc biệt.";
                return false;
            }

            return true;
        }

        public static bool KiemTraDiem(string input, out string errorMessage)
        {
            errorMessage = null;

            if (!double.TryParse(input, out double diem))
            {
                errorMessage = "Điểm phải là một số thực.";
                return false;
            }

            if (diem < 0 || diem > 10)
            {
                errorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.";
                return false;
            }

            return true;
        }
    }
}
