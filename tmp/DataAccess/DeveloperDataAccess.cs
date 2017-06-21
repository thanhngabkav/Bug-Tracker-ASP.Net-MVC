using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace DataAccess
{
    public class DeveloperDataAccess
    {
        private BugTrackerDBContext db;
        public DeveloperDataAccess()
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
    }
}
