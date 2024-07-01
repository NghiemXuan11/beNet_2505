using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Managers
{
    public class CongDoanManager
    {
        private readonly ICongDoanService _congDoanService;
        private readonly INhanVienService _nhanVienService;

        public CongDoanManager(ICongDoanService congDoanService, INhanVienService nhanVienService)
        {
            _congDoanService = congDoanService;
            _nhanVienService = nhanVienService;
        }

        public void TaoSanLuong()
        {
            try
            {
                Console.Write("Nhập ID nhân viên: ");
                Guid nhanVienId = Guid.Parse(Console.ReadLine());
                var nhanVien = _nhanVienService.TimKiemNhanVien(nhanVienId);

                if (nhanVien == null)
                {
                    Console.WriteLine("Không tìm thấy nhân viên.");
                    return;
                }

                var congDoan = new CongDoan();
                congDoan.NhanVienId = nhanVienId;

                Console.Write("Nhập mã công đoạn: ");
                congDoan.MaCongDoan = Console.ReadLine();

                Console.Write("Nhập tên công đoạn: ");
                congDoan.TenCongDoan = Console.ReadLine();

                Console.Write("Nhập số lượng sản phẩm: ");
                congDoan.SoLuongSanPham = int.Parse(Console.ReadLine());

                Console.Write("Nhập giá: ");
                congDoan.Gia = double.Parse(Console.ReadLine());

                _congDoanService.ThemCongDoan(congDoan);
                Console.WriteLine("Tạo sản lượng thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}
