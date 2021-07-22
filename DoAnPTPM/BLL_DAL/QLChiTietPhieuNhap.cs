using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLChiTietPhieuNhap
    {
        QLCHTLDataContext qlctpn = new QLCHTLDataContext();
        public QLChiTietPhieuNhap()
        {

        }
        public List<CTPHIEUNHAP> LoadChiTietPhieuNhap()
        {
            return qlctpn.CTPHIEUNHAPs.Select(t => t).ToList<CTPHIEUNHAP>();
        }
        public int kTraKhoaChinh(string mactpn, string mahh)
        {
            return qlctpn.CTPHIEUNHAPs.Select(t => t).Where(t => t.MAPN == mactpn).Where(h => h.MAHH == mahh).Count();
        }
    }
}
