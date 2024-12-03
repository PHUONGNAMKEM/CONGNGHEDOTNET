using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LichTruc_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<LichTruc_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<LichTruc_DTO> lst = new List<LichTruc_DTO>();
            sql = @"EXEC P_HIENTHI_LICTRUC";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manv = read[0].ToString();
                string maca = read[1].ToString();
                string ngaytruc = read[2].ToString();
                LichTruc_DTO hd = new LichTruc_DTO(manv, maca, ngaytruc);
                lst.Add(hd);
            }
            conn.Close();
            return lst;
        }
        public string them(LichTruc_DTO lt)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                sql = @"EXEC P_THEM_LICTRUC '"+lt.MaNV_P+"', '"+lt.MaCA_P+"', '"+lt.NgayTruc_P+"'";
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
        public bool xoa(LichTruc_DTO lt)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //sql = @"EXEC DELETE_KHACHHANG '" + kh.MaKH_P + "'";
            sql = @"EXEC P_XOA_LICHTRUC '"+lt.MaNV_P+"', '"+lt.MaCA_P+"', '"+lt.NgayTruc_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public string sua(LichTruc_DTO lt)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql = @"EXEC P_SUA_LICTRUC '"+lt.MaNV_P+"', '"+lt.MaCA_P+"', '"+lt.NgayTruc_P+"', '"+lt.MaNV_OLD_P+"', '"+lt.MaCA_OLD_P+"', '"+lt.NgayTruc_OLD_P+"'";
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
        public List<NhanVien_DTO> getall_manv()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<NhanVien_DTO> lst = new List<NhanVien_DTO>();
            sql = @"EXEC HIENTHI_NHANVIEN";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manv = read[0].ToString();
                string tennv = read[1].ToString();
                string chucvu = read[2].ToString();
                string maql = read[3].ToString();
                NhanVien_DTO nv = new NhanVien_DTO(manv, tennv, chucvu, maql);
                lst.Add(nv);
            }
            conn.Close();
            return lst;
        }
        public List<LichCa_DTO> getall_lichca()
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
        public string ten_ca(NhanVien_DTO nv)
        {
            string kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = @"EXEC P_TEN_CA '"+nv.MaNV_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = (string)cmd.ExecuteScalar();
            conn.Close();
            return kq;
        }
    }
}
