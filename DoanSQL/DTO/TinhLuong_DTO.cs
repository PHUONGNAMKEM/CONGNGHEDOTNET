using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhLuong_DTO
    {
        private string MaNV;
        private string TenNV;
        private string SoGioLam;
        private string TongLuong;

        public string MaNV_P { get => MaNV; set => MaNV = value; }
        public string TenNV_P { get => TenNV; set => TenNV = value; }
        public string SoGioLam_P { get => SoGioLam; set => SoGioLam = value; }
        public string TongLuong_P { get => TongLuong; set => TongLuong = value; }
        public TinhLuong_DTO(string manv, string tennv, string sogiolam, string tongluong) 
        {
            MaNV_P = manv;
            TenNV_P = tennv;
            SoGioLam_P = sogiolam;
            TongLuong_P = tongluong;
        }
    }
}
