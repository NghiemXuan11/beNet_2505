using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Interfaces
{
    public interface ICongDoanService
    {
        void ThemCongDoan(CongDoan congDoan);
        List<CongDoan> LayCongDoanCuaNhanVien(Guid nhanVienId);
    }
}
