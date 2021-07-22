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
    public partial class FrmKhachHang : Form
    {
        QLKhachHang kh = new QLKhachHang();
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kh.themKhachHang(txtMaKH.Text,txtTenKH.Text,txtDiaChi.Text,txtDT.Text,txtMK.Text,float.Parse(txtDiem.Text)))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = kh.LoadKhachHang(); 
            }
            else
            {
                MessageBox.Show("Khách Hàng " + txtTenKH.Text + " đã tồn tại ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kh.xoaKhachHang(txtMaKH.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = kh.LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kh.LoadKhachHang();
        }

        private void FrmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kh.suaKhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtDT.Text, txtMK.Text, float.Parse(txtDiem.Text)))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = kh.LoadKhachHang(); 
                
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kh.loadHangHoaTheoLoaiHang(txtMaKH.Text);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
