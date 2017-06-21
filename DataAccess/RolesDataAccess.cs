using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class RolesDataAccess
    {
        private BugTrackerDBContext db;
        public RolesDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        public string[] GetUserRoles(int userGroupID)
        {
            List<string> userRoles = new List<string>();
            List<UserGroup_Role> list = db.UserGroup_Roles.Where(x => x.UserGroupID.Equals(userGroupID)).ToList();
            foreach (UserGroup_Role x in list)
            {
                userRoles.Add((db.Roles.Find(x.RoleID)).RoleName);
            }
            return userRoles.ToArray();
        }
        public List<Role> GetAllRole()
        {
            return db.Roles.OrderBy(x => x.RoleID).ToList();
        }

    }
}
