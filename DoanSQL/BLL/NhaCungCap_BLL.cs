using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        NhaCungCap_DAL DAL = new NhaCungCap_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<NhaCungCap_DTO> display()
        {
            return DAL.display();
        }
        public bool them(NhaCungCap_DTO ncc)
        {
            try
            {
                bool kq = DAL.them(ncc);
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
        public bool xoa(NhaCungCap_DTO ncc)
        {
            try
            {
                bool kq = DAL.xoa(ncc);
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
        public bool sua(NhaCungCap_DTO ncc)
        {
            try
            {
                bool kq = DAL.sua(ncc);
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