using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLPhieuNhap
    {
        QLCHTLDataContext qlpn = new QLCHTLDataContext();
        public QLPhieuNhap()
        {

        }
        public List<PHIEUNHAP> LoadPhieuNhap()
        {
            return qlpn.PHIEUNHAPs.Select(t => t).ToList<PHIEUNHAP>();
        }
        public List<PHIEUNHAP> loadHangHoaTheoLoaiHang(string mabp)
        {
            return qlpn.PHIEUNHAPs.Select(t => t).Where(t => t.MAPN == mabp).ToList<PHIEUNHAP>();
        }
        public int kTraKhoaChinh(string mapn)
        {
            return qlpn.PHIEUNHAPs.Select(t => t).Where(t => t.MAPN == mapn).Count();
        }
    }
}
