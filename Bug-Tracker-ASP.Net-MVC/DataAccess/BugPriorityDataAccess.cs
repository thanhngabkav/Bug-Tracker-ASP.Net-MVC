using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DataAccess
{
    public class BugPriorityDataAccess
    {
        private BugTrackerDBContext db;
        public BugPriorityDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        public bool CreateBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.BugPriorities.Add(bugpriority);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.Entry(bugpriority).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.Entry(bugpriority).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<BugPriority> GetAllBugPriority()
        {
            try
            {
                return db.BugPriorities.ToList();
            }
            catch
            {
                return null;
            }
        }
        public BugPriority GetBugPriorityByID(int priorityID)
        {
            return db.BugPriorities.Where(x=>x.PriorityID==priorityID).SingleOrDefault();
        }
    }
}
