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
    public partial class frmErrorSever : Form
    {
        XuLy CauHinh = new XuLy();
        public frmErrorSever()
        {
            InitializeComponent();
        }

        private void cbo_servername_DropDown(object sender, EventArgs e)
        {
            cbo_servername.DataSource = CauHinh.GetServerName();
            cbo_servername.DisplayMember = "ServerName";
        }

        private void cbo_database_DropDown(object sender, EventArgs e)
        {
            cbo_database.DataSource = CauHinh.GetDBName(cbo_servername.Text, txt_username.Text, txt_password.Text);
            cbo_database.DisplayMember = "name";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbo_servername.Text, txt_username.Text, txt_password.Text, cbo_database.Text);
            this.Close();
        }
    }
}
