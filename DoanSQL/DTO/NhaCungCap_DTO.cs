using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        private string MaNCC;
        private string TenNCC;
        private string DiaChi;
        private string SoDT;

        public string MaNCC_P { get => MaNCC; set => MaNCC = value; }
        public string TenNCC_P { get => TenNCC; set => TenNCC = value; }
        public string DiaChi_P { get => DiaChi; set => DiaChi = value; }
        public string SoDT_P { get => SoDT; set => SoDT = value; }


        public NhaCungCap_DTO()
        {
            MaNCC_P = TenNCC_P = DiaChi_P = SoDT_P = string.Empty;
        }

        public NhaCungCap_DTO(string mancc, string tenncc, string diachi, string sodt)
        {
            MaNCC_P = mancc;
            TenNCC_P = tenncc;
            DiaChi_P = diachi;
            SoDT_P = sodt;
        }


    }
}