using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLKhachHang
    {
        QLCHTLDataContext qlkh = new QLCHTLDataContext();
        public QLKhachHang()
        {

        }
        public List<KHACHHANG> LoadKhachHang()
        {
            return qlkh.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();
        }
        public int kTraKhoaChinh(string makh)
        {
            return qlkh.KHACHHANGs.Select(t => t).Where(t => t.MAKH == makh).Count();
        }
        public List<KHACHHANG> loadHangHoaTheoLoaiHang(string maloaihang)
        {
            return qlkh.KHACHHANGs.Select(t => t).Where(t => t.MAKH == maloaihang).ToList<KHACHHANG>();
        }
        public bool themKhachHang(string mkh, string tenkh, string diachi, string dt, string mk, float diem)
        {
            if (kTraKhoaChinh(mkh) == 0)
            {
                KHACHHANG a = new KHACHHANG();
                a.MAKH = mkh;
                a.TENKH = tenkh;
                a.DIACHI = diachi;
                a.DIENTHOAI = dt;
                a.MK = mk;
                a.DIEMTHANHVIEN = diem;
                qlkh.KHACHHANGs.InsertOnSubmit(a);
                qlkh.SubmitChanges();
                LoadKhachHang();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaKhachHang(string makh)
        {

            KHACHHANG a = new KHACHHANG();
            a = qlkh.KHACHHANGs.Where(bp => bp.MAKH == makh.Trim()).FirstOrDefault();
            if (a == null)
            {
                return false;
            }
            qlkh.KHACHHANGs.DeleteOnSubmit(a);
            qlkh.SubmitChanges();
            LoadKhachHang();
            return true;

        }
        public bool suaKhachHang(string makh, string tenkh, string diachi, string dt, string mk, float diem)
        {
            if (kTraKhoaChinh(makh) == 1)
            {
                List<KHACHHANG> list = LoadKhachHang();
                KHACHHANG a = new KHACHHANG();
                a = qlkh.KHACHHANGs.Where(kh => kh.MAKH == makh.Trim()).FirstOrDefault();
                a.TENKH = tenkh;
                a.DIACHI = diachi;
                a.DIENTHOAI = dt;
                a.MK = mk;
                a.DIEMTHANHVIEN = diem;
                foreach (KHACHHANG b in list)
                {
                    if (b.MAKH == makh)
                    {
                        qlkh.KHACHHANGs.DeleteOnSubmit(b);
                        qlkh.SubmitChanges();
                    }
                }
                qlkh.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
}
