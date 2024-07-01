using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public double LuongCoBan { get; set; }
        public double HeSoLuong { get; set; }
        public double PhuCap { get; set; }
        public double TongLuong { get; set; }
    }
}
