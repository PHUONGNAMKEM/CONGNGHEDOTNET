using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhapHang_DAL
    {
        string MaPN;
        public string luu_pn(PhieuNhap_DTO pn)
        {

            try
            {
                MaPN = pn.MaPN_P;
                // 2. Lưu thông tin hóa đơn vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(dbconect.constr))  // Thay "connectionString" bằng chuỗi kết nối của bạn
                {
                    conn.Open();
                    SqlCommand cmd_manv = new SqlCommand("SELECT dbo.F_TIM_MANV('" + pn.MANV_P + "')", conn);
                    int manv = (int)cmd_manv.ExecuteScalar();

                    // Lưu thông tin hóa đơn vào bảng HoaDon
                    SqlCommand cmd = new SqlCommand("EXEC P_LUU_PHIEUNHAP_THANHTOAN @MaPhieuNhap, @NgayLap, @MaNCC ,@Nhanvien", conn);
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", pn.MaPN_P);
                    cmd.Parameters.AddWithValue("@NgayLap", pn.NgayNhap_P);
                    cmd.Parameters.AddWithValue("@MaNCC", pn.MaNCC_P);
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
        public string luu_ctpn(ChiTietPN_DTO cthd)
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
                    SqlCommand cmdChiTiet = new SqlCommand("EXEC P_LUU_CHITIETPN_THANHTOAN @MaPN, @MAHG, @SoLuong, @DonGia", conn);
                    cmdChiTiet.Parameters.AddWithValue("@MaPN", MaPN);
                    cmdChiTiet.Parameters.AddWithValue("@MAHG", cthd.MaHG_P);
                    cmdChiTiet.Parameters.AddWithValue("@DonGia", cthd.GiaBan_P);
                    cmdChiTiet.Parameters.AddWithValue("@SoLuong", cthd.SL_P);
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
