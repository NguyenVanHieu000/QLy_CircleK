using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLHangHoa
    {
        QLCHTLDataContext qlhh = new QLCHTLDataContext();
        public QLHangHoa()
        {

        }
        public List<HANGHOA> LoadHangHoa()
        {
            return qlhh.HANGHOAs.Select(t => t).ToList<HANGHOA>();
        }
        public List<HANGHOA> loadHangHoaTheoLoaiHang(string maloaihang)
        {
            return qlhh.HANGHOAs.Select(t => t).Where(t => t.MALH == maloaihang).ToList<HANGHOA>();
        }
        public int kTraKhoaChinh(string mahh)
        {
            return qlhh.HANGHOAs.Select(t => t).Where(t => t.MAHH == mahh).Count();
        }
        public bool themHanghoa(string mahang, string tenhang, string dvt,float dg, int sl, string lh, string ncc, string tinhtrang)
        {
            if (kTraKhoaChinh(mahang) == 0)
            {
                HANGHOA a = new HANGHOA();
                a.MAHH = mahang;
                a.TENHH = tenhang;
                a.DVT = dvt;
                a.DONGIA = dg;
                a.SOLUONG = sl;
                a.MALH = lh;
                a.MANCC = ncc;
                a.TINHTRANG = tinhtrang;
                qlhh.HANGHOAs.InsertOnSubmit(a);
                qlhh.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaBoPhan(string mahang)
        {

            HANGHOA a = new HANGHOA();
            a = qlhh.HANGHOAs.Where(bp => bp.MAHH == mahang.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qlhh.HANGHOAs.DeleteOnSubmit(a);
            qlhh.SubmitChanges();
            return true;

        }
        public bool suabophan(string mahang, string tenhang, string dvt, float dg, int sl, string lh, string ncc, string tinhtrang)
        {
            if (kTraKhoaChinh(mahang) == 1)
            {
                List<HANGHOA> list = LoadHangHoa();
                HANGHOA a = new HANGHOA();
                a = qlhh.HANGHOAs.Where(bp => bp.MAHH == mahang.Trim()).FirstOrDefault();
                a.TENHH = tenhang;
                a.DVT = dvt;
                a.DONGIA = dg;
                a.SOLUONG = sl;
                a.MALH = lh;
                a.MANCC = ncc;
                a.TINHTRANG = tinhtrang;
                foreach (HANGHOA b in list)
                {
                    if (b.MAHH == mahang)
                    {
                        qlhh.HANGHOAs.DeleteOnSubmit(b);
                        qlhh.SubmitChanges();
                    }
                }
                qlhh.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
