using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLKho
    {
        QLCHTLDataContext qlkho = new QLCHTLDataContext();
        public QLKho()
        {

        }
        public List<KHO> loadKho()
        {
            return qlkho.KHOs.Select(t => t).ToList<KHO>();
        }
        public List<KHO> loadHangHoaTheoLoaiHang(string maloaihang)
        {
            return qlkho.KHOs.Select(t => t).Where(t => t.MAKHO == maloaihang).ToList<KHO>();
        }
        public int kTraKhoaChinh(string makho)
        {
            return qlkho.KHOs.Select(t => t).Where(t => t.MAKHO == makho).Count();
        }
        public bool themKho(string makho, string tenkho, string ghichu)
        {
            if (kTraKhoaChinh(makho) == 0)
            {
                KHO a = new KHO();
                a.MAKHO = makho;
                a.TENKHO = tenkho;
                a.GHICHU = ghichu;
                qlkho.KHOs.InsertOnSubmit(a);
                qlkho.SubmitChanges();
                loadKho();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoakho(string makho)
        {

            KHO a = new KHO();
            a = qlkho.KHOs.Where(bp => bp.MAKHO == makho.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qlkho.KHOs.DeleteOnSubmit(a);
            qlkho.SubmitChanges();
            loadKho();
            return true;

        }
        public bool suakho(string makho, string tenkho, string ghichu)
        {
            if (kTraKhoaChinh(makho) == 1)
            {
                List<KHO> list = loadKho();
                KHO a = new KHO();
                a = qlkho.KHOs.Where(bp => bp.MAKHO == makho.Trim()).FirstOrDefault();
                a.TENKHO = tenkho;
                a.GHICHU = ghichu;
                foreach (KHO b in list)
                {
                    if (b.MAKHO == makho)
                    {
                        qlkho.KHOs.DeleteOnSubmit(b);
                        qlkho.SubmitChanges();
                    }
                }
                qlkho.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
