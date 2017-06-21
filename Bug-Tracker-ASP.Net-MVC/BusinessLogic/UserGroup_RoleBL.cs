using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class UserGroup_RoleBL
    {
        private UserGroup_RoleDataAccess userGroup_RoleDAL;
        public UserGroup_RoleBL()
        {
            userGroup_RoleDAL = new UserGroup_RoleDataAccess();
        }
        public bool CreateUserGroupRole(UserGroup_Role usergroup_role)
        {
            return userGroup_RoleDAL.CreateUserGroupRole(usergroup_role);
        }
        public bool EditUserGroupRole(UserGroup_Role usergroup_role)
        {
            return userGroup_RoleDAL.EditUserGroupRole(usergroup_role);
        }
        public bool DeleteUserGroupRole(UserGroup_Role usergroup_role)
        {
            return userGroup_RoleDAL.DeleteUserGroupRole(usergroup_role);
        }
    }
}
