using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class Z_Old_AnonymusUserBL
    {
        private Z_Old_AnonymusUserDataAccess anonymusUserDAL;
        public Z_Old_AnonymusUserBL()
        {
            anonymusUserDAL = new Z_Old_AnonymusUserDataAccess();
        }
        public List<Project> GetAllProject()
        {
            return anonymusUserDAL.GetAllProject();
        }
        public List<Project> FindProjectByName(string projectName)
        {
            return anonymusUserDAL.FindProjectByName(projectName);
        }
        public Project GetProjectById(string projectID)
        {
            return anonymusUserDAL.GetProjectById(projectID);
        }
    }
}
