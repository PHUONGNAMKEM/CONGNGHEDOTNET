using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BanHang_BLL
    {
        BanHang_DAL DAL = new BanHang_DAL();
        public string luu_hd(HoaDon_DTO hd)
        {
            if(DAL.luu_hd(hd) == "true")
            {
                return "true";
            }
            else
            {
                return DAL.luu_hd(hd);
            }
         
        }
        public string luu_cthd(ChiTietHoaDon_DTO cthd)
        {
            if (DAL.luu_cthd(cthd) == "true")
            {
                return "true";
            }
            else
            {
                return DAL.luu_cthd(cthd);
            }
        }
    }
}
