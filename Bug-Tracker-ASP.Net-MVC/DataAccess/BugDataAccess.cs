using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
using PagedList;
namespace DataAccess
{
    public class BugDataAccess
    {
        private BugTrackerDBContext db;
        public BugDataAccess()
        {
            db = new BugTrackerDBContext();
        }
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
                throw new Exception(ex.Message);
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
                List<Bug> listBug = db.Bugs.Where(x => x.Owner.Equals(testerID)).OrderBy(x => x.Priority).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToList();
                return listBug;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Bug> GetPageListBugByTester(string testerID, int page, int pageSize)
        {
            try
            {
                IPagedList<Bug> listBug = db.Bugs.Where(x => x.Owner.Equals(testerID)).OrderBy(x => x.PriorityID).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToPagedList(page,pageSize);
                return listBug;
            }
            catch
            {
                return null;
            }
        }
        public List<Bug> GetAllBug()
        {
            try
            {
                List<Bug> listBug = db.Bugs.OrderBy(x => x.PriorityID).ThenBy(x => x.StatusID).ToList();
                return listBug;
            }
            catch(Exception ex)
            {
                return null;

            }
        }
        public IPagedList<Bug> GetPageListBug(int page, int pageSize)
        {
            return db.Bugs.OrderBy(x => x.PriorityID).ThenBy(x => x.StatusID).ToPagedList(page, pageSize);
        }
        public List<Bug> GetAllInprocessBugByTesterID(string testerID)
        {
            //define buf inprocess has statusID is 2
            try
            {
                return db.Bugs.Where(x => x.StatusID == 2 & x.Owner.Equals(testerID)).OrderBy(x => x.Priority).ThenByDescending(x => x.DetectionTime).ToList();
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Bug> GetPageListInprocessBugByTesterID(string testerID,int page,int pageSize)
        {
            //define buf inprocess has statusID is 2
            try
            {
                return db.Bugs.Where(x => x.StatusID == 2 & x.Owner.Equals(testerID)).OrderBy(x => x.PriorityID).ThenByDescending(x => x.DetectionTime).ToPagedList(page,pageSize);
            }
            catch
            {
                return null;
            }
        }
        public Bug GetBugByID(string bugID)
        {
            try
            {
                return db.Bugs.Where(x => x.BugID.Equals(bugID)).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public List<Bug> GetDeveloperBug(string developerID)
        {
            try
            {
                List<Bug> listBug = (from b in db.Bugs
                                     join a in db.AllotProjects on b.ProjectID equals a.ProjectID
                                     where a.DeveloperID.Equals(developerID)
                                     select b).OrderBy(x => x.Priority).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToList();
                return listBug;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Bug> GetPageListDeveloperBug(string developerID, int page, int pageSize)
        {
            try
            {
                IPagedList<Bug> listBug = (from b in db.Bugs
                                     join a in db.AllotProjects on b.ProjectID equals a.ProjectID
                                     where a.DeveloperID.Equals(developerID)
                                     select b).OrderBy(x => x.PriorityID).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToPagedList(page,pageSize);
                return listBug;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Bug> GetAllBugByProjectID(string projectID)
        {
            try
            {
                return db.Bugs.Where(x => x.ProjectID.Equals(projectID)).OrderBy(x => x.Priority).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToList();
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Bug> GetPageListBugByProjectID(string projectID,int page,int pageSize)
        {

            try
            {
                return db.Bugs.Where(x => x.ProjectID.Equals(projectID)).OrderBy(x => x.PriorityID).ThenBy(x => x.StatusID).ThenByDescending(x => x.DetectionTime).ToPagedList(page,pageSize);
            }
            catch
            {
                return null;
            }
        }
        public long GetBugCount()
        {
            return db.Bugs.Count();
        }
        public long GetBugCountByProjecctID(string projectID)
        {
            return db.Bugs.Where(x=>x.ProjectID==projectID).Count();
        }

    }
}
