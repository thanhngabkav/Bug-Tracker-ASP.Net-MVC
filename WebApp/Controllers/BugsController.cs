using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
using WebApp.Models;
using PagedList;
using PagedList.Mvc;
namespace WebApp.Controllers
{
    public class BugsController : Controller
    {
        private const int PageSize= 20;
        /**
         * Contrller nay thuc hien cac chuc nang hien thi bug (Khong thuc hien cac chuc nang quan li)
         * - Cho phep Liet ke tat ca cac bugs dang co trong he thong (Co bieu do thong ke hoac phan loai -- chua lam)
         * - Liet ke cac bug theo loai (Chua lam)
         * - Cac bug cua 1 project nao do
         * - Thong tin chi tiet cua bug, cac bug cua 1 tester
         * */
        // GET: Bug
        //Neu user la tester se cho create,
        private BugBL bugBL = new BugBL();
        //Cac chuc nang thuc ve tat ca user
        public ActionResult Index(int? page)
        {
            var model = bugBL.GetPageListBug(page ?? 1, PageSize);
            return View(model);
        }
        //Liet ke cac bug cua 1 project, chi user da dang nhap moi duoc thuc hien chuc nang nay
        [Authorize]
        public ActionResult Project(string projectID,int? page)
        {
            var model = bugBL.GetPageListBugByProjectID(projectID, page ?? 1, PageSize);
            return View(model);
        }
/*
        public ActionResult CreateBug()
        {
            BugPriorityBL priorityBL = new BugPriorityBL();
            BugStatusBL bugstatusBL = new BugStatusBL();
            ProjectBL projectBL = new ProjectBL();
            ViewBag.PriorityID = new SelectList(priorityBL.GetAllBugPriority(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(bugstatusBL.GetAllBugStatus(), "BugStatusID", "StatusName");
            ViewBag.ProjectID = new SelectList(projectBL.GetAllProject(), "ProjectID", "ProjectName");
            return View();
        }
        [HttpPost]
        public ActionResult CreateBug(Bug bug)
        {
            string userID = ((Models.UserSession)Session[Models.UserSession.SessionName]).UserID;
            bug.Owner = userID;
            if (ModelState.IsValid)
            {
                bugBL.CreateBug(bug);
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
            Bug bug = bugBL.GetBugByID(bugID);
            UserBL userBL = new UserBL();
            UserGroupBL userGroupBL = new UserGroupBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            User user = userBL.GetUserByID(userID);
            //Define Admin Group ID is 1
            if (bug.Owner.Equals(userID)||user.UserGroupID == 1)
            {
                BugPriorityBL priorityBL = new BugPriorityBL();
                BugStatusBL bugstatusBL = new BugStatusBL();
                ProjectBL projectBL = new ProjectBL();
                ViewBag.PriorityID = new SelectList(priorityBL.GetAllBugPriority(), "PriorityID", "PriorityName");
                ViewBag.StatusID = new SelectList(bugstatusBL.GetAllBugStatus(), "BugStatusID", "StatusName");
                ViewBag.ProjectID = new SelectList(projectBL.GetAllProject(), "ProjectID", "ProjectName");
                return View(bug);
            }else
            {
                ViewBag.ErrorMess = "Ban khong co quyen thuc hien chuc nang nay, vui long lien he voi Admin";
                return Redirect("/Home/Error");
            }
        }
        [HttpPost]
        public ActionResult EditBug(Bug bug)
        {
            if (ModelState.IsValid)
            {
                bugBL.EditBug(bug);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMess = "Error! Can not edit this Bug, Model State is invalid";
            }
            return View();
        }*/
        //Hien thi thong tin chi tiet cua Bug, chi user da dang nhap moi duoc thuc hien chuc nang nay
        [Authorize]
        public ActionResult Details(string bugID)
        {
            Bug bug = bugBL.GetBugByID(bugID);
            return View(bug);
        }
/*
        public ActionResult DeleteBug(string bugID)
        {
            Bug bug = bugBL.GetBugByID(bugID);
            UserBL userBL = new UserBL();
            UserGroupBL userGroupBL = new UserGroupBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            User user = userBL.GetUserByID(userID);
            //Define Admin Group ID is 1
            if (bug.Owner.Equals(userID) || user.UserGroupID == 1)
            {
                return View(bug);
            }else
            {
                ViewBag.ErrorMess = "Ban khong co quyen thuc hien chuc nang nay, vui long lien he voi Admin";
                return Redirect("/Home/Error");
            }
        }
        [HttpPost]
        public ActionResult DeleteBug(Bug bug)
        {
            if (ModelState.IsValid)
            {
                if (bugBL.DeleteBug(bug))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMess = "Error! Can not delete this project, Update Database Fail";
                }
            }
            else
            {
                ViewBag.ErrorMess = "Error! Can not delete this project, Data is not valid";
            }
            return View();
        }
        public ActionResult GetBugByTester(string testerID)
        {
            BugBL bugBL = new BugBL();
            List<Bug> listBug = bugBL.GetListBugByTester(testerID);
            return Json(listBug, JsonRequestBehavior.AllowGet);
        }*/
        //Liet ke cac bug cua 1 tester, chi co user da dang nhap dc thuc hien
        [Authorize]
        public ActionResult TesterBug(string testerID,int? page)
        {
            var model = bugBL.GetPageListBugByTester(testerID, page ?? 1, PageSize);
            return View(model);
        }
/*
        //Liet ke cac bug cua tester hien tai, chi co tester duoc thuc hien
        public ActionResult MyBug()
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            List<Bug> listBug = bugBL.GetListBugByTester(userID);
            return View(listBug);
        }
        //Liet ke cac bug co status inprocess cua tester hien tai, chi co tester duoc thuc hien
        public ActionResult InprocessBug()
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            List<Bug> listBug = bugBL.GetAllInprocessBugByTesterID(userID);
            return View(listBug);
        }
*/
        
    }
}