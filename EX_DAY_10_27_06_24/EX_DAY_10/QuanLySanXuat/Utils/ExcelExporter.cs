using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace QuanLySanXuat.Utils
{
    public class ExcelExporter
    {
        private readonly ICongDoanService _congDoanService;

        public ExcelExporter(ICongDoanService congDoanService)
        {
            _congDoanService = congDoanService;
        }

        public void ExportToExcel(List<NhanVien> danhSachNhanVien, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Báo cáo");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Tên";
                worksheet.Cells[1, 3].Value = "Giới tính";
                worksheet.Cells[1, 4].Value = "Tuổi";
                worksheet.Cells[1, 5].Value = "Lương cơ bản";
                worksheet.Cells[1, 6].Value = "Hệ số lương";
                worksheet.Cells[1, 7].Value = "Phụ cấp";
                worksheet.Cells[1, 8].Value = "Tổng lương";

                int row = 2;
                foreach (var nhanVien in danhSachNhanVien)
                {
                    worksheet.Cells[row, 1].Value = nhanVien.Id;
                    worksheet.Cells[row, 2].Value = nhanVien.Ten;
                    worksheet.Cells[row, 3].Value = nhanVien.GioiTinh;
                    worksheet.Cells[row, 4].Value = nhanVien.Tuoi;
                    worksheet.Cells[row, 5].Value = nhanVien.LuongCoBan;
                    worksheet.Cells[row, 6].Value = nhanVien.HeSoLuong;
                    worksheet.Cells[row, 7].Value = nhanVien.PhuCap;
                    worksheet.Cells[row, 8].Value = nhanVien.TongLuong;

                    row++;
                }

                package.SaveAs(new FileInfo(filePath));
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }
    }
}
