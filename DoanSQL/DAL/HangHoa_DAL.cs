﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class HangHoa_DAL
    {
        SqlCommand cmd;
        SqlDataReader read;
        string constr;
        string sql;
        public void Login(Login_DTO login)
        {
            constr = "Server=" + login.Servername + ";Database=" + login.Database + ";User Id=" + login.UserName + ";Password=" + login.Password + ";";
        }
        public List<LoaiHang_DTO> getall_mahang()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<LoaiHang_DTO> lst = new List<LoaiHang_DTO>();
            sql = @"SELECT * FROM F_HIENTHI_LOAIHANG()";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string maloai = read[0].ToString();
                string tenloai = read[1].ToString();
                LoaiHang_DTO loaihang = new LoaiHang_DTO(maloai, tenloai);
                lst.Add(loaihang);
            }
            conn.Close();
            return lst;
        }
        public List<HangHoa_DTO> display()
        {
            List<HangHoa_DTO> lst = new List<HangHoa_DTO>();
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

 
                sql = @"EXEC DISPLAY_HANGHOA";
                cmd = new SqlCommand(sql, conn);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string mahang = read[0].ToString();
                    string tenhang = read[1].ToString();
                    string dvt = read[2].ToString();
                    string maloai = read[3].ToString();
                    float dongia = float.Parse(read[4].ToString());
                    string hinh = read[5].ToString();
                    HangHoa_DTO hanghoa = new HangHoa_DTO(mahang, tenhang, dvt, maloai, dongia, hinh);
                    lst.Add(hanghoa);
                }
                conn.Close();
                return lst;
            }
            catch (Exception ex)
            {
                lst = null;
                MessageBox.Show("Lổi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lst;
            }
            
        }
        public List<HangHoa_DTO> display_1()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<HangHoa_DTO> lst = new List<HangHoa_DTO>();
            sql = @"EXEC HANG_CHUA_BAN";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string mahang = read[0].ToString();
                string tenhang = read[1].ToString();
                string dvt = read[2].ToString();
                string maloai = read[3].ToString();
                float dongia = float.Parse(read[4].ToString());
                string hinh = read[5].ToString();
                float sl = float.Parse(read[6].ToString());
                HangHoa_DTO hanghoa = new HangHoa_DTO(mahang, tenhang, dvt, maloai,dongia, hinh, sl);
                lst.Add(hanghoa);
            }
            conn.Close();
            return lst;
        }
        public List<HangHoa_DTO> display_2()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            List<HangHoa_DTO> lst = new List<HangHoa_DTO>();
            sql = @"EXEC HANG_BAN_CHAY_NHAT";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string mahang = read[0].ToString();
                string tenhang = read[1].ToString();
                string dvt = read[2].ToString();
                string maloai = read[3].ToString();
                float dongia = float.Parse(read[4].ToString());
                string hinh = read[5].ToString();
                float doanhthu = float.Parse(read[6].ToString());
                HangHoa_DTO hanghoa = new HangHoa_DTO(mahang, tenhang, dvt, maloai, dongia, hinh, doanhthu);
                lst.Add(hanghoa);
            }
            conn.Close();
            return lst;
        }
        public bool them(HangHoa_DTO hang)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC INSERT_HANGHOA N'" + hang.TenHang_P + "',N'" + hang.DVT_P + "','" + hang.MaLoai_P + "','"+hang.DonGia_P+"','"+hang.Hinh_P+"'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool xoa(HangHoa_DTO hang)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC DELETE_HANGHOA '" + hang.MaHang_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public bool sua(HangHoa_DTO hang)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC UPDATE_HANGHOA '" + hang.MaHang_OLD_P+ "',N'" + hang.TenHang_P + "',N'" + hang.DVT_P+ "','"+hang.MaLoai_P+ "','" + hang.DonGia_P + "','" + hang.Hinh_P + "'";
            cmd = new SqlCommand(sql, conn);
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
        public List<HangHoa_DTO> search(string name, string giadau, string giacuoi)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            List<HangHoa_DTO> lst = new List<HangHoa_DTO>();
            if(giadau.Length==0 || giacuoi.Length==0)
            {
                sql = @"EXEC TIMKIEM_HANGHOA_TEN N'" + name + "'";
            }    
            else if(name.Length==0)
            {
                sql = @"EXEC TIMKIEM_HANGHOA_KHOANGGIA "+giadau+", "+giacuoi+"";
            }    
            else
            {
                sql = @"EXEC TIMKIEM_HANGHOA_TEN_KHOANGGIA N'"+name+"',"+giadau+", "+giacuoi+"";

            }
        
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string mahang = read[0].ToString();
                string tenhang = read[1].ToString();
                string dvt = read[2].ToString();
                string maloai = read[3].ToString();
                float dongia = float.Parse(read[4].ToString());
                string hinh = read[5].ToString();
                HangHoa_DTO hanghoa = new HangHoa_DTO(mahang, tenhang, dvt, maloai, dongia, hinh);
                lst.Add(hanghoa);
            }
            conn.Close();
            return lst;
        }
        public int sl_ton(int mahg)
        {
            int kq;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            sql = @"EXEC P_SL_TONKHO_SP "+mahg+"";
            cmd = new SqlCommand(sql, conn);
            kq = (int)cmd.ExecuteScalar();
            conn.Close();
            return kq;
        }
        public int tong_sl_hang_chua_ban()
        {
            int tongSoLuongChuaBan = 0; // Biến để lưu kết quả
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand("HANG_CHUA_BAN_VA_TONG", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số OUTPUT
                        SqlParameter outputParam = new SqlParameter("@TongSoLuongChuaBan", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output // Đặt là OUTPUT
                        };
                        cmd.Parameters.Add(outputParam);

                        // Thực thi lệnh (không cần truy vấn dữ liệu)
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị từ tham số OUTPUT
                        tongSoLuongChuaBan = (int)cmd.Parameters["@TongSoLuongChuaBan"].Value;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    throw new Exception("Lỗi khi lấy tổng số lượng hàng chưa bán: " + ex.Message);
                }
            }

            return tongSoLuongChuaBan; // Trả về kết quả cho GUI
        }

    }
}