using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class Z_Old_UserDataAccess
    {
        private BugTrackerDBContext db;
        public Z_Old_UserDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        public bool CreateUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<User> GetAllUser()
        {
            return db.Users.ToList();
        }
        public User GetUserByID(string userID)
        {
            return db.Users.Find(userID);
        }
        public User GetUserByUserName(string userName)
        {
            return db.Users.Where(x => x.UserName.Equals(userName)).SingleOrDefault();
        }
        public List<Bug> GetAllBug()
        {
            try
            {
                List<Bug> listBug = db.Bugs.ToList();
                return listBug;
            }
            catch
            {
                return null;
            }
        }
        public Bug GetBugByID(string bugID)
        {
            try
            {
                return db.Bugs.Where(x => x.BugID.Equals(bugID)).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public string[] GetUserRoles(int userGroupID)
        {
            List<string> userRoles = new List<string>();
            List<UserGroup_Role> list = db.UserGroup_Roles.Where(x => x.UserGroupID.Equals(userGroupID)).ToList();
            foreach (UserGroup_Role x in list)
            {
                userRoles.Add(db.Roles.Find(x.RoleID).RoleName);
            }
            return userRoles.ToArray();
        }
        public UserGroup GetUserGroupByUserGroupID(int userGroupID)
        {
            try
            {
                return db.UserGroups.Find(userGroupID);
            }
            catch
            {
                return null;
            }
        }
    }
}
