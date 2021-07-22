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
    public partial class frmHangHoa : Form
    {
        QLHangHoa qlhh = new QLHangHoa();
        QLLoaiHang qll = new QLLoaiHang();
        QLNCC qlncc = new QLNCC();
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qlhh.themHanghoa(txtMHang.Text,txtTenHang.Text,txtDVT.Text,float.Parse(txtDongia.Text),int.Parse(txtSL.Text),cbbLoaiHang.SelectedValue.ToString(),cbbNCC.SelectedValue.ToString(),cbbTinhTrang.SelectedValue.ToString()))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = qlhh.LoadHangHoa();
            }
            else
            {
                MessageBox.Show("Hàng hoá " + txtTenHang.Text + " đã tồn tại ");
            }
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            
            cbbLoaiHang.DataSource = qll.LoadLoaiHang();
            cbbLoaiHang.ValueMember = "MaLH";
            cbbLoaiHang.DisplayMember = "TENLH";

            cbbNCC.DataSource = qlncc.LoadNhaCungCap();
            cbbNCC.ValueMember = "MANCC";
            cbbNCC.DisplayMember = "TENNCC";

            string[] tt = { "Còn hàng", "Hết hàng" };
            cbbTinhTrang.DataSource = tt;

            dataGridView1.DataSource = qlhh.LoadHangHoa();
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void frmHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qlhh.xoaBoPhan(txtMHang.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = qlhh.LoadHangHoa();
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qlhh.suabophan(txtMHang.Text, txtTenHang.Text, txtDVT.Text, float.Parse(txtDongia.Text), int.Parse(txtSL.Text), cbbLoaiHang.SelectedValue.ToString(), cbbNCC.SelectedValue.ToString(), cbbTinhTrang.SelectedValue.ToString()))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = qlhh.LoadHangHoa();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlhh.loadHangHoaTheoLoaiHang(txtMHang.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
