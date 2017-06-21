using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
namespace WebApp.Controllers
{
    public class Z_Old_BugManagementController : Controller
    {
        // GET: BugManagement
        //Cac chuc nang nay thuc ve tester
        //List Bug do tester tao ra
        //List cac bug o trang thai In Progress cua tester do
        //Quan li bug CreateBug, Editbug, Delete Bug (Bug ID co the tao bang ten projectID+teserID + so Bug trong projet + 1)
        //Thong ke (Chua lam)
        public ActionResult Index()
        {
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            List<Bug> listBug = userBL.GetAllBug();
            return View(listBug);
        }
        public ActionResult GetBugByTester(string testerID)
        {
            Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
            List<Bug> listBug = testerBL.GetListBugByTester(testerID);
            return View(listBug);
        }
        public ActionResult GetAllInprocessBug(string testerID)
        {
            Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
            List<Bug> listBug = testerBL.GetAllInprocessBugByTesterID(testerID);
            return View(listBug);
        }
        public ActionResult CreateBug()
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            Z_Old_AnonymusUserBL userBL = new Z_Old_AnonymusUserBL();
            ViewBag.PriorityID = new SelectList(adminBL.GetAllBugPriority(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(adminBL.GetAllBugStatus(), "BugStatusID", "StatusName");
            ViewBag.ProjectID = new SelectList(userBL.GetAllProject(), "ProjectID","ProjectName");
            return View();
        }
        public ActionResult CreateBug(Bug bug)
        {
            string userID = ((Models.UserSession)Session[Models.UserSession.SessionName]).UserID;
            bug.Owner = userID;
            if (ModelState.IsValid)
            {
                Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
                testerBL.CreateBug(bug);
                ViewBag.ErrorMess = "";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMess = "Error! Can not create Bug, Model state is invalid";
            }
            return View();
        }
        public ActionResult EditBug(string bugID)
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            Z_Old_AnonymusUserBL anonymusUserBL = new Z_Old_AnonymusUserBL();
            ViewBag.PriorityID = new SelectList(adminBL.GetAllBugPriority(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(adminBL.GetAllBugStatus(), "BugStatusID", "StatusName");
            ViewBag.ProjectID = new SelectList(anonymusUserBL.GetAllProject(), "ProjectID", "ProjectName");
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            Bug bug = userBL.GetBugByID(bugID);
            return View(bug);
        }
        public ActionResult EditBug(Bug bug)
        {
            if (ModelState.IsValid)
            {
                Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
                testerBL.EditBug(bug);
                return RedirectToAction("Index");
            }else
            {
                ViewBag.ErrorMess = "Error! Can not edit this Bug, Model State is invalid";
            }
            return View();
        }
        public ActionResult DeleteBug(string bugID)
        {
            Z_Old_UserBL userBl = new Z_Old_UserBL();
            Bug bug = userBl.GetBugByID(bugID);
            return View(bug);
        }
        public ActionResult DeleteBug(Bug bug)
        {
            if (ModelState.IsValid)
            {
                Z_Old_TesterBL testerBL = new Z_Old_TesterBL();
                if (testerBL.DeleteBug(bug))
                {
                    return RedirectToAction("Index");
                }else
                {
                    ViewBag.ErrorMess = "Error! Can not delete this project, Update Database Fail";
                }
            }else
            {
                ViewBag.ErrorMess = "Error! Can not delete this project, Data is not valid";
            }
            return View();
        }
    }
}