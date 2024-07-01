using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Services
{
    public class BaoCaoService : IBaoCaoService
    {
        private readonly INhanVienService _nhanVienService;
        private readonly ICongDoanService _congDoanService;
        private readonly ExcelExporter _excelExporter;

        public BaoCaoService(INhanVienService nhanVienService, ICongDoanService congDoanService, ExcelExporter excelExporter)
        {
            _nhanVienService = nhanVienService;
            _congDoanService = congDoanService;
            _excelExporter = excelExporter;
        }

        public void HienThiBaoCao()
        {
            var danhSachNhanVien = _nhanVienService.LayTatCaNhanVien();
            foreach (var nhanVien in danhSachNhanVien)
            {
                Console.WriteLine($"ID: {nhanVien.Id}");
                Console.WriteLine($"Tên: {nhanVien.Ten}");
                Console.WriteLine($"Giới tính: {nhanVien.GioiTinh}");
                Console.WriteLine($"Tuổi: {nhanVien.Tuoi}");
                Console.WriteLine($"Lương cơ bản: {nhanVien.LuongCoBan}");
                Console.WriteLine($"Hệ số lương: {nhanVien.HeSoLuong}");
                Console.WriteLine($"Phụ cấp: {nhanVien.PhuCap}");
                Console.WriteLine($"Tổng lương: {nhanVien.TongLuong}");
                Console.WriteLine("Các công đoạn:");

                var danhSachCongDoan = _congDoanService.LayCongDoanCuaNhanVien(nhanVien.Id);
                foreach (var congDoan in danhSachCongDoan)
                {
                    Console.WriteLine($"\tMã công đoạn: {congDoan.MaCongDoan}");
                    Console.WriteLine($"\tTên công đoạn: {congDoan.TenCongDoan}");
                    Console.WriteLine($"\tSố lượng sản phẩm: {congDoan.SoLuongSanPham}");
                    Console.WriteLine($"\tGiá: {congDoan.Gia}");
                    Console.WriteLine($"\tSản lượng: {congDoan.SanLuong}");
                }
            }
        }

        public void XuatBaoCao()
        {
            var danhSachNhanVien = _nhanVienService.LayTatCaNhanVien();
            string filePath = "BaoCao.xlsx";
            _excelExporter.ExportToExcel(danhSachNhanVien, filePath);
            Console.WriteLine($"Báo cáo đã được xuất ra file: {filePath}");
        }
    }
}
