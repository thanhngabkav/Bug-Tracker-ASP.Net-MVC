using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class Z_Old_DeveloperController : Controller
    {
        // GET: Developer
        //Cac chuc nang nay thuc ve Developer
        //List cac project ma developer do duoc allot
        //List cac bug trong 1 project ma developer do duoc allot
        public ActionResult Index()
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            Z_Old_DeveloperBL developerBL = new Z_Old_DeveloperBL();
            List<Project> list = developerBL.GetListProjectByDeveloperID(userID);
            return View(list);
        }
        public ActionResult SendSendProcessingRequest(string bugID)
        {
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            Bug bug = userBL.GetBugByID(bugID);
            //Define Bug Status = 1 is New
            if (bug.StatusID == 1)
            {
                bug.StatusID = 2;
                Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
                testerBL.EditBug(bug);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMess = "This bug status is not NEW";
                return Redirect("/Home/Error");
            }
        }
    }
}