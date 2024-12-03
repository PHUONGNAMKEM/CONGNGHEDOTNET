using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhap_BLL
    {
        PhieuNhap_DAL DAL = new PhieuNhap_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<PhieuNhap_DTO> display()
        {
            return DAL.display();
        }
        public bool them(PhieuNhap_DTO pn)
        {
            try
            {
                bool kq = DAL.them(pn);
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
        public bool xoa(PhieuNhap_DTO pn)
        {
            try
            {
                bool kq = DAL.xoa(pn);
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
        public bool sua(PhieuNhap_DTO pn)
        {
            try
            {
                bool kq = DAL.sua(pn);
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
    }
}