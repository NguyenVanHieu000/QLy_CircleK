using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLLoaiHang
    {
        QLCHTLDataContext qllh = new QLCHTLDataContext();
        public QLLoaiHang()
        {

        }
        public List<LOAIHANG> LoadLoaiHang()
        {
            return qllh.LOAIHANGs.Select(t => t).ToList<LOAIHANG>();
        }
        public int Ktkhoachinh(string malh)
        {
            return qllh.LOAIHANGs.Select(t => t).Where(t => t.MALH == malh).Count();
        }
        public List<LOAIHANG> loadHangHoaTheoLoaiHang(string maloaihang)
        {
            return qllh.LOAIHANGs.Select(t => t).Where(t => t.MALH == maloaihang).ToList<LOAIHANG>();
        }
        public bool themLoaihang(string malh, string tenlh, string ghichu)
        {
            if (Ktkhoachinh(malh) == 0)
            {
                LOAIHANG a = new LOAIHANG();
                a.MALH = malh;
                a.TENLH = tenlh;
                a.GHICHU = ghichu;
                qllh.LOAIHANGs.InsertOnSubmit(a);
                qllh.SubmitChanges();
                LoadLoaiHang();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaLoaihang(string malh)
        {

            LOAIHANG a = new LOAIHANG();
            a = qllh.LOAIHANGs.Where(bp => bp.MALH == malh.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qllh.LOAIHANGs.DeleteOnSubmit(a);
            qllh.SubmitChanges();
            LoadLoaiHang();
            return true;

        }
        public bool suabophan(string malh, string tenlh, string ghichu)
        {
            if (Ktkhoachinh(malh) == 1)
            {
                List<LOAIHANG> list = LoadLoaiHang();
                LOAIHANG a = new LOAIHANG();
                a = qllh.LOAIHANGs.Where(bp => bp.MALH == malh.Trim()).FirstOrDefault();
                a.TENLH = tenlh;
                a.GHICHU = ghichu;
                foreach (LOAIHANG b in list)
                {
                    if (b.MALH == malh)
                    {
                        qllh.LOAIHANGs.DeleteOnSubmit(b);
                        qllh.SubmitChanges();
                    }
                }
                qllh.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
}
