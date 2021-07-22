using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class XuLy
    {
        public int Check_config()
        {
            if (Properties.Settings.Default.TTinKetNoi == string.Empty)
                return 1;
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.TTinKetNoi);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;
            }
            catch
            {

                return 2;
            }


        }

        public enum LoginResult
        {
            Invalid,

            Disabled,

            Success


        }

        public LoginResult Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from NHANVIEN where MANV= '" + pUser + "' and MK = '" + pPass + "'", Properties.Settings.Default.TTinKetNoi);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return LoginResult.Disabled;


            }
            return LoginResult.Success;

        }

        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable GetDBName(string pServer, string pUser, string pPasss)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServer + ";Initial Catalog = master;User ID=" + pUser + ";pwd=" + pPasss + "");
            da.Fill(dt);
            return dt;
        }

        public void SaveConfig(string pServer, string pUser, string pPass, string pDBName)
        {
            BLL_DAL.Properties.Settings.Default.TTinKetNoi = "Data Source=" + pServer + ";Initial Catalog = " + pDBName + ";User ID=" + pUser + ";pwd=" + pPass + "";
            BLL_DAL.Properties.Settings.Default.Save();

        }



    }
}
