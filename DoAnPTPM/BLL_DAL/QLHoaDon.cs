using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLHoaDon
    {
        QLCHTLDataContext qlhd = new QLCHTLDataContext();
        public QLHoaDon()
        {

        }
        public List<HOADON> LoadHoaDon()
        {
            return qlhd.HOADONs.Select(t => t).ToList<HOADON>();
        }
        public int kTraKhoaChinh(string mahd)
        {
            return qlhd.HOADONs.Select(t => t).Where(t => t.MAHD == mahd).Count();
        }
        public List<HOADON> LoadHoaDontheoma(string mh)
        {
            return qlhd.HOADONs.Select(t => t).Where(t => t.MAHD == mh).ToList<HOADON>();
        }
    }
}
