using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Models;
using QuanLySanXuat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Managers
{
    public class NhanVienManager
    {
        private readonly INhanVienService _nhanVienService;

        public NhanVienManager(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        public void ThemNhanVien()
        {
            try
            {
                var nhanVien = new NhanVien();
                Console.Write("Nhập tên: ");
                nhanVien.Ten = Console.ReadLine();
                Validator.ValidateTen(nhanVien.Ten);

                Console.Write("Nhập giới tính (Nam/Nữ): ");
                nhanVien.GioiTinh = Console.ReadLine();
                Validator.ValidateGioiTinh(nhanVien.GioiTinh);

                Console.Write("Nhập tuổi: ");
                nhanVien.Tuoi = int.Parse(Console.ReadLine());
                Validator.ValidateTuoi(nhanVien.Tuoi);

                Console.Write("Nhập lương cơ bản: ");
                nhanVien.LuongCoBan = double.Parse(Console.ReadLine());

                Console.Write("Nhập hệ số lương: ");
                nhanVien.HeSoLuong = double.Parse(Console.ReadLine());

                Console.Write("Nhập phụ cấp: ");
                nhanVien.PhuCap = double.Parse(Console.ReadLine());

                nhanVien.TongLuong = nhanVien.LuongCoBan * nhanVien.HeSoLuong + nhanVien.PhuCap;

                _nhanVienService.ThemNhanVien(nhanVien);
                Console.WriteLine("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}
