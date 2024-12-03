using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LichCa_BLL
    {
        LichCa_DAL DAL = new LichCa_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<LichCa_DTO> display()
        {
            return DAL.display();
        }
        public string them(LichCa_DTO lc)
        {
            try
            {
                string kq = DAL.them(lc);
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
        public bool xoa(LichCa_DTO lc)
        {
            try
            {
                bool kq = DAL.xoa(lc);
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
        public string sua(LichCa_DTO lc)
        {
            try
            {
                string kq = DAL.sua(lc);
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
    }
}
