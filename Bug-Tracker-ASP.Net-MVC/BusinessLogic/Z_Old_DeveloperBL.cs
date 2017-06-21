using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class Z_Old_DeveloperBL
    {
        private Z_Old_DeveloperDataAccess developerDAL;
        public Z_Old_DeveloperBL()
        {
            developerDAL = new Z_Old_DeveloperDataAccess();
        }
        public List<Project> GetListProjectByDeveloperID(string developerID)
        {
            return developerDAL.GetListProjectByDeveloperID(developerID);
        }
        public List<Bug> GetDeveloperBugByProjectID(string projectID,string developerID)
        {
            return developerDAL.GetDeveloperBugByProjectID(projectID,developerID);
        }
    }
}
