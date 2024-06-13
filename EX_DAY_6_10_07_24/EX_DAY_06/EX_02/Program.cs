using System.Text;

namespace EX_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Dictionary<int, SinhVien> dsSinhVien = new Dictionary<int, SinhVien>();

            while (true)
            {
                Console.WriteLine("\nChọn một chức năng:");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Tìm sinh viên có điểm số cao nhất");
                Console.WriteLine("3. Lấy danh sách tên sinh viên có điểm lớn hơn một giá trị cho trước");
                Console.WriteLine("4. Đếm số lượng sinh viên đạt điểm trung bình trở lên");
                Console.WriteLine("5. Thoát");

                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien(dsSinhVien);
                        break;
                    case "2":
                        TimSinhVienDiemCaoNhat(dsSinhVien);
                        break;
                    case "3":
                        LayDanhSachSinhVienDiemCao(dsSinhVien);
                        break;
                    case "4":
                        DemSinhVienDiemTrungBinhTroLen(dsSinhVien);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        static void ThemSinhVien(Dictionary<int, SinhVien> dsSinhVien)
        {
            while (true)
            {
                Console.WriteLine("Nhập ID sinh viên:");
                string idInput = Console.ReadLine();
                Console.WriteLine("Nhập tên sinh viên:");
                string tenInput = Console.ReadLine();
                Console.WriteLine("Nhập điểm sinh viên:");
                string diemInput = Console.ReadLine();

                string idError, tenError, diemError;

                if (!Validate.KiemTraID(idInput, dsSinhVien, out idError))
                {
                    Console.WriteLine($"Lỗi: {idError}");
                    continue;
                }

                if (!Validate.KiemTraTen(tenInput, out tenError))
                {
                    Console.WriteLine($"Lỗi: {tenError}");
                    continue;
                }

                if (!Validate.KiemTraDiem(diemInput, out diemError))
                {
                    Console.WriteLine($"Lỗi: {diemError}");
                    continue;
                }

                int id = int.Parse(idInput);
                double diem = double.Parse(diemInput);

                SinhVien sv = new SinhVien
                {
                    ID = id,
                    Ten = tenInput,
                    Diem = diem
                };

                dsSinhVien[id] = sv;
                Console.WriteLine($"Đã thêm sinh viên: {sv.Ten} với điểm {sv.Diem}");
                break; // Thoát vòng lặp khi nhập thông tin đúng
            }
        }

        static void TimSinhVienDiemCaoNhat(Dictionary<int, SinhVien> dsSinhVien)
        {
            var svCaoNhat = dsSinhVien.Values.OrderByDescending(sv => sv.Diem).FirstOrDefault();
            Console.WriteLine($"Sinh viên có điểm số cao nhất: {svCaoNhat?.Ten} - {svCaoNhat?.Diem}");
        }

        static void LayDanhSachSinhVienDiemCao(Dictionary<int, SinhVien> dsSinhVien)
        {
            Console.WriteLine("Nhập điểm ngưỡng:");
            string diemNguongInput = Console.ReadLine();

            if (!Validate.KiemTraDiem(diemNguongInput, out string diemNguongError))
            {
                Console.WriteLine(diemNguongError);
                return;
            }

            double diemNguong = double.Parse(diemNguongInput);

            var dsSinhVienTrenNguong = dsSinhVien.Values.Where(sv => sv.Diem > diemNguong).Select(sv => sv.Ten).ToList();
            Console.WriteLine($"Sinh viên có điểm lớn hơn {diemNguong}: {string.Join(", ", dsSinhVienTrenNguong)}");
        }

        static void DemSinhVienDiemTrungBinhTroLen(Dictionary<int, SinhVien> dsSinhVien)
        {
            var soLuongTrungBinhTroLen = dsSinhVien.Values.Count(sv => sv.Diem >= 5);
            Console.WriteLine($"Số lượng sinh viên đạt điểm trung bình trở lên: {soLuongTrungBinhTroLen}");
        }
    }
}
