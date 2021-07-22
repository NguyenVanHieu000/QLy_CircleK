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
    public partial class frmKho : Form
    {
        QLKho qlkho = new QLKho();
        public frmKho()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qlkho.themKho(txtMaKho.Text,txtTenKho.Text,txtGhichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = qlkho.loadKho();
            }
            else
            {
                MessageBox.Show("Kho " + txtTenKho.Text + " đã tồn tại ");
            }
        }

        private void frmKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qlkho.xoakho(txtMaKho.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = qlkho.loadKho(); 
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qlkho.suakho(txtMaKho.Text,txtTenKho.Text,txtGhichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = qlkho.loadKho();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlkho.loadKho();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlkho.loadHangHoaTheoLoaiHang(txtMaKho.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
