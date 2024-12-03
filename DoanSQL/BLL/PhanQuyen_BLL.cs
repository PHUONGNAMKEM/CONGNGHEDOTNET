using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanQuyen_BLL
    {
        PhanQuyen_DAL DAL = new PhanQuyen_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<PhanQuyen_DTO> display()
        {
            return DAL.display();
        }

        public string layQuyen_For_PhanQuyen(int maquyen)
        {
            return DAL.layQuyen_For_PhanQuyen(maquyen);
        }

        public string layQuyen_For_ThuHoiQuyen(int maquyen)
        {
            return DAL.layQuyen_For_ThuHoiQuyen(maquyen);
        }

        public bool phanQuyen_For_User(int maquyen, string username)
        {
            return DAL.phanQuyen_For_User(maquyen, username);
        }
        public bool thuHoiQuyen_For_User(int maquyen, string username)
        {
            return DAL.thuHoiQuyen_For_User(maquyen, username);
        }

        //public bool them(PhieuNhap_DTO pn)
        //{
        //    try
        //    {
        //        bool kq = DAL.them(pn);
        //        if (kq == true)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public bool xoa(PhieuNhap_DTO pn)
        //{
        //    try
        //    {
        //        bool kq = DAL.xoa(pn);
        //        if (kq == true)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public bool sua(PhieuNhap_DTO pn)
        //{
        //    try
        //    {
        //        bool kq = DAL.sua(pn);
        //        if (kq == true)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
    }
}