using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace GUI
{
    public partial class frmGoiY : Form
    {
        public frmGoiY()
        {
            InitializeComponent();
            
        }

        AI.HangHoa[] data = new AI.HangHoa[1000];
        AI.HangHoa[] dataOut = new AI.HangHoa[1000];
        AI.HangHoa[] dataK = new AI.HangHoa[100];
        AI.KNN_Model knn = new AI.KNN_Model();


        public DataTable ReadExcel(string fileName)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();

                connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + fileName); //Excel 97-2003, .xls
                string excelQuery = @"Select [DonGia],[TenHHoa] 
                   FROM [Sheet1$]";

                //string excelQuery = @"Select * FROM [Sheet1$]";        
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(excelQuery, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dgv_SanPham.DataSource = dt.DefaultView;
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program can't read file. " + ex.Message, "Please Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void frmGoiY_Load(object sender, EventArgs e)
        {
            ReadExcel("Data.xls");
        }

        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (dgv_SanPham.DataSource != null && dgv_SanPham.RowCount > 0)
            {
                try
                {
                    for (int i = 0; i < dgv_SanPham.RowCount; i++)
                    {
                        int giaBan = Convert.ToInt32(dgv_SanPham.Rows[i].Cells[0].Value);
                        string tenHang = dgv_SanPham.Rows[i].Cells[1].Value.ToString();

                        AI.HangHoa h = new AI.HangHoa(giaBan, tenHang);
                        data[n] = h;
                        n++;
                    }
                    try
                    {
                        if (txt_GiaMua.Text.Length != 0)
                        {
                            int giaBan = Convert.ToInt32(txt_GiaMua.Text);
                            AI.HangHoa input = new AI.HangHoa();
                            input.GiaBan1 = giaBan;

                            knn.getValue(data, dgv_SanPham.RowCount, input, dataOut);
                            knn.sortUp(dataOut);
                            knn.getK_Value(dataOut, dataK);
                            string a = knn.check_Label(dataK);

                            txt_SPGoiY.Text = a.ToString();
                        }
                        else
                            MessageBox.Show("Bạn chưa nhập giá cần mua!");
                    }
                    catch (Exception)
                    {
                        txt_SPGoiY.Text = "null";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            else
                MessageBox.Show("Rỗng");
        }
    }
}
