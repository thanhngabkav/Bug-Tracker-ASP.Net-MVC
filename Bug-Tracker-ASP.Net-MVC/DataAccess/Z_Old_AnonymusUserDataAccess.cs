using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class Z_Old_AnonymusUserDataAccess
    {
        private BugTrackerDBContext db;
        public Z_Old_AnonymusUserDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        //All User Data Access
        public List<Project> GetAllProject()
        {
            try
            {
                List<Project> listProject = db.Projects.OrderByDescending(x => x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public List<Project> FindProjectByName(string projectName)
        {
            try
            {
                List<Project> listProject = db.Projects.Where(x => x.Name.Contains(projectName)).OrderByDescending(x => x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public Project GetProjectById(string projectID)
        {
            try
            {
                Project project = db.Projects.Find(projectID);
                return project;
            }
            catch
            {
                return null;
            }
        }
       
    }
}
