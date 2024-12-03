using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class LichCa_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<LichCa_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<LichCa_DTO> lst = new List<LichCa_DTO>();
            sql = @"EXEC P_HIENTHI_LICHCA";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string maca = read[0].ToString();
                string tenca = read[1].ToString();
                string tgbd = read[2].ToString();
                string tgkt = read[3].ToString();
                LichCa_DTO lc = new LichCa_DTO(maca, tenca, tgbd, tgkt);
                lst.Add(lc);
            }
            conn.Close();
            return lst;
        }
        public string them(LichCa_DTO lc)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                sql = @"EXEC P_THEM_LICHCA N'" + lc.TenCA_P + "', '" + lc.TGBD_P + "', '" + lc.TGKT_P + "'";
                cmd = new SqlCommand(sql, conn);
                kq = cmd.ExecuteNonQuery();
                conn.Close();
                if (kq > 0)
                {
                    return "true";
                }
                return "false";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public bool xoa(LichCa_DTO lc)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //sql = @"EXEC DELETE_KHACHHANG '" + kh.MaKH_P + "'";
            sql = @"EXEC P_XOA_LICHCA '" + lc.MaCA_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public string sua(LichCa_DTO lc)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql = @"EXEC P_SUA_LICHCA '" + lc.MaCA_P + "', N'" + lc.TenCA_P + "','" + lc.TGBD_P + "','" + lc.TGKT_P + "'";
                cmd = new SqlCommand(sql, conn);
                kq = cmd.ExecuteNonQuery();
                conn.Close();
                if (kq > 0)
                {
                    return "true";
                }
                return "false";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }



        }
    }
}
