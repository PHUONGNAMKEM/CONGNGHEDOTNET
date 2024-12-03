using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuNhap_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<PhieuNhap_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<PhieuNhap_DTO> lst = new List<PhieuNhap_DTO>();
            sql = "select * from dbo.F_HIENTHI_PHIEUNHAP()";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string maPN = read[0].ToString();
                string ngaynhap = read[1].ToString();
                string mancc = read[2].ToString();
                string manv = read[3].ToString();
                PhieuNhap_DTO pn = new PhieuNhap_DTO(maPN, ngaynhap, mancc, manv);
                lst.Add(pn);
            }
            conn.Close();
            return lst;
        }
        public bool them(PhieuNhap_DTO pn)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //if (pn.MAKH_P == "")
            //{
            //    sql = @"EXEC THEM_HOADON '" + hd.MAHD_P + "', '" + hd.NGAYLAP_P + "', N'" + hd.TRANGTHAI_P + "', NULL, '" + hd.MANV_P + "'";

            //}
            //else
            //{
            //    sql = @"EXEC THEM_HOADON '" + hd.MAHD_P + "', '" + hd.NGAYLAP_P + "', N'" + hd.TRANGTHAI_P + "', '" + hd.MAKH_P + "', '" + hd.MANV_P + "'";

            //}

            sql = @"EXEC THEM_PHIEUNHAP '" + pn.MaPN_P + "', '" + pn.NgayNhap_P + "', N'" + pn.MaNCC_P + "', '" + pn.MANV_P + "'";

            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool xoa(PhieuNhap_DTO pn)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC XOA_PHIEUNHAP '" + pn.MaPN_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool sua(PhieuNhap_DTO pn)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = @"EXEC SUA_PHIEUNHAP " + "'" + pn.NgayNhap_P + "', '" + pn.MaNCC_P + "', '" + pn.MANV_P + "', '" + pn.MaPN_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }

        public List<NhanVien_DTO> getall_manv()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<NhanVien_DTO> lst = new List<NhanVien_DTO>();
            sql = @"select * from NHANVIEN";
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
        public List<NhaCungCap_DTO> getall_mancc()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<NhaCungCap_DTO> lst = new List<NhaCungCap_DTO>();
            sql = @"select * from NHACC";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string makh = read[0].ToString();
                string tenncc = read[1].ToString();
                string diachi = read[2].ToString();
                string sodt = read[3].ToString();
                NhaCungCap_DTO ncc = new NhaCungCap_DTO(makh, tenncc, diachi, sodt);
                lst.Add(ncc);
            }
            conn.Close();
            return lst;
        }
    }
}
