using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLCTPX
    {
        QLCHTLDataContext qlctpx = new QLCHTLDataContext();
        public QLCTPX()
        {

        }
        public List<CTPHIEUXUAT> LoadChiTietPhieuXuat()
        {
            return qlctpx.CTPHIEUXUATs.Select(t => t).ToList<CTPHIEUXUAT>();
        }
        public int kTraKhoaChinh(string mactpx, string mahh)
        {
            return qlctpx.CTPHIEUXUATs.Select(t => t).Where(t => t.MAPX == mactpx).Where(h => h.MAHH == mahh).Count();
        }
    }
}
