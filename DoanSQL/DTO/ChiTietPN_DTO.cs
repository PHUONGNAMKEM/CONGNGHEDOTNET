using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPN_DTO
    {
        private string maPN;
        private string maHG;
        private string sL;
        private string giaBan;

        public string MaPN_P { get => maPN; set => maPN = value; }
        public string MaHG_P { get => maHG; set => maHG = value; }
        public string SL_P { get => sL; set => sL = value; }
        public string GiaBan_P { get => giaBan; set => giaBan = value; }
        public ChiTietPN_DTO(string mapn, string mahg, string sl, string giaban)
        {
            MaPN_P = mapn;
            MaHG_P = mahg;
            SL_P = sl;
            GiaBan_P = giaban;
        }
    }
}
