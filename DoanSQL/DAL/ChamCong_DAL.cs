using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChamCong_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<ChamCong_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<ChamCong_DTO> lst = new List<ChamCong_DTO>();
            sql = @"EXEC P_HIENTHI_CHAMCONG";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string manv = read[0].ToString();
                string maca = read[1].ToString();
                string ngaylam = read[2].ToString();
                string tgvao = read[3].ToString();
                string tgra = read[4].ToString();
                string ghichu = read[5].ToString();
                ChamCong_DTO cc = new ChamCong_DTO(manv, maca, ngaylam, tgvao, tgra, ghichu);
                lst.Add(cc);
            }
            conn.Close();
            return lst;
        }
        public string them(ChamCong_DTO cc)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                sql = @"EXEC P_THEM_CHAMCONG '"+cc.MaNV_P+"', '"+cc.MaCA_P+"', '"+cc.NgayLam_P+"','"+cc.TGVAO_P+"', '"+cc.TGRA_P+"',N'"+cc.GhiChu_P+"'";
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
        public bool xoa(ChamCong_DTO cc)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //sql = @"EXEC DELETE_KHACHHANG '" + kh.MaKH_P + "'";
            sql = @"EXEC P_XOA_CHAMCONG '"+cc.MaNV_P+"', '"+cc.MaCA_P+"', '"+cc.NgayLam_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public string sua(ChamCong_DTO cc)
        {
            try
            {
                int kq;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql = @"EXEC P_SUA_CHAMCONG '"+cc.MaNV_P+"', '"+cc.MaCA_P+"', '"+cc.NgayLam_P+"','"+cc.TGVAO_P+"','"+cc.TGRA_P+"',N'"+cc.GhiChu_P+"', '"+cc.MaNV_OLD_P+"', '"+cc.MaCA_OLD_P+"', '"+cc.NgayLam_OLD_P+"'";
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
    }
}
