using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
namespace BusinessLogic
{
    public class Z_Old_TesterBL
    {
        private Z_Old_TesterDataAccess testerDAL;
        public Z_Old_TesterBL()
        {
            testerDAL = new Z_Old_TesterDataAccess();
        }
        public bool CreateBug(Bug bug)
        {
            return testerDAL.CreateBug(bug);
        }
        public bool EditBug(Bug bug)
        {
            return testerDAL.EditBug(bug);
        }
        public bool DeleteBug(Bug bug)
        {
            return testerDAL.DeleteBug(bug);
        }
        public List<Bug> GetListBugByTester(string testerID)
        {
            return testerDAL.GetListBugByTester(testerID);
        }
        public List<Bug> GetAllInprocessBugByTesterID(string testerID)
        {
            return testerDAL.GetAllInprocessBugByTesterID(testerID);
        }
    }
}
