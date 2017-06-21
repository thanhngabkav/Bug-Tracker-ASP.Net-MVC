using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
namespace BusinessLogic
{
    public class Z_Old_UserBL
    {
        private Z_Old_UserDataAccess userDAL;
        public Z_Old_UserBL()
        {
            userDAL = new Z_Old_UserDataAccess();
        }
        public bool EditUser(User user)
        {
            return userDAL.EditUser(user);
        }
        public User GetUserByID(string userID)
        {
            return userDAL.GetUserByID(userID);
        }
        public User GetUserByUserName(string username)
        {
            return userDAL.GetUserByUserName(username);
        }
        public bool Login(LoginModel loginModel)
        {
            User x = new User();
            SHA_2 mySHA = new SHA_2();
            x = userDAL.GetUserByUserName(loginModel.Username);
            string loginPass = mySHA.Hash(x.UserID + loginModel.Password);
            string userPass = x.Password;
            if (!(x.Equals(null)))
            {
                if (!loginPass.Equals(userPass))
                {
                    return false;
                }else
                {
                    return true;
                }
            }else
            {
                return false;
            }
        }
        public string[] GetUserRoles(int userGroupID)
        {
            return userDAL.GetUserRoles(userGroupID);
        }
        public UserGroup GetUserGroup(int userGroupID)
        {
            return userDAL.GetUserGroupByUserGroupID(userGroupID);
        }
        public List<Bug> GetAllBug()
        {
            return userDAL.GetAllBug();
        }
        public Bug GetBugByID(string bugID)
        {
            return userDAL.GetBugByID(bugID);
        }
      
    }
}
