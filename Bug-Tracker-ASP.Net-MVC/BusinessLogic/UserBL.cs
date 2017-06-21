using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using PagedList;
using PagedList.Mvc;
namespace BusinessLogic
{
    public class UserBL
    {
        private UserDataAccess userDAL;
        public UserBL()
        {
            userDAL = new UserDataAccess();
        }
        public bool CreateUser(User user)
        { 
            SHA_2 mySHA = new SHA_2();
            string createPass = user.UserID + user.Password;
            user.Password = mySHA.Hash(createPass);
            return userDAL.CreateUser(user);
        }
        public bool EditUser(User user)
        {
            SHA_2 mySHA = new SHA_2();
            string createPass = user.UserID + user.Password;
            user.Password = mySHA.Hash(createPass);
            return userDAL.EditUser(user);
        }
        public bool DeleteUser(User user)
        {
            return userDAL.DeleteUser(user);
        }
        public List<User> GetAllUser()
        {
            return userDAL.GetAllUser();
        }
        public User GetUserByID(string userID)
        {
            return userDAL.GetUserByID(userID);
        }
        public User GetUserByUserName(string userName)
        {
            return userDAL.GetUserByUserName(userName);
        }
        public List<User> GetUsersByUserGroup(int userGroupID)
        {
            return userDAL.GetUsersByUserGroup(userGroupID);
        }
        public List<User> GetListAllotedDeveloperByProjectID(string projectID)
        {
            return userDAL.GetListAllotedDeveloperByProjectID(projectID);
        }
        public IPagedList<User> GetPageListUser(int page, int pageSize)
        {
            return userDAL.GetPageListUser(page, pageSize);
        }
        public IPagedList<User> GetPageListUserByUserGroup(int userGroupID, int page, int pageSize)
        {
            return userDAL.GetPageListUserByUserGroup(userGroupID, page, pageSize);
        }
        public IPagedList<User> GetPageListAllotedDeveloperByProjectID(string projectID, int page, int pageSize)
        {
            return userDAL.GetPageListAllotedDeveloperByProjectID(projectID, page, pageSize);
        }
        public bool Login(LoginModel loginModel)
        {
           
            SHA_2 mySHA = new SHA_2();
            User x = userDAL.GetUserByUserName(loginModel.Username);
            if (x==null)
            {
                return false;
            }
            else
            {
                string loginPass = mySHA.Hash(x.UserID + loginModel.Password);
                string userPass = x.Password;
                if (!loginPass.Equals(userPass))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
