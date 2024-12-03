using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhapHang_BLL
    {
        NhapHang_DAL DAL = new NhapHang_DAL();
        public string luu_pn(PhieuNhap_DTO pn)
        {
            if (DAL.luu_pn(pn) == "true")
            {
                return "true";
            }
            else
            {
                return DAL.luu_pn(pn);
            }

        }
        public string luu_ctpn(ChiTietPN_DTO ctpn)
        {
            if (DAL.luu_ctpn(ctpn) == "true")
            {
                return "true";
            }
            else
            {
                return DAL.luu_ctpn(ctpn);
            }
        }
    }
}
