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
    public partial class fromNCC : Form
    {
        QLNCC qlncc = new QLNCC();
        public fromNCC()
        {
            InitializeComponent();
        }

        private void fromNCC_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlncc.LoadNhaCungCap();
        }

        private void fromNCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qlncc.themNCC(txtMaNCC.Text,txtTenNCC.Text,txtDC.Text,txtDT.Text,txtGhichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = qlncc.LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Nhà cung cấp " + txtTenNCC.Text + " đã tồn tại ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qlncc.xoaNcc(txtMaNCC.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = qlncc.LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("xoá thất bại ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qlncc.suaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDC.Text, txtDT.Text, txtGhichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = qlncc.LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
