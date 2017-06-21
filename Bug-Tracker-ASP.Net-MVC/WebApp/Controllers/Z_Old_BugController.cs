using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
namespace WebApp.Controllers
{
    public class Z_Old_BugController : Controller
    {
        // GET: Bug
        //Cac chuc nang nay thuoc ve Login User
        //List AllBug, BugDetails
        public ActionResult Index()
        {
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            List<Bug> listBug = userBL.GetAllBug();
            return View(listBug);
        }
        public ActionResult Details(string bugID)
        {
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            Bug bug = userBL.GetBugByID(bugID);
            return View(bug);
        }
    }
}