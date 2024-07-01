using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Interfaces
{
    public interface INhanVienService
    {
        void ThemNhanVien(NhanVien nhanVien);
        NhanVien TimKiemNhanVien(Guid nhanVienId);
        List<NhanVien> LayTatCaNhanVien();
    }
}
