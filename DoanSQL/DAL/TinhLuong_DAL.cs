using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TinhLuong_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<TinhLuong_DTO> display(string day, string month, string year)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<TinhLuong_DTO> lst = new List<TinhLuong_DTO>();
            sql = @"EXEC P_TINH_LUONG "+day+","+month+","+year+"";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manv = read[0].ToString();
                string tennv = read[1].ToString();
                string sogiolam = read[2].ToString();
                string tongluong = read[3].ToString();
                TinhLuong_DTO hd = new TinhLuong_DTO(manv, tennv, sogiolam, tongluong);
                lst.Add(hd);
            }
            conn.Close();
            return lst;
        }
    }
}
