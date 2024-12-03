using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BanHang_DAL
    {
        string Mahd;
        public string luu_hd(HoaDon_DTO hd)
        {
           
            try
            {
                Mahd = hd.MAHD_P;
                // 2. Lưu thông tin hóa đơn vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(dbconect.constr))  // Thay "connectionString" bằng chuỗi kết nối của bạn
                {
                    conn.Open();
                    SqlCommand cmd_manv = new SqlCommand("SELECT dbo.F_TIM_MANV('" + hd.MANV_P+"')", conn);
                    int manv = (int)cmd_manv.ExecuteScalar();

                    // Lưu thông tin hóa đơn vào bảng HoaDon
                    SqlCommand cmd = new SqlCommand("EXEC P_LUU_HOADON_THANHTOAN @MaHoaDon, @NgayLap, @TrangThai ,@Nhanvien", conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", hd.MAHD_P);
                    cmd.Parameters.AddWithValue("@NgayLap", hd.NGAYLAP_P);
                    cmd.Parameters.AddWithValue("@TrangThai", "Đã thanh toán");
                    cmd.Parameters.AddWithValue("@Nhanvien", manv);
                    cmd.ExecuteNonQuery();
                }
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string luu_cthd(ChiTietHoaDon_DTO cthd)
        {
            try
            {
                // 2. Lưu thông tin hóa đơn vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(dbconect.constr))  // Thay "connectionString" bằng chuỗi kết nối của bạn
                {
                    conn.Open();
                    //Lấy mã hóa đơn mới nhất
                    //int mahd;
                    //SqlCommand cmd1 = new SqlCommand("select dbo.F_MaHD_Moi()", conn);
                    //mahd = (int)cmd1.ExecuteScalar();

                    // Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon
                    SqlCommand cmdChiTiet = new SqlCommand("EXEC P_LUU_CHITIETHOADON_THANHTOAN @MaHoaDon, @MAHG, @SoLuong, @DonGia", conn);
                    cmdChiTiet.Parameters.AddWithValue("@MaHoaDon", Mahd);
                    cmdChiTiet.Parameters.AddWithValue("@MAHG", cthd.MaHG_P);
                    cmdChiTiet.Parameters.AddWithValue("@DonGia", cthd.GiaBan_P);
                    cmdChiTiet.Parameters.AddWithValue("@SoLuong", cthd.SoLuong_P);
                    cmdChiTiet.ExecuteNonQuery();
                }
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
