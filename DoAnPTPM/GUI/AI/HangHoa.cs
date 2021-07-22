using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.AI
{
    public class HangHoa
    {
        private int GiaBan;
        private string TenHang;

        public HangHoa()
        {

        }
        public HangHoa(int GiaBan,string TenHang)
        {
            this.GiaBan = GiaBan;
            this.TenHang = TenHang;
        }

        public int GiaBan1{ get { return GiaBan; }set { GiaBan = value; }}
        public string TenHang1 { get { return TenHang; } set { TenHang = value; } }
    }
}
