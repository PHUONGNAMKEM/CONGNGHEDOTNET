using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LichTruc_BLL
    {
        LichTruc_DAL DAL = new LichTruc_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<LichTruc_DTO> display()
        {
            return DAL.display();
        }
        public string them(LichTruc_DTO lt)
        {
            try
            {
                string kq = DAL.them(lt);
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
        public bool xoa(LichTruc_DTO lt)
        {
            try
            {
                bool kq = DAL.xoa(lt);
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
        public string sua(LichTruc_DTO lt)
        {
            try
            {
                string kq = DAL.sua(lt);
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
        public string ten_ca(NhanVien_DTO nv)
        {
            return DAL.ten_ca(nv);
        }
    }
}
