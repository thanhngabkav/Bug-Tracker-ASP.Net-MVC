using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using PagedList;
namespace BusinessLogic
{
    public class BugBL
    {
        private BugDataAccess bugDAL;
        public BugBL()
        {
            bugDAL = new BugDataAccess();
        }
        public bool CreateBug(Bug bug)
        {
            return bugDAL.CreateBug(bug);
        }
        public bool EditBug(Bug bug)
        {
            return bugDAL.EditBug(bug);
        }
        public bool DeleteBug(Bug bug)
        {
            return bugDAL.DeleteBug(bug);
        }
        public List<Bug> GetListBugByTester(string testerID)
        {
            return bugDAL.GetListBugByTester(testerID);
        }
        public IPagedList<Bug> GetPageListBugByTester(string testerID,int page, int pageSize)
        {
            return bugDAL.GetPageListBugByTester(testerID,page,pageSize);
        }
        public List<Bug> GetAllBug()
        {
            return bugDAL.GetAllBug();
        }
        public IPagedList<Bug> GetPageListBug(int page, int pageSize)
        {
            return bugDAL.GetPageListBug(page, pageSize);
        }
        public List<Bug> GetAllInprocessBugByTesterID(string testerID)
        {
            //define buf inprocess has statusID is 2
            return bugDAL.GetAllInprocessBugByTesterID(testerID);
        }
        public IPagedList<Bug> GetPageListInprocessBugByTesterID(string testerID, int page, int pageSize)
        {
            //define buf inprocess has statusID is 2
            return bugDAL.GetPageListInprocessBugByTesterID(testerID, page, pageSize);
        }
        public Bug GetBugByID(string bugID)
        {
            return bugDAL.GetBugByID(bugID);
        }
        public List<Bug> GetDeveloperBug(string developerID)
        {
            return bugDAL.GetDeveloperBug(developerID);
        }
        public IPagedList<Bug> GetPageListDeveloperBug(string developerID, int page, int pageSize)
        {
            return bugDAL.GetPageListDeveloperBug(developerID, page, pageSize);
        }
        public List<Bug> GetAllBugByProjectID(string projectID)
        {
            return bugDAL.GetAllBugByProjectID(projectID);
        }
        public IPagedList<Bug> GetPageListBugByProjectID(string projectID, int page, int pageSize)
        {

            return bugDAL.GetPageListBugByProjectID(projectID, page, pageSize);
        }
        public long GetBugCount()
        {
            return bugDAL.GetBugCount();
        }
        public long GetBugCountByProjecctID(string projectID)
        {
            return bugDAL.GetBugCountByProjecctID(projectID);
        }
    }
}
