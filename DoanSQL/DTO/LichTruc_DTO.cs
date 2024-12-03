using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichTruc_DTO
    {
        private string MaNV;
        private string MaCA;
        private string NgayTruc;
        private string MaNV_OLD;
        private string MaCA_OLD;
        private string NgayTruc_OLD;

        public string MaNV_P { get => MaNV; set => MaNV = value; }
        public string MaCA_P { get => MaCA; set => MaCA = value; }
        public string NgayTruc_P { get => NgayTruc; set => NgayTruc = value; }
        public string MaNV_OLD_P { get => MaNV_OLD; set => MaNV_OLD = value; }
        public string MaCA_OLD_P { get => MaCA_OLD; set => MaCA_OLD = value; }
        public string NgayTruc_OLD_P { get => NgayTruc_OLD; set => NgayTruc_OLD = value; }

        public LichTruc_DTO(string manv, string maca, string ngaytruc)
        {
            MaNV_P = manv;
            MaCA_P = maca;
            NgayTruc_P = ngaytruc;
        }
        public LichTruc_DTO(string manv, string maca, string ngaytruc, string manv_old, string maca_old, string ngaytruc_old)
        {
            MaNV_P = manv;
            MaCA_P = maca;
            NgayTruc_P = ngaytruc;
            MaNV_OLD_P = manv_old;
            MaCA_OLD_P= maca_old;
            NgayTruc_OLD_P = ngaytruc_old;
        }

    }
}
