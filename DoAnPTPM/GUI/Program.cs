using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        public static Form1 frmHomePage = null;

        public static frmErrorSever errorserver = null;
        public static frmNhanVien frmNV = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmHomePage = new Form1();
            frmNV = new frmNhanVien();
            Application.Run( new frmDangNhap());
        }
    }
}
