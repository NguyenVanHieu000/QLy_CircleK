using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLBoPhan
    {
        QLCHTLDataContext qlbp = new QLCHTLDataContext();
        public QLBoPhan()
        {

        }
        public List<BOPHAN> LoadBoPhan()
        {
            return qlbp.BOPHANs.Select(t => t).ToList<BOPHAN>();
        }
        public List<BOPHAN> loadHangHoaTheoLoaiHang(string mabp)
        {
            return qlbp.BOPHANs.Select(t => t).Where(t => t.MABP == mabp).ToList<BOPHAN>();
        }
        public int kTraKhoaChinh(string mabp)
        {
            return qlbp.BOPHANs.Select(t => t).Where(t => t.MABP == mabp).Count();
        }
        public bool themBoPhan(string mabophan, string tenbophan,string ghichu)
        {
            if (kTraKhoaChinh(mabophan) == 0)
            {
                BOPHAN a = new BOPHAN();
                a.MABP = mabophan;
                a.TENBP = tenbophan;
                a.GHICHU = ghichu;
                qlbp.BOPHANs.InsertOnSubmit(a);
                qlbp.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaBoPhan(string mabp)
        {
            
            BOPHAN a = new BOPHAN();
            a = qlbp.BOPHANs.Where(bp => bp.MABP == mabp.Trim()).FirstOrDefault();
            if(a == null)
            {
                return false;
            }
            qlbp.BOPHANs.DeleteOnSubmit(a);
            qlbp.SubmitChanges();
            return true;

        }
        public bool suabophan(string mabp, string tenbp,string ghichu)
        {
            if (kTraKhoaChinh(mabp) == 1)
            {
                List<BOPHAN> list = LoadBoPhan();
                BOPHAN a = new BOPHAN();
                a = qlbp.BOPHANs.Where(bp => bp.MABP == mabp.Trim()).FirstOrDefault();
                a.TENBP = tenbp;
                a.GHICHU = ghichu;
                foreach (BOPHAN b in list)
                {
                    if (b.MABP == mabp)
                    {
                        qlbp.BOPHANs.DeleteOnSubmit(b);
                        qlbp.SubmitChanges();
                    }
                }               
                qlbp.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
}
