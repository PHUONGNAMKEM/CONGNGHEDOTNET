using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap_DTO
    {
        private string maPN;
        private string ngayNhap;
        private string maNCC;
        private string mANV;

        public string MaPN_P { get => maPN; set => maPN = value; }
        public string NgayNhap_P { get => ngayNhap; set => ngayNhap = value; }
        public string MaNCC_P { get => maNCC; set => maNCC = value; }
        public string MANV_P { get => mANV; set => mANV = value; }
        public PhieuNhap_DTO(string mapn, string ngaynhap, string mancc, string manv)
        {
            MaPN_P = mapn;
            NgayNhap_P = ngaynhap;
            MaNCC_P = mancc;
            MANV_P = manv;
        }
    }
}
