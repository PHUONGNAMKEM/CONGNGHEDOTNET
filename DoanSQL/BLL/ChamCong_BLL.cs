using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChamCong_BLL
    {
        ChamCong_DAL DAL = new ChamCong_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<ChamCong_DTO> display()
        {
            return DAL.display();
        }
        public string them(ChamCong_DTO cc)
        {
            try
            {
                string kq = DAL.them(cc);
                if (kq == "true")
                {
                    return "true";
                }
                else return kq;
            }
            catch (Exception ex)
            {
                return "false";
            }

        }
        public bool xoa(ChamCong_DTO cc)
        {
            try
            {
                bool kq = DAL.xoa(cc);
                if (kq == true)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public string sua(ChamCong_DTO cc)
        {
            try
            {
                string kq = DAL.sua(cc);
                if (kq == "true")
                {
                    return "true";
                }
                else return kq;
            }
            catch (Exception ex)
            {
                return "false";
            }

        }
        public List<NhanVien_DTO> getall_manv()
        {
            return DAL.getall_manv();
        }
        public List<LichCa_DTO> getall_lichca()
        {
            return DAL.getall_lichca();
        }
    }
}
