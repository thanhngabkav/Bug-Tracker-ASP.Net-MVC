using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace DataAccess
{
    public class Z_Old_DeveloperDataAccess
    {
        private BugTrackerDBContext db;
        public Z_Old_DeveloperDataAccess()
        {
            db = new BugTrackerDBContext();
        }      
        public List<Project> GetListProjectByDeveloperID(string developerID)
        {
            try
            {
                List<Project> listProject = (from p in db.Projects
                                             join a in db.AllotProjects on p.ProjectID equals a.ProjectID
                                             where a.DeveloperID.Equals(developerID)
                                             select p).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public List<Bug> GetDeveloperBugByProjectID(string projectID, string developerID)
        {
            try
            {
                DeveloperAllotProject allotProject = db.AllotProjects.Where(x => x.DeveloperID.Equals(developerID)).SingleOrDefault();
                if (allotProject != null)
                    return db.Bugs.Where(x => x.ProjectID.Equals(projectID) && x.ProjectID.Equals(allotProject.ProjectID)).ToList();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
