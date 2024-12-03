using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        //public List<User_DTO> getAllUserName()
        //{
        //    return userDAL.getAllUserName();
        //}
        public List<string> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public List<string> GetAllTables()
        {
            return userDAL.GetAllTables();
        }
        public List<NhanVien_DTO> GetAllStaff()
        {
            return userDAL.GetAllStaff();
        }
        public void GrantAcc(string manv, string username)
        {
            userDAL.GrantAcc(manv, username);
        }
        public void GrantPermissions(string username, string table, string permissions)
        {
            userDAL.GrantPermissions(username, table, permissions); 
        }
    }
}
