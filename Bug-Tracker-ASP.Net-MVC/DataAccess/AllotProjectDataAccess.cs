using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class AllotProjectDataAccess
    {
        private BugTrackerDBContext db;
        public AllotProjectDataAccess()
        {
            db = new BugTrackerDBContext();
        }
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
        public List<DeveloperAllotProject> GetDeveloperAllotProjectByProjectID(string projectID)
        {
            return db.AllotProjects.Where(x => x.ProjectID.Equals(projectID)).ToList();
        }
        public DeveloperAllotProject GetAllotProjectByDeveloperID_ProjectID(string developerID, string projectID)
        {
            return db.AllotProjects.Where(x => x.DeveloperID.Equals(developerID) && x.ProjectID.Equals(projectID)).SingleOrDefault();
        }
    }
}
