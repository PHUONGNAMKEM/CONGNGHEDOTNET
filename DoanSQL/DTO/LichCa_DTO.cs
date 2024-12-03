using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichCa_DTO
    {
        private string MaCA;
        private string TenCA;
        private string TGBD;
        private string TGKT;

        public string MaCA_P { get => MaCA; set => MaCA = value; }
        public string TenCA_P { get => TenCA; set => TenCA = value; }
        public string TGBD_P { get => TGBD; set => TGBD = value; }
        public string TGKT_P { get => TGKT; set => TGKT = value; }
        public LichCa_DTO(string maca, string tenca, string tgbd, string tgkt)
        {
            MaCA_P = maca;
            TenCA_P = tenca;
            TGBD_P = tgbd;
            TGKT_P = tgkt;            
        }
    }
}
