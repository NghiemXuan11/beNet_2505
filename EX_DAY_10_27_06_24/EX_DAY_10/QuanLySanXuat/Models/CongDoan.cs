using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Models
{
    public class CongDoan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid NhanVienId { get; set; }
        public string MaCongDoan { get; set; }
        public string TenCongDoan { get; set; }
        public int SoLuongSanPham { get; set; }
        public double Gia { get; set; }
        public double SanLuong => SoLuongSanPham * Gia;
    }
}
