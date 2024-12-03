using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChamCong_DTO
    {
        private string MaNV;
        private string MaCA;
        private string NgayLam;
        private string TGVAO;
        private string TGRA;
        private string GhiChu;
        private string MaNV_OLD;
        private string MaCA_OLD;
        private string NgayLam_OLD;

        public string MaNV_P { get => MaNV; set => MaNV = value; }
        public string MaCA_P { get => MaCA; set => MaCA = value; }
        public string NgayLam_P { get => NgayLam; set => NgayLam = value; }
        public string TGVAO_P { get => TGVAO; set => TGVAO = value; }
        public string TGRA_P { get => TGRA; set => TGRA = value; }
        public string MaNV_OLD_P { get => MaNV_OLD; set => MaNV_OLD = value; }
        public string MaCA_OLD_P { get => MaCA_OLD; set => MaCA_OLD = value; }
        public string NgayLam_OLD_P { get => NgayLam_OLD; set => NgayLam_OLD = value; }
        public string GhiChu_P { get => GhiChu; set => GhiChu = value; }

        public ChamCong_DTO(string manv, string maca, string ngaylam, string tgvao, string tgra, string ghichu) 
        {
            MaNV_P = manv;
            MaCA_P = maca;
            NgayLam_P = ngaylam;
            TGVAO_P = tgvao;
            TGRA_P = tgra;
            GhiChu_P = ghichu;
        }
        public ChamCong_DTO(string manv, string maca, string ngaylam, string tgvao, string tgra,string ghichu, string manv_old, string maca_old, string ngaylam_old)
        {
            MaNV_P = manv;
            MaCA_P = maca;
            NgayLam_P = ngaylam;
            TGVAO_P = tgvao;
            TGRA_P = tgra;
            GhiChu_P = ghichu;
            MaNV_OLD_P = manv_old;
            MaCA_OLD_P = maca_old;
            NgayLam_OLD_P = ngaylam_old;
        }
    }
}
