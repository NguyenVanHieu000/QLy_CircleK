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
    public partial class frmLoaiHang : Form
    {
        QLLoaiHang qllh = new QLLoaiHang();
        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qllh.themLoaihang(txtMLoai.Text,txtTenLoai.Text,txtGhichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = qllh.LoadLoaiHang();
            }
            else
            {
                MessageBox.Show("Loại hàng " + txtTenLoai.Text + " đã tồn tại ");
            }
        }

        private void frmLoaiHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qllh.LoadLoaiHang();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qllh.xoaLoaihang(txtMLoai.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = qllh.LoadLoaiHang();
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qllh.suabophan(txtMLoai.Text,txtTenLoai.Text,txtGhichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = qllh.LoadLoaiHang();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qllh.loadHangHoaTheoLoaiHang(txtMLoai.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
