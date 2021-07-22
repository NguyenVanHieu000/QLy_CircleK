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
    public partial class frmCheckPX : Form
    {
        QLPhieuXuat qlpx = new QLPhieuXuat();
        public frmCheckPX()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlpx.loadHangHoaTheoLoaiHang(txtMaPX.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPhieuXuat frm = new frmPhieuXuat();
            this.Hide();
            frm.Show();
        }

        private void frmCheckPX_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlpx.LoadPhieuXuat();
        }
    }
}
