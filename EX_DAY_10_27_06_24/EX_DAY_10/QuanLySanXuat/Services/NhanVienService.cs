using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Services
{
    public class NhanVienService : INhanVienService
    {
        private List<NhanVien> _nhanVienList = new List<NhanVien>();

        public void ThemNhanVien(NhanVien nhanVien)
        {
            _nhanVienList.Add(nhanVien);
        }

        public NhanVien TimKiemNhanVien(Guid nhanVienId)
        {
            return _nhanVienList.FirstOrDefault(nv => nv.Id == nhanVienId);
        }

        public List<NhanVien> LayTatCaNhanVien()
        {
            return _nhanVienList;
        }
    }
}
