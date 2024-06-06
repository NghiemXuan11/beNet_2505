using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

enum HocLuc
{
    XuatSac,
    Gioi,
    Kha,
    TrungBinh,
    Yeu
}

struct SinhVien
{
    public int ID;
    public string Ten;
    public int Tuoi;
    public double DiemHK1;
    public double DiemHK2;
    public HocLuc HocLuc;

    public SinhVien(int id, string ten, int tuoi, double diemHK1, double diemHK2)
    {
        ID = id;
        Ten = ten;
        Tuoi = tuoi;
        DiemHK1 = diemHK1;
        DiemHK2 = diemHK2;
        HocLuc = XepLoaiHocLuc((diemHK1 + diemHK2) / 2);
    }

    private static HocLuc XepLoaiHocLuc(double diemTB)
    {
        if (diemTB >= 9) return HocLuc.XuatSac;
        if (diemTB >= 8) return HocLuc.Gioi;
        if (diemTB >= 6.5) return HocLuc.Kha;
        if (diemTB >= 5) return HocLuc.TrungBinh;
        return HocLuc.Yeu;
    }
}

class Program
{
    static List<SinhVien> danhSachSinhVien = new List<SinhVien>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        while (true)
        {
            Console.WriteLine("Chọn chức năng:");
            Console.WriteLine("1. Nhập danh sách sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên và điểm tổng kết cao nhất");
            Console.WriteLine("3. Liệt kê danh sách sinh viên có tiến bộ");
            Console.WriteLine("4. Tìm kiếm sinh viên");
            Console.WriteLine("5. Xuất danh sách sinh viên ra file Excel");
            Console.WriteLine("6. Thoát");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NhapDanhSachSinhVien();
                    break;
                case "2":
                    HienThiDanhSachVaDiemCaoNhat();
                    break;
                case "3":
                    LietKeSinhVienTienBo();
                    break;
                case "4":
                    TimKiemSinhVien();
                    break;
                case "5":
                    //XuatDanhSachRaExcel();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }

    static void NhapDanhSachSinhVien()
    {
        danhSachSinhVien.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");

            int id = NhapSoNguyen("ID");
            string ten = NhapChuoi("Tên");
            int tuoi = NhapSoNguyen("Tuổi");
            double diemHK1 = NhapSoThuc("Điểm tổng kết học kì 1");
            double diemHK2 = NhapSoThuc("Điểm tổng kết học kì 2");

            SinhVien sv = new SinhVien(id, ten, tuoi, diemHK1, diemHK2);
            danhSachSinhVien.Add(sv);
        }
    }

    static void HienThiDanhSachVaDiemCaoNhat()
    {
        if (danhSachSinhVien.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên trống.");
            return;
        }

        double diemCaoNhat = danhSachSinhVien.Max(sv => (sv.DiemHK1 + sv.DiemHK2) / 2);
        var svCaoNhat = danhSachSinhVien.Where(sv => (sv.DiemHK1 + sv.DiemHK2) / 2 == diemCaoNhat);

        Console.WriteLine("Danh sách sinh viên:");
        foreach (var sv in danhSachSinhVien)
        {
            Console.WriteLine($"ID: {sv.ID}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Điểm HK1: {sv.DiemHK1}, Điểm HK2: {sv.DiemHK2}, Học lực: {sv.HocLuc}");
        }

        Console.WriteLine("\nSinh viên có điểm tổng kết cao nhất:");
        foreach (var sv in svCaoNhat)
        {
            Console.WriteLine($"ID: {sv.ID}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Điểm HK1: {sv.DiemHK1}, Điểm HK2: {sv.DiemHK2}, Học lực: {sv.HocLuc}");
        }
    }

    static void LietKeSinhVienTienBo()
    {
        var svTienBo = danhSachSinhVien.Where(sv => sv.DiemHK2 > sv.DiemHK1);

        if (!svTienBo.Any())
        {
            Console.WriteLine("Không có sinh viên nào có tiến bộ.");
            return;
        }

        Console.WriteLine("Danh sách sinh viên có tiến bộ:");
        foreach (var sv in svTienBo)
        {
            Console.WriteLine($"ID: {sv.ID}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Điểm HK1: {sv.DiemHK1}, Điểm HK2: {sv.DiemHK2}, Học lực: {sv.HocLuc}");
        }
    }

    static void TimKiemSinhVien()
    {
        Console.WriteLine("Chọn tiêu chí tìm kiếm:");
        Console.WriteLine("1. Tìm kiếm theo ID");
        Console.WriteLine("2. Tìm kiếm theo tên");
        Console.WriteLine("3. Tìm kiếm theo loại học lực");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                int id = NhapSoNguyen("ID");
                var svTheoID = danhSachSinhVien.Where(sv => sv.ID == id);
                HienThiKetQuaTimKiem(svTheoID);
                break;
            case "2":
                string ten = NhapChuoi("Tên");
                var svTheoTen = danhSachSinhVien.Where(sv => sv.Ten.Contains(ten, StringComparison.OrdinalIgnoreCase));
                HienThiKetQuaTimKiem(svTheoTen);
                break;
            case "3":
                Console.WriteLine("Chọn loại học lực:");
                foreach (var hocLuc in Enum.GetValues(typeof(HocLuc)))
                {
                    Console.WriteLine($"{(int)hocLuc}. {hocLuc}");
                }
                int hocLucChoice = NhapSoNguyen("loại học lực");
                if (Enum.IsDefined(typeof(HocLuc), hocLucChoice))
                {
                    HocLuc hocLuc = (HocLuc)hocLucChoice;
                    var svTheoHocLuc = danhSachSinhVien.Where(sv => sv.HocLuc == hocLuc);
                    HienThiKetQuaTimKiem(svTheoHocLuc);
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                }
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                break;
        }
    }

    static void HienThiKetQuaTimKiem(IEnumerable<SinhVien> ketQua)
    {
        if (!ketQua.Any())
        {
            Console.WriteLine("Không tìm thấy sinh viên nào.");
            return;
        }

        Console.WriteLine("Kết quả tìm kiếm:");
        foreach (var sv in ketQua)
        {
            Console.WriteLine($"ID: {sv.ID}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Điểm HK1: {sv.DiemHK1}, Điểm HK2: {sv.DiemHK2}, Học lực: {sv.HocLuc}");
        }
    }

    

    static int NhapSoNguyen(string thongTin)
    {
        int value;
        while (true)
        {
            Console.WriteLine($"Vui lòng nhập {thongTin}:");
            string input = Console.ReadLine();
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
}
