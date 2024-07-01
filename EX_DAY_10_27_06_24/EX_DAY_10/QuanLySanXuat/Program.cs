using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Managers;
using QuanLySanXuat.Services;
using QuanLySanXuat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat
{
    class Program
    {
        private static INhanVienService nhanVienService = new NhanVienService();
        private static ICongDoanService congDoanService = new CongDoanService();
        private static IBaoCaoService baoCaoService = new BaoCaoService(nhanVienService, congDoanService, new ExcelExporter(congDoanService));

        private static NhanVienManager nhanVienManager = new NhanVienManager(nhanVienService);
        private static CongDoanManager congDoanManager = new CongDoanManager(congDoanService, nhanVienService);
        private static BaoCaoManager baoCaoManager = new BaoCaoManager(baoCaoService);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Thêm nhân viên.");
                Console.WriteLine("2. Tạo sản lượng theo công đoạn của từng nhân viên.");
                Console.WriteLine("3. Xuất và hiển thị báo cáo.");
                Console.WriteLine("4. Xuất báo cáo ra file Excel.");
                Console.WriteLine("5. Thoát.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        nhanVienManager.ThemNhanVien();
                        break;
                    case "2":
                        congDoanManager.TaoSanLuong();
                        break;
                    case "3":
                        baoCaoManager.HienThiBaoCao();
                        break;
                    case "4":
                        baoCaoManager.XuatBaoCao();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
