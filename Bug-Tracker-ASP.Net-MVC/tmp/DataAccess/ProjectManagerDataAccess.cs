using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace DataAccess
{
    public class ProjectManagerDataAccess
    {
        private BugTrackerDBContext db;
        public ProjectManagerDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        //Project Manager Data Access
        public bool CreateDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.AllotProjects.Add(allotproject);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.Entry(allotproject).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.Entry(allotproject).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Project> GetListProjectByManagerID(string managerID)
        {
            try
            {
                List<Project> listProject = db.Projects.Where(x => x.ManagerID.Equals(managerID)).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
    }
}
