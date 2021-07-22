using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLNCC
    {
        QLCHTLDataContext qlncc = new QLCHTLDataContext();
        public QLNCC()
        {

        }
        public List<NHACUNGCAP> LoadNhaCungCap()
        {
            return qlncc.NHACUNGCAPs.Select(t => t).ToList<NHACUNGCAP>();
        }
        public int kTraKhoaChinh(string mancc)
        {
            return qlncc.NHACUNGCAPs.Select(t => t).Where(t => t.MANCC == mancc).Count();
        }
        public bool themNCC(string mancc, string tenncc, string dc, string dt, string ghichu)
        {
            if (kTraKhoaChinh(mancc) == 0)
            {
                NHACUNGCAP a = new NHACUNGCAP();
                a.MANCC = mancc;
                a.TENNCC = tenncc;
                a.DIACHI = dc;
                a.DIENTHOAI = dt;
                a.GHICHU = ghichu;
                qlncc.NHACUNGCAPs.InsertOnSubmit(a);
                qlncc.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaNcc(string mancc)
        {

            NHACUNGCAP a = new NHACUNGCAP();
            a = qlncc.NHACUNGCAPs.Where(bp => bp.MANCC == mancc.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qlncc.NHACUNGCAPs.DeleteOnSubmit(a);
            qlncc.SubmitChanges();
            return true;

        }
        public bool suaNCC(string mancc, string tenncc, string dc, string dt, string ghichu)
        {
            if (kTraKhoaChinh(mancc) == 1)
            {
                List<NHACUNGCAP> list = LoadNhaCungCap();
                NHACUNGCAP a = new NHACUNGCAP();
                a.TENNCC = tenncc;
                a.DIACHI = dc;
                a.DIENTHOAI = dt;
                a.GHICHU = ghichu;
                foreach (NHACUNGCAP b in list)
                {
                    if (b.MANCC == mancc)
                    {
                        qlncc.NHACUNGCAPs.DeleteOnSubmit(b);
                        qlncc.SubmitChanges();
                    }
                }
                qlncc.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
