using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TinhLuong_BLL
    {
        TinhLuong_DAL DAL = new TinhLuong_DAL();
        public void login(Login_DTO login)
        {
            DAL.Login(login);
        }
        public List<TinhLuong_DTO> display(string day, string month, string year)
        {
            return DAL.display(day, month, year);
        }
    }
}
