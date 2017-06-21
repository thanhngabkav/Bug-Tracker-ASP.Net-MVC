using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class BugStatusBL
    {
        private BugStatusDataAccess bugStatusDAL;
        public BugStatusBL()
        {
            bugStatusDAL = new BugStatusDataAccess();
        }
        public bool CreateBugStatus(BugStatus bugstatus)
        {
            return bugStatusDAL.CreateBugStatus(bugstatus);
        }
        public bool EditBugStatus(BugStatus bugstatus)
        {
            return bugStatusDAL.EditBugStatus(bugstatus);
        }
        public bool DeleteBugStatus(BugStatus bugstatus)
        {
            return bugStatusDAL.DeleteBugStatus(bugstatus);
        }
        public List<BugStatus> GetAllBugStatus()
        {
            return bugStatusDAL.GetAllBugStatus();
        }
        public BugStatus GetBugStatusByID(int bugStatusID)
        {
            return bugStatusDAL.GetBugStatusByID(bugStatusID);
        }
    }
}
