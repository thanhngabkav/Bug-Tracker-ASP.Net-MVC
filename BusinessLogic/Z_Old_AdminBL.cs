using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class Z_Old_AdminBL
    {
        private Z_Old_AdminDataAccess adminDAL;
        public Z_Old_AdminBL()
        {
            adminDAL = new Z_Old_AdminDataAccess();
        }
        public bool CreateUserGroup(UserGroup userGroup)
        {
            return adminDAL.CreateUserGroup(userGroup);
        }
        public bool EditUserGroup(UserGroup userGroup)
        {
            return adminDAL.EditUserGroup(userGroup);
        }
        public bool DeleteUserGroup(UserGroup userGroup)
        {
            return adminDAL.DeleteUserGroup(userGroup);
        }
        public List<UserGroup> GetAllUserGroup()
        {
            return adminDAL.GetAllUserGroup();
        }
        public bool CreateUserGroupRole(UserGroup_Role userGroup_role)
        {
            return adminDAL.CreateUserGroupRole(userGroup_role);
        }
        public bool EditUserGroupRole(UserGroup_Role userGroup_role)
        {
            return adminDAL.EditUserGroupRole(userGroup_role);
        }
        public bool DeleteUserGroupRole(UserGroup_Role userGroup_role)
        {
            return adminDAL.DeleteUserGroupRole(userGroup_role);
        }
        public bool CreateUser(User user)
        {
            SHA_2 mySHA = new SHA_2();
            string createPass = user.UserID + user.Password;
            user.Password = mySHA.Hash(createPass);
            return adminDAL.CreateUser(user);
        }
        public bool EditUser(User user)
        {
            return adminDAL.EditUser(user);
        }
        public bool DeleteUser(User user)
        {
            return adminDAL.DeleteUser(user);
        }
        public List<User> GetAllUser()
        {
            return adminDAL.GetAllUser();
        }
        public List<User> GetUsersByUserGroup(int userGroupID)
        {
            return adminDAL.GetUsersByUserGroup(userGroupID);
        }
        public bool CreateBugStatus(BugStatus bugstatus)
        {
            return adminDAL.CreateBugStatus(bugstatus);
        }
        public bool EditBugStatus(BugStatus bugstatus)
        {
            return adminDAL.EditBugStatus(bugstatus);
        }
        public bool DeleteBugStatus(BugStatus bugstatus)
        {
            return adminDAL.DeleteBugStatus(bugstatus);
        }
        public List<BugStatus> GetAllBugStatus()
        {
            return adminDAL.GetAllBugStatus();
        }
        public bool CreateBugPriority(BugPriority bugpriority)
        {
            return adminDAL.CreateBugPriority(bugpriority);
        }
        public bool EditBugPriority(BugPriority bugpriority)
        {
            return adminDAL.EditBugPriority(bugpriority);
        }
        public bool DeleteBugPriority(BugPriority bugpriority)
        {
            return adminDAL.DeleteBugPriority(bugpriority);
        }
        public List<BugPriority> GetAllBugPriority()
        {
            return adminDAL.GetAllBugPriority();
        }
        public bool CreateProject(Project project)
        {
            return adminDAL.CreateProject(project);
        }
        public bool EditProject(Project project)
        {
            return adminDAL.EditProject(project);
        }
        public bool DeleteProject(Project project)
        {
            return adminDAL.DeleteProject(project);
        }
    }
}
