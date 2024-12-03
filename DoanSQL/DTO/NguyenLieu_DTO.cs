using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieu_DTO
    {
        private string MaNL;
        private string TenNL;
        private string SL_Ton;
        private string DVT;
        private string DonGia;
        private string Hinh;

        public string MaNL_P { get => MaNL; set => MaNL = value; }
        public string TenNL_P { get => TenNL; set => TenNL = value; }
        public string SL_Ton_P { get => SL_Ton; set => SL_Ton = value; }
        public string DVT_P { get => DVT; set => DVT = value; }
        public string DonGia_P { get => DonGia; set => DonGia = value; }
        public string Hinh_P { get => Hinh; set => Hinh = value; }
        public NguyenLieu_DTO(string manl, string tennl, string sl_ton, string dvt, string dongiga, string hinh) 
        {
            MaNL_P = manl;
            TenNL_P = tennl;
            SL_Ton_P = sl_ton;
            DVT_P = dvt;
            DonGia_P = dongiga;
            Hinh_P = hinh;
        }

    }
}
