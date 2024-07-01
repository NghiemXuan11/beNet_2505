using QuanLySanXuat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Managers
{
    public class BaoCaoManager
    {
        private readonly IBaoCaoService _baoCaoService;

        public BaoCaoManager(IBaoCaoService baoCaoService)
        {
            _baoCaoService = baoCaoService;
        }

        public void HienThiBaoCao()
        {
            _baoCaoService.HienThiBaoCao();
        }

        public void XuatBaoCao()
        {
            _baoCaoService.XuatBaoCao();
        }
    }
}
