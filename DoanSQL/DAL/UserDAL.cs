using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAL
    {
        private string connectionString = @"Data Source=LAPTOP-H6IDD6F8\SQLEXPRESS;Initial Catalog=DEAN5;Integrated Security=True;Encrypt=False";
        public UserDAL()
        {
            //this.connectionString = connectionString;
        }

        public List<string> GetAllUsers()
        {
            List<string> users = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT loginname FROM sys.syslogins";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(reader["loginname"].ToString());
                        }
                    }
                }
            }
            return users;
        }

        public List<string> GetAllTables()
        {
            List<string> tables = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string query = "SELECT name FROM sys.tables";
                string query = "SELECT name FROM sys.objects WHERE type IN ('U', 'V')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(reader[0].ToString());
                        }
                    }
                }
            }
            return tables;
        }
        public List<NhanVien_DTO> GetAllStaff()
        {
            List<NhanVien_DTO> staff = new List<NhanVien_DTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string query = "SELECT name FROM sys.tables";
                string query = "SELECT * FROM NHANVIEN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string manv = reader[0].ToString();
                            string tennv = reader[1].ToString();
                            NhanVien_DTO nv = new NhanVien_DTO(manv, tennv);
                            staff.Add(nv);
                        }
                    }
                }
            }
            return staff;
        }

        //private string strConn = @"Data Source=LAPTOP-7VLSR7BE\SQLEXPRESS02;Initial Catalog=DEAN5;Integrated Security=True;Encrypt=False";
        //private string strSql = "SELECT * FROM sys.syslogins";
        //private DataTable tbl;
        //private SqlConnection conn;
        //private SqlDataAdapter adap;

        //public UserDAL()
        //{
        //    tbl = new DataTable();
        //    conn = new SqlConnection(strConn);
        //    adap = new SqlDataAdapter(strSql, conn);

        //    // Nạp dữ liệu vào DataTable
        //    adap.Fill(tbl);
        //}

        //public List<User_DTO> getAllUserName()
        //{
        //    List<User_DTO> lst = new List<User_DTO>();

        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        // Đảm bảo lấy đúng cột chứa tên người dùng
        //        string username = row["name"].ToString(); // Tùy chỉnh "name" theo tên cột trong sys.syslogins
        //        User_DTO user = new User_DTO() { User = username };
        //        lst.Add(user);
        //    }

        //    return lst;
        //}

        public void GrantPermissions(string username, string table, string permissions)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("P_ADMIN_PHANQUYEN_USER", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USERNAME", username);
                    cmd.Parameters.AddWithValue("@TABLE", table);
                    cmd.Parameters.AddWithValue("@QUYENDUOCCAP", permissions);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GrantAcc(string manv, string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("P_CAP_TAIKHOAN", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
