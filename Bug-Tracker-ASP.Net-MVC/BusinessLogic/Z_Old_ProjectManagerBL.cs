using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class Z_Old_ProjectManagerBL
    {
        private Z_Old_ProjectManagerDataAccess projectManagerDAL;
        public Z_Old_ProjectManagerBL()
        {
            projectManagerDAL = new Z_Old_ProjectManagerDataAccess();
        }
        public bool CreateDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return projectManagerDAL.CreateDeveloperAllotProject(allotproject);
        }
        public bool EditDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return projectManagerDAL.EditDeveloperAllotProject(allotproject);
        }
        public bool DeleteDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return projectManagerDAL.DeleteDeveloperAllotProject(allotproject);
        }
        public List<Project> GetListProjectByManagerID(string managerID)
        {
            return projectManagerDAL.GetListProjectByManagerID(managerID);
        }

    }
}
