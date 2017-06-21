using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DataAccess
{
    public class BugStatusDataAccess
    {
        private BugTrackerDBContext db;
        public BugStatusDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        public bool CreateBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.BugStatuses.Add(bugstatus);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.Entry(bugstatus).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.Entry(bugstatus).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<BugStatus> GetAllBugStatus()
        {
            try
            {
                return db.BugStatuses.ToList();
            }
            catch
            {
                return null;
            }
        }
        public BugStatus GetBugStatusByID(int bugStatusID)
        {
            return db.BugStatuses.Where(x => x.BugStatusID == bugStatusID).SingleOrDefault();
        }
    }
}
