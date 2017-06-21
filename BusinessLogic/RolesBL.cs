using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class RolesBL
    {
        private RolesDataAccess roleDAL;
        public RolesBL()
        {
            roleDAL = new RolesDataAccess();
        }
        public string[] GetUserRoles(int userGroupID)
        {
            return roleDAL.GetUserRoles(userGroupID);
        }
        public List<Role> GetAllRole()
        {
            return roleDAL.GetAllRole();
        }

    }
}
