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
    public class PhanQuyen_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<PhanQuyen_DTO> display()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<PhanQuyen_DTO> lst = new List<PhanQuyen_DTO>();
            sql = "EXEC P_PHANQUYEN";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                int mapq = int.Parse(read[0].ToString());
                string mota = read[1].ToString();
                string phanquyen = read[2].ToString();
                string thuhoiquyen = read[3].ToString();
                PhanQuyen_DTO pq = new PhanQuyen_DTO() { MaQuyen = mapq, MoTa = mota, CauLenhPhanQuyen = phanquyen, CauLenhThuHoiQuyen = thuhoiquyen };
                lst.Add(pq);
            }
            conn.Close();
            return lst;
        }

        public string layQuyen_For_PhanQuyen(int maquyen)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<PhanQuyen_DTO> lst = new List<PhanQuyen_DTO>();
            sql = "EXEC P_PHANQUYEN_FOR_USER @MaQuyen";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaQuyen", maquyen);

            read = cmd.ExecuteReader();
            string cauLenh = "";
            while (read.Read())
            {
                cauLenh = read[0].ToString();
            }
            conn.Close();
            return cauLenh;
        }

        public string layQuyen_For_ThuHoiQuyen(int maquyen)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<PhanQuyen_DTO> lst = new List<PhanQuyen_DTO>();
            sql = "EXEC P_THUHOIQUYEN_FOR_USER @MaQuyen";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaQuyen", maquyen);

            read = cmd.ExecuteReader();
            string cauLenh = "";
            while (read.Read())
            {
                cauLenh = read[0].ToString();
            }
            conn.Close();
            return cauLenh;
        }

        public bool phanQuyen_For_User(int maquyen, string username)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                List<PhanQuyen_DTO> lst = new List<PhanQuyen_DTO>();
                sql = layQuyen_For_PhanQuyen(maquyen);
                sql = sql.Replace("@username", username);

                cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool thuHoiQuyen_For_User(int maquyen, string username)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                List<PhanQuyen_DTO> lst = new List<PhanQuyen_DTO>();
                sql = layQuyen_For_ThuHoiQuyen(maquyen);
                sql = sql.Replace("@username", username);

                cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        //public bool them(PhanQuyen_DTO pq)
        //{
        //    int kq;
        //    SqlConnection conn = new SqlConnection(constr);
        //    conn.Open();
        //    //if (pn.MAKH_P == "")
        //    //{
        //    //    sql = @"EXEC THEM_HOADON '" + hd.MAHD_P + "', '" + hd.NGAYLAP_P + "', N'" + hd.TRANGTHAI_P + "', NULL, '" + hd.MANV_P + "'";

        //    //}
        //    //else
        //    //{
        //    //    sql = @"EXEC THEM_HOADON '" + hd.MAHD_P + "', '" + hd.NGAYLAP_P + "', N'" + hd.TRANGTHAI_P + "', '" + hd.MAKH_P + "', '" + hd.MANV_P + "'";

        //    //}

        //    sql = @"EXEC THEM_PHIEUNHAP '" + pn.MaPN_P + "', '" + pn.NgayNhap_P + "', N'" + pn.MaNCC_P + "', '" + pn.MANV_P + "'";

        //    cmd = new SqlCommand(sql, conn);
        //    kq = cmd.ExecuteNonQuery();
        //    conn.Close();
        //    if (kq > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public bool xoa(PhanQuyen_DTO pq)
        //{
        //    int kq;
        //    SqlConnection conn = new SqlConnection(constr);
        //    conn.Open();
        //    sql = @"EXEC XOA_PHIEUNHAP '" + pn.MaPN_P + "'";
        //    cmd = new SqlCommand(sql, conn);
        //    kq = cmd.ExecuteNonQuery();
        //    conn.Close();
        //    if (kq > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public bool sua(PhanQuyen_DTO pq)
        //{
        //    int kq;
        //    SqlConnection conn = new SqlConnection(constr);
        //    conn.Open();
        //    string sql = @"EXEC SUA_PHIEUNHAP " + "'" + pn.NgayNhap_P + "', '" + pn.MaNCC_P + "', '" + pn.MANV_P + "', '" + pn.MaPN_P + "'";
        //    cmd = new SqlCommand(sql, conn);
        //    kq = cmd.ExecuteNonQuery();/-strong/-heart:>:o:-((:-h //    conn.Close();
        //    if (kq > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


    }
}