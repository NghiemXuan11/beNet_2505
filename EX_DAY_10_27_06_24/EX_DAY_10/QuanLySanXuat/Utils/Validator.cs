using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLySanXuat.Utils
{
    public static class Validator
    {
        private static readonly Regex nameRegex = new Regex("^[a-zA-Z0-9 ]*$");
        private static readonly Regex genderRegex = new Regex("^(Nam|nam|Nữ|nữ)$");

        public static void ValidateTen(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten) || !nameRegex.IsMatch(ten))
                throw new ArgumentException("Tên không được để trống và không chứa ký tự đặc biệt.");
        }

        public static void ValidateGioiTinh(string gioiTinh)
        {
            if (!genderRegex.IsMatch(gioiTinh))
                throw new ArgumentException("Giới tính phải là 'Nam', 'nam', 'Nữ' hoặc 'nữ'.");
        }

        public static void ValidateTuoi(int tuoi)
        {
            if (tuoi < 22 || tuoi > 60)
                throw new ArgumentException("Tuổi phải nằm trong khoảng từ 22 đến 60.");
        }
    }
}
