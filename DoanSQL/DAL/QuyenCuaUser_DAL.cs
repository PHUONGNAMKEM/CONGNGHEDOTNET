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
    public class QuyenCuaUser_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }

        public List<QuyenCuaUser_DTO> display(string username)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<QuyenCuaUser_DTO> lst = new List<QuyenCuaUser_DTO>();
            sql = "EXEC P_GET_PERMISSION_FOR_USER '" + username + "'";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string usernamene = read[0].ToString();
                string procedurename = read[1].ToString();
                string functioname = read[2].ToString();
                string tablename = read[3].ToString();
                QuyenCuaUser_DTO quern = new QuyenCuaUser_DTO() { UserName = usernamene, ProcedureName = procedurename, FunctionName = functioname, TabelName = tablename };
                lst.Add(quern);
            }
            conn.Close();
            return lst;
        }

        //public bool them(QuyenCuaUser_DTO pq)
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
        //public bool xoa(QuyenCuaUser_DTO pq)
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
        //}/-strong/-heart:>:o:-((:-h //public bool sua(QuyenCuaUser_DTO pq)
        //{
        //    int kq;
        //    SqlConnection conn = new SqlConnection(constr);
        //    conn.Open();
        //    string sql = @"EXEC SUA_PHIEUNHAP " + "'" + pn.NgayNhap_P + "', '" + pn.MaNCC_P + "', '" + pn.MANV_P + "', '" + pn.MaPN_P + "'";
        //    cmd = new SqlCommand(sql, conn);
        //    kq = cmd.ExecuteNonQuery();
        //    conn.Close();
        //    if (kq > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


    }
}