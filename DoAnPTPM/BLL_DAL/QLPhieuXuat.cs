using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLPhieuXuat
    {
        QLCHTLDataContext qlpx = new QLCHTLDataContext();
        public QLPhieuXuat()
        {

        }
        public List<PHIEUXUAT> LoadPhieuXuat()
        {
            return qlpx.PHIEUXUATs.Select(t => t).ToList<PHIEUXUAT>();
        }
        public List<PHIEUXUAT> loadHangHoaTheoLoaiHang(string mabp)
        {
            return qlpx.PHIEUXUATs.Select(t => t).Where(t => t.MAPX == mabp).ToList<PHIEUXUAT>();
        }
        public int kTraKhoaChinh(string mapx)
        {
            return qlpx.PHIEUXUATs.Select(t => t).Where(t => t.MAPX == mapx).Count();
        }
    }
}
