using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<NhaCungCap_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<NhaCungCap_DTO> lst = new List<NhaCungCap_DTO>();
            sql = "select * from dbo.F_HIENTHI_NHACC()";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manv = read[0].ToString();
                string tennv = read[1].ToString();
                string diachi = read[2].ToString();
                string sodt = read[3].ToString();
                NhaCungCap_DTO ncc = new NhaCungCap_DTO(manv, tennv, diachi, sodt);
                lst.Add(ncc);
            }
            conn.Close();
            return lst;
        }
        public bool them(NhaCungCap_DTO ncc)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC THEM_NHACC N'" + ncc.TenNCC_P + "', N'" + ncc.DiaChi_P + "', '" + ncc.SoDT_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool xoa(NhaCungCap_DTO ncc)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //sql = @"EXEC DELETE_KHACHHANG '" + kh.MaKH_P + "'";
            sql = @"EXEC XOA_NHACC '" + ncc.MaNCC_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool sua(NhaCungCap_DTO ncc)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = @"EXEC SUA_NHACC " + "N'" + ncc.TenNCC_P + "', N'" + ncc.DiaChi_P + "', '" + ncc.SoDT_P + "', '" + ncc.MaNCC_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
    }
}