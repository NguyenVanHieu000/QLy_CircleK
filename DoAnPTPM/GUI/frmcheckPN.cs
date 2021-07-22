using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace GUI
{
    public partial class frmcheckPN : Form
    {
        QLPhieuNhap qlpn = new QLPhieuNhap();
        public frmcheckPN()
        {
            InitializeComponent();
        }

        private void frmcheckPN_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlpn.LoadPhieuNhap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            this.Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlpn.loadHangHoaTheoLoaiHang(txtMaPN.Text);
        }
    }
}
