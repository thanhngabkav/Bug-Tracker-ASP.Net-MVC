using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
using WebApp.Models;
using PagedList;
namespace WebApp.Areas.Developer.Controllers
{
    /**
     * Controller nay thuc hien cac chuc nang cua developer, co xac thuc quyen thuc hien
     * Gom cac chuc nang gom:
     * - Liet ke cac project duoc phan cho developer hien tai
     * - Gui request Retest cho 1 bug trong rpoject ma developer do duoc phan 
     * (Viec liet ke cac bug torng 1 project duoc thuc hien o Controler Project)
     * */
   
    public class BugsController : Controller
    {
        private const int NewBug = 1;
        private const int ProcessingBug = 2;
        private const int PageSize = 20;
        // GET: Developer/Bugs
        //Liet ke tat ca cac bug trong cac project duoc allot cho developer hien tai
        [Authorize(Roles = "DeveloperBug")]
        public ActionResult Index(int? page)
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            BugBL bugBL = new BugBL();
            //List<Bug> listBug = bugBL.GetDeveloperBug(userID);
            IPagedList<Bug> listBug = bugBL.GetPageListDeveloperBug(userID,page??1,PageSize);
            return View(listBug);
        }
        //Gui request process bug, chi deverloper duoc allot cho project chua bug nay moi duoc thuc hien
        [Authorize(Roles = "SendProcessingRequest")]
        public ActionResult SendProcessingRequest(string bugID)
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            BugBL bugBL = new BugBL();
            Bug bug = bugBL.GetBugByID(bugID);
            AllotProjectBL allotProjectBL = new AllotProjectBL();
            DeveloperAllotProject listAllotProject = allotProjectBL.GetAllotProjectByDeveloperID_ProjectID(userID, bug.ProjectID);
            //Define Bug Status = 1 is New
            if (listAllotProject != null)
            {
                if (bug.StatusID == NewBug)
                {
                    bug.StatusID = ProcessingBug;
                    bugBL.EditBug(bug);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "This bug status is not NEW or Inprocess";
                    return Redirect("/Home/Error");
                }
            }else
            {
                TempData["Message"] = "Author Error, Please contact to Admin!";
                return Redirect("/Home/Error");
            }
            
        }
    }
}