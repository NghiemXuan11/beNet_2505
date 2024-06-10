using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;

struct Employee
{
    public int MaNhanVien;
    public string TenNhanVien;
    public DateTime NgayVaoCongTy;
    public double HeSoLuong;
    public string ViTriCongViec;

    public Employee(int maNhanVien, string tenNhanVien, DateTime ngayVaoCongTy, double heSoLuong, string viTriCongViec)
    {
        MaNhanVien = maNhanVien;
        TenNhanVien = tenNhanVien;
        NgayVaoCongTy = ngayVaoCongTy;
        HeSoLuong = heSoLuong;
        ViTriCongViec = viTriCongViec;
    }

    public override string ToString()
    {
        return $"ID: {MaNhanVien}, Tên: {TenNhanVien}, Ngày vào công ty: {NgayVaoCongTy.ToString("dd/MM/yyyy")}, Hệ số lương: {HeSoLuong}, Vị trí: {ViTriCongViec}";
    }
}

class Program
{
    static List<Employee> danhSachNhanVien = new List<Employee>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        while (true)
        {
            Console.WriteLine("Chọn chức năng:");
            Console.WriteLine("1. Nhập danh sách nhân viên từ bàn phím");
            Console.WriteLine("2. Nhập danh sách nhân viên từ file Excel");
            Console.WriteLine("3. Hiển thị danh sách nhân viên");
            Console.WriteLine("4. Xuất danh sách nhân viên theo mốc 5 năm và 10 năm ra file Excel");
            Console.WriteLine("5. Thoát");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NhapDanhSachNhanVien();
                    break;
                case "2":
                    NhapDanhSachNhanVienTuFileExcel();
                    break;
                case "3":
                    HienThiDanhSachNhanVien();
                    break;
                case "4":
                    XuatDanhSachNhanVienTheoMocNam();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }

    static void NhapDanhSachNhanVien()
    {
        danhSachNhanVien.Clear();
        while (true)
        {
            Console.WriteLine("Nhập thông tin nhân viên (hoặc nhập 'exit' để dừng):");

            int maNhanVien = NhapSoNguyen("Mã nhân viên");
            if (maNhanVien == -1) break;

            string tenNhanVien = NhapChuoi("Tên nhân viên");
            if (tenNhanVien.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

            DateTime ngayVaoCongTy = NhapNgay("Ngày vào công ty (dd/MM/yyyy)");
            double heSoLuong = NhapSoThuc("Hệ số lương");
            string viTriCongViec = NhapChuoi("Vị trí công việc");

            Employee nv = new Employee(maNhanVien, tenNhanVien, ngayVaoCongTy, heSoLuong, viTriCongViec);
            danhSachNhanVien.Add(nv);
        }
    }

    static void NhapDanhSachNhanVienTuFileExcel()
    {
        Console.WriteLine("Nhập đường dẫn file Excel:");
        string filePath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.WriteLine("Đường dẫn file không hợp lệ.");
            return;
        }

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Thiết lập LicenseContext

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null || worksheet.Dimension == null)
            {
                Console.WriteLine("File Excel không có dữ liệu hoặc không có bảng tính hợp lệ.");
                return;
            }

            int rowCount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    int maNhanVien = int.Parse(worksheet.Cells[row, 1].Text);
                    string tenNhanVien = worksheet.Cells[row, 2].Text;
                    DateTime ngayVaoCongTy = DateTime.ParseExact(worksheet.Cells[row, 3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    double heSoLuong = double.Parse(worksheet.Cells[row, 4].Text);
                    string viTriCongViec = worksheet.Cells[row, 5].Text;

                    Employee nv = new Employee(maNhanVien, tenNhanVien, ngayVaoCongTy, heSoLuong, viTriCongViec);
                    danhSachNhanVien.Add(nv);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi ở dòng {row}: {ex.Message}");
                }
            }
        }
    }

    static void HienThiDanhSachNhanVien()
    {
        if (danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Danh sách nhân viên trống.");
            return;
        }

        Console.WriteLine("Danh sách nhân viên:");
        foreach (var nv in danhSachNhanVien)
        {
            Console.WriteLine(nv);
        }
    }

    static void XuatDanhSachNhanVienTheoMocNam()
    {
        if (danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Danh sách nhân viên trống.");
            return;
        }

        var nhanVien5Nam = danhSachNhanVien.Where(nv => (DateTime.Now - nv.NgayVaoCongTy).TotalDays / 365 >= 5 && (DateTime.Now - nv.NgayVaoCongTy).TotalDays / 365 < 10).ToList();
        var nhanVien10Nam = danhSachNhanVien.Where(nv => (DateTime.Now - nv.NgayVaoCongTy).TotalDays / 365 >= 10).ToList();

        using (var package = new ExcelPackage())
        {
            var worksheet5Nam = package.Workbook.Worksheets.Add("5 Nam");
            worksheet5Nam.Cells[1, 1].Value = "Mã nhân viên";
            worksheet5Nam.Cells[1, 2].Value = "Tên nhân viên";
            worksheet5Nam.Cells[1, 3].Value = "Ngày vào công ty";
            worksheet5Nam.Cells[1, 4].Value = "Hệ số lương";
            worksheet5Nam.Cells[1, 5].Value = "Vị trí công việc";

            for (int i = 0; i < nhanVien5Nam.Count; i++)
            {
                var nv = nhanVien5Nam[i];
                worksheet5Nam.Cells[i + 2, 1].Value = nv.MaNhanVien;
                worksheet5Nam.Cells[i + 2, 2].Value = nv.TenNhanVien;
                worksheet5Nam.Cells[i + 2, 3].Value = nv.NgayVaoCongTy.ToString("dd/MM/yyyy");
                worksheet5Nam.Cells[i + 2, 4].Value = nv.HeSoLuong;
                worksheet5Nam.Cells[i + 2, 5].Value = nv.ViTriCongViec;
            }

            var worksheet10Nam = package.Workbook.Worksheets.Add("10 Nam");
            worksheet10Nam.Cells[1, 1].Value = "Mã nhân viên";
            worksheet10Nam.Cells[1, 2].Value = "Tên nhân viên";
            worksheet10Nam.Cells[1, 3].Value = "Ngày vào công ty";
            worksheet10Nam.Cells[1, 4].Value = "Hệ số lương";
            worksheet10Nam.Cells[1, 5].Value = "Vị trí công việc";

            for (int i = 0; i < nhanVien10Nam.Count; i++)
            {
                var nv = nhanVien10Nam[i];
                worksheet10Nam.Cells[i + 2, 1].Value = nv.MaNhanVien;
                worksheet10Nam.Cells[i + 2, 2].Value = nv.TenNhanVien;
                worksheet10Nam.Cells[i + 2, 3].Value = nv.NgayVaoCongTy.ToString("dd/MM/yyyy");
                worksheet10Nam.Cells[i + 2, 4].Value = nv.HeSoLuong;
                worksheet10Nam.Cells[i + 2, 5].Value = nv.ViTriCongViec;
            }

            Console.WriteLine("Nhập tên file (không có đuôi .xlsx):");
            string fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Tên file không hợp lệ.");
                return;
            }

            string filePath = $"{fileName}.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

            Console.WriteLine($"Danh sách nhân viên đã được xuất ra file {filePath}");
        }
    }

    static int NhapSoNguyen(string thongTin)
    {
        int value;
        while (true)
        {
            Console.WriteLine($"Vui lòng nhập {thongTin}:");
            string input = Console.ReadLine();
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) return -1;
            if (int.TryParse(input, out value))
            {
                break;
            }
            else
            {
                Console.WriteLine($"{thongTin} phải là số nguyên.");
            }
        }
        return value;
    }

    static double NhapSoThuc(string thongTin)
    {
        double value;
        while (true)
        {
            Console.WriteLine($"Vui lòng nhập {thongTin}:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out value))
            {
                break;
            }
            else
            {
                Console.WriteLine($"{thongTin} phải là số thực.");
            }
        }
        return value;
    }

    static string NhapChuoi(string thongTin)
    {
        string value;
        while (true)
        {
            Console.WriteLine($"Vui lòng nhập {thongTin}:");
            value = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(value))
            {
                break;
            }
            else
            {
                Console.WriteLine($"{thongTin} không được trống.");
            }
        }
        return value;
    }

    static DateTime NhapNgay(string thongTin)
    {
        DateTime value;
        while (true)
        {
            Console.WriteLine($"Vui lòng nhập {thongTin}:");
            string input = Console.ReadLine();
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                break;
            }
            else
            {
                Console.WriteLine($"{thongTin} phải đúng định dạng dd/MM/yyyy.");
            }
        }
        return value;
    }
}
