using QuanLySanXuat.Interfaces;
using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Services
{
    public class CongDoanService : ICongDoanService
    {
        private List<CongDoan> _congDoanList = new List<CongDoan>();

        public void ThemCongDoan(CongDoan congDoan)
        {
            _congDoanList.Add(congDoan);
        }

        public List<CongDoan> LayCongDoanCuaNhanVien(Guid nhanVienId)
        {
            return _congDoanList.Where(c => c.NhanVienId == nhanVienId).ToList();
        }
    }
}
