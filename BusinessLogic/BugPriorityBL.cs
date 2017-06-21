using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class BugPriorityBL
    {
        private BugPriorityDataAccess bugPriorityDAL;
        public BugPriorityBL()
        {
            bugPriorityDAL = new BugPriorityDataAccess();
        }
        public bool CreateBugPriority(BugPriority bugpriority)
        {
            return bugPriorityDAL.CreateBugPriority(bugpriority);
        }
        public bool EditBugPriority(BugPriority bugpriority)
        {
            return bugPriorityDAL.EditBugPriority(bugpriority);
        }
        public bool DeleteBugPriority(BugPriority bugpriority)
        {
            return bugPriorityDAL.DeleteBugPriority(bugpriority);
        }
        public List<BugPriority> GetAllBugPriority()
        {
            return bugPriorityDAL.GetAllBugPriority();
        }
        public BugPriority GetBugPriorityByID(int priorityID)
        {
            return bugPriorityDAL.GetBugPriorityByID(priorityID);
        }
    }
}
