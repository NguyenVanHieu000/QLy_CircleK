using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLNhanVien
    {
        QLCHTLDataContext qlnv = new QLCHTLDataContext();
        public QLNhanVien()
        {

        }
        public List<NHANVIEN> loadNhanVien()
        {
            return qlnv.NHANVIENs.Select(t => t).ToList<NHANVIEN>();
        }
        public List<NHANVIEN> loadNhanVienTheoBoPhans(string mabophan)
        {
            return qlnv.NHANVIENs.Select(t => t).Where(t => t.MABP == mabophan).ToList<NHANVIEN>();
        }
        public int kTraKhoaChinh(string manv)
        {
            return qlnv.NHANVIENs.Select(t => t).Where(t => t.MANV == manv).Count();
        }
        public bool themNhanvien(string manv, string tennv, DateTime ns, string dc, int luong, string dt, string mk,string bp,DateTime ngaylam)
        {
            if (kTraKhoaChinh(manv) == 0)
            {
                NHANVIEN a = new NHANVIEN();
                a.MANV = manv;
                a.TENNV = tennv;
                a.NGAYSINH = ns ;
                a.DCHI = dc;
                a.LUONGCOBAN = luong;
                a.DIENTHOAI = dt;
                a.MK = mk;
                a.MABP = bp;
                a.NGAYLAMVIEC = ngaylam;
                qlnv.NHANVIENs.InsertOnSubmit(a);
                qlnv.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoanhanvien(string manv)
        {

            NHANVIEN a = new NHANVIEN();
            a = qlnv.NHANVIENs.Where(bp => bp.MANV == manv.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qlnv.NHANVIENs.DeleteOnSubmit(a);
            qlnv.SubmitChanges();
            loadNhanVien();
            return true;

        }
        public bool suanhanvien(string manv, string tennv, DateTime ns, string dc, int luong, string dt, string mk, string bp, DateTime ngaylam)
        {
            if (kTraKhoaChinh(manv) == 1)
            {
                List<NHANVIEN> list = loadNhanVien();
                NHANVIEN a = new NHANVIEN();
                a.TENNV = tennv;
                a.NGAYSINH = ns;
                a.DCHI = dc;
                a.LUONGCOBAN = luong;
                a.DIENTHOAI = dt;
                a.MK = mk;
                a.MABP = bp;
                a.NGAYLAMVIEC = ngaylam;
                foreach (NHANVIEN b in list)
                {
                    if (b.MANV == manv)
                    {
                        qlnv.NHANVIENs.DeleteOnSubmit(b);
                        qlnv.SubmitChanges();
                    }
                }
                qlnv.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
}
