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
    public partial class frmBoPhan : Form
    {
        QLBoPhan bp = new QLBoPhan();
        public frmBoPhan()
        {
            InitializeComponent();
        }

        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bp.LoadBoPhan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bp.themBoPhan(txtMBoPhan.Text,txtTenBP.Text,txtGhichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = bp.LoadBoPhan(); 
            }
            else
            {
                MessageBox.Show("Bộ phận " + txtTenBP.Text + " đã tồn tại ");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bp.xoaBoPhan(txtMBoPhan.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = bp.LoadBoPhan(); ; 
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
            dataGridView1.DataSource = bp.LoadBoPhan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bp.suabophan(txtMBoPhan.Text, txtTenBP.Text, txtGhichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = bp.LoadBoPhan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void frmBoPhan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtMBoPhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtTenBP_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bp.loadHangHoaTheoLoaiHang(txtMBoPhan.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
