using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DataAccess
{
    public class TesterDataAccess
    {
        private BugTrackerDBContext db;
        public TesterDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        //Tester Data Access
        // Bug
        public bool CreateBug(Bug bug)
        {
            try
            {
                db.Bugs.Add(bug);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBug(Bug bug)
        {
            try
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBug(Bug bug)
        {
            try
            {
                db.Entry(bug).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Bug> GetListBugByTester(string testerID)
        {
            try
            {
                List<Bug> listBug = db.Bugs.Where(x => x.Owner.Equals(testerID)).OrderByDescending(x => x.DetectionTime).ToList();
                return listBug;
            }
            catch
            {
                return null;
            }
        }
    }
}
