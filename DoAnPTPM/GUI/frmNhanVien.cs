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
    public partial class frmNhanVien : Form
    {
        QLNhanVien qlnv= new QLNhanVien();
        QLBoPhan qlbp = new QLBoPhan();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (qlnv.themNhanvien(txtManv.Text,txtTennv.Text,dateTimePicker1.Value,txtDiaChi.Text,int.Parse(txtLuong.Text),txtDT.Text,txtMK.Text,comboBox1.SelectedValue.ToString(),dateTimePicker2.Value))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = qlnv.loadNhanVien();
            }
            else
            {
                MessageBox.Show("Nhân Viên " + txtTennv.Text + " đã tồn tại ");
            }
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlnv.loadNhanVien();
            dataGridView1.Columns[9].Visible = false;
            comboBox1.DataSource = qlbp.LoadBoPhan();
            comboBox1.DisplayMember = "TENBP";
            comboBox1.ValueMember = "MABP";

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qlnv.xoanhanvien(txtManv.Text))
            {
                MessageBox.Show("Xoá thành công");
                dataGridView1.DataSource = qlnv.loadNhanVien();
            }
            else
            {
                MessageBox.Show(" Xoá thất bại ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qlnv.suanhanvien(txtManv.Text, txtTennv.Text, dateTimePicker1.Value, txtDiaChi.Text, int.Parse(txtLuong.Text), txtDT.Text, txtMK.Text, comboBox1.SelectedValue.ToString(), dateTimePicker2.Value))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = qlnv.loadNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlnv.loadNhanVienTheoBoPhans(comboBox1.SelectedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("bạn có chắc muốn thoát không ?", "Thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                this.Close();

            }
            Program.frmHomePage.Show();

        }
    }
}
