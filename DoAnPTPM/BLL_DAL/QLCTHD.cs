using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLCTHD
    {
        QLCHTLDataContext qlcthd = new QLCHTLDataContext();
        public QLCTHD()
        {

        }
        public List<CHITIETHD> LoadChiTietHoaDon()
        {
            return qlcthd.CHITIETHDs.Select(t => t).ToList<CHITIETHD>();
        }
        public int kTraKhoaChinh(string mahd, string mahh)
        {
            return qlcthd.CHITIETHDs.Select(t => t).Where(t => t.MAHD == mahd).Where(h => h.MAHH == mahh).Count();
        }
    }
}
