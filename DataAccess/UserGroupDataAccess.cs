using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class UserGroupDataAccess
    {
        private BugTrackerDBContext db;
        public UserGroupDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        //User Group
        public bool CreateUserGroup(UserGroup userGroup)
        {
            try
            {
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUserGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUserGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        public List<UserGroup> GetAllUserGroup()
        {
            try
            {
                return db.UserGroups.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
