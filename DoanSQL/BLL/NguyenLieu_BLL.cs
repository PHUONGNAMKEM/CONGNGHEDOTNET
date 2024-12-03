using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NguyenLieu_BLL
    {
        NguyenLieu_DAL DAL = new NguyenLieu_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<NguyenLieu_DTO> display()
        {
            return DAL.display();
        }
        public bool them(NguyenLieu_DTO nl)
        {
            try
            {
                bool kq = DAL.them(nl);
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
        public bool xoa(NguyenLieu_DTO nl)
        {
            try
            {
                bool kq = DAL.xoa(nl);
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
        public bool sua(NguyenLieu_DTO nl)
        {
            try
            {
                bool kq = DAL.sua(nl);
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
