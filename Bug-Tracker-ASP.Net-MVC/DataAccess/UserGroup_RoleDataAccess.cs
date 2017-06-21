using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class UserGroup_RoleDataAccess
    {
        private BugTrackerDBContext db;
        public UserGroup_RoleDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        //UserGroup_Role
        public bool CreateUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.UserGroup_Roles.Add(usergroup_role);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.Entry(usergroup_role).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.Entry(usergroup_role).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
