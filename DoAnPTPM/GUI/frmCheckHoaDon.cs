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
    public partial class frmCheckHoaDon : Form
    {
        QLHoaDon qlhd = new QLHoaDon();
        public frmCheckHoaDon()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlhd.LoadHoaDontheoma(txtMaHD.Text);
        }

        private void frmCheckHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = qlhd.LoadHoaDon();
        }
    }
}
