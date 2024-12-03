using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NguyenLieu_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<NguyenLieu_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<NguyenLieu_DTO> lst = new List<NguyenLieu_DTO>();
            sql = @"EXEC P_HIENTHI_NGUYENLIEU";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manl = read[0].ToString();
                string tennl = read[1].ToString();
                string sl_ton = read[2].ToString();
                string dvt = read[3].ToString();
                string dongia = read[4].ToString();
                string hinh = read[5].ToString();
                NguyenLieu_DTO nl = new NguyenLieu_DTO(manl, tennl, dvt, sl_ton, dongia, hinh);
                lst.Add(nl);
            }
            conn.Close();
            return lst;
        }
        public bool them(NguyenLieu_DTO nl)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC N'"+nl.TenNL_P+"', "+nl.SL_Ton_P+", N'"+nl.DVT_P+"', "+nl.DonGia_P+",'"+nl.Hinh_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool xoa(NguyenLieu_DTO nl)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC P_XOA_NGUYENLIEU '"+nl.MaNL_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool sua(NguyenLieu_DTO nl)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC P_SUA_NGUYENLIEU '"+nl.MaNL_P+"', N'"+nl.TenNL_P+"', '"+nl.SL_Ton_P+"', N'"+nl.DVT_P+"', '"+nl.DonGia_P+"', N'"+nl.Hinh_P+"'";
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
