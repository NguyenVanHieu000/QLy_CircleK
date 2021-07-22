using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hàngHoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            this.Hide();
            frm.Show();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiHang frm = new frmLoaiHang();
            this.Hide();
            frm.Show();
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromNCC frm = new fromNCC();
            this.Hide();
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.frmNV.Show();
            this.Hide();
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frm = new frmKho();
            this.Hide();
            frm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();
            this.Hide();
            frm.Show();
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoPhan frm = new frmBoPhan();
            this.Hide();
            frm.Show();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            this.Hide();
            frm.Show();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuat frm = new frmPhieuXuat();
            this.Hide();
            frm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmcheckPN frm = new frmcheckPN();
            this.Hide();
            frm.Show();
        }

        private void phiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCheckPX frm = new frmCheckPX();
            this.Hide();
            frm.Show();
        }

        private void hoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCheckHoaDon frm = new frmCheckHoaDon();
            this.Hide();
            frm.Show();
        }
    }
}
