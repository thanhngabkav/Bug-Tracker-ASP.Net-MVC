using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
namespace BusinessLogic
{
    public class AllotProjectBL
    {
        private AllotProjectDataAccess allotProjectDAL;
        public AllotProjectBL()
        {
            allotProjectDAL = new AllotProjectDataAccess();
        }
        public bool CreateDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return allotProjectDAL.CreateDeveloperAllotProject(allotproject);
        }
        public bool EditDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return allotProjectDAL.EditDeveloperAllotProject(allotproject);
        }
        public bool DeleteDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            return allotProjectDAL.DeleteDeveloperAllotProject(allotproject);
        }
        public List<DeveloperAllotProject> GetDeveloperAllotProjectByProjectID(string projectID)
        {
            return allotProjectDAL.GetDeveloperAllotProjectByProjectID(projectID);
        }
        public DeveloperAllotProject GetAllotProjectByDeveloperID_ProjectID(string developerID, string projectID)
        {
            return allotProjectDAL.GetAllotProjectByDeveloperID_ProjectID(developerID, projectID);
        }
    }
}
