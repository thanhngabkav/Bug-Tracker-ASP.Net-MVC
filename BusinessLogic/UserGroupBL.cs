using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class UserGroupBL
    {
        private UserGroupDataAccess userGroupDAL;
        public UserGroupBL()
        {
            userGroupDAL = new UserGroupDataAccess();
        }
        public bool CreateUserGroup(UserGroup userGroup)
        {
            return userGroupDAL.CreateUserGroup(userGroup);
        }
        public bool EditUserGroup(UserGroup userGroup)
        {
            return userGroupDAL.EditUserGroup(userGroup);
        }
        public bool DeleteUserGroup(UserGroup userGroup)
        {
            return userGroupDAL.DeleteUserGroup(userGroup);
        }
        public UserGroup GetUserGroupByUserGroupID(int userGroupID)
        {
            return userGroupDAL.GetUserGroupByUserGroupID(userGroupID);
        }
        public List<UserGroup> GetAllUserGroup()
        {
            return userGroupDAL.GetAllUserGroup();
        }
    }
}
