using System.Web.Mvc;
using BusinessLogic;
using Models;
using WebApp.Models;
using System.Collections.Generic;
using PagedList;

namespace WebApp.Areas.Tester.Controllers
{
    /**
     * Controller nay thuc hien cac chuc nang quan li bug cua tester
     * - Hien thi cac bug do tester hien tai quan li
     * - Tao bug
     * - Edit bug
     * - Delete bug
     * - Hien thi cac bug o trang thai Inprocess cua tester hien
     * */
    public class BugsController : Controller
    {
        private const int PageSize = 20;
        // GET: Tester/Bugs
        //Liet ke cac Bugs do tester hien tai quan li
        [Authorize(Roles = "ViewTesterBug")]
        public ActionResult Index(int? page)
        {
            BugBL bugBL = new BugBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            // List<Bug> listBug = bugBL.GetListBugByTester(userID);
            IPagedList<Bug> listBug = bugBL.GetPageListBugByTester(userID, page ?? 1, PageSize);
            return View(listBug);
        }
        //Hien thi view tao bug
        [Authorize(Roles = "CreateBug")]
        public ActionResult CreateBug()
        {
            BugPriorityBL priorityBL = new BugPriorityBL();
            BugStatusBL bugstatusBL = new BugStatusBL();
            ProjectBL projectBL = new ProjectBL();
            ViewBag.PriorityID = new SelectList(priorityBL.GetAllBugPriority(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(bugstatusBL.GetAllBugStatus(), "BugStatusID", "StatusName");
            ViewBag.ProjectID = new SelectList(projectBL.GetAllProject(), "ProjectID", "Name");
            return View();
        }
        //Hien thi view tao bug dua vao projectID
        [Authorize(Roles = "CreateBug")]
        public ActionResult AddBug (string projectID)
        {
            BugPriorityBL priorityBL = new BugPriorityBL();
            BugStatusBL bugstatusBL = new BugStatusBL();
            ProjectBL projectBL = new ProjectBL();
            ViewBag.PriorityID = new SelectList(priorityBL.GetAllBugPriority(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(bugstatusBL.GetAllBugStatus(), "BugStatusID", "StatusName");
            Project project = projectBL.GetProjectById(projectID);
            ViewBag.ProjectID = projectID;
            ViewBag.ProjectLabel = project.Name + " - " + project.ProjectID;
            return View();
        }
        //Tao Bug
        [HttpPost]
        [Authorize(Roles = "CreateBug")]
        public ActionResult CreateBug(Bug bug)
        {
            string userID = ((Models.UserSession)Session[Models.UserSession.SessionName]).UserID;
            bug.Owner = userID;
            if (ModelState.IsValid)
            {
                BugBL bugBL = new BugBL();
                bug.BugID = bug.ProjectID + "_" + bugBL.GetBugCountByProjecctID(bug.ProjectID)+1 + "_" + (bugBL.GetBugCount()+1);
                bugBL.CreateBug(bug);
                ViewBag.ErrorMess = "";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"]  = "Error! Can not create Bug, Model state is invalid";
            }
            return View();
        }
        //Hien thi view Edit bug
        [Authorize(Roles = "EditBug")]
        public ActionResult EditBug(string bugID)
        {
            BugBL bugBL = new BugBL();
            Bug bug = bugBL.GetBugByID(bugID);
            UserBL userBL = new UserBL();
            UserGroupBL userGroupBL = new UserGroupBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            User user = userBL.GetUserByID(userID);
            //Define Admin Group ID is 1
            if (bug.Owner.Equals(userID) || user.UserGroupID == 1)
            {
                BugPriorityBL priorityBL = new BugPriorityBL();
                BugStatusBL bugstatusBL = new BugStatusBL();
                ProjectBL projectBL = new ProjectBL();
                ViewBag.PriorityID = new SelectList(priorityBL.GetAllBugPriority(), "PriorityID", "PriorityName");
                ViewBag.StatusID = new SelectList(bugstatusBL.GetAllBugStatus(), "BugStatusID", "StatusName");
                ViewBag.ProjectID = new SelectList(projectBL.GetAllProject(), "ProjectID", "Name");
                return View(bug);
            }
            else
            {
                TempData["Message"] = "Ban khong co quyen edit bug nay, vui long lien he voi Admin";
                return Redirect("/Home/Error");
            } 
        }
        //Edit Bug
        [HttpPost]
        [Authorize(Roles = "EditBug")]
        public ActionResult EditBug(Bug bug)
        {
            if (ModelState.IsValid)
            {
                
                BugBL bugBL = new BugBL();
                Bug oldBug = bugBL.GetBugByID(bug.BugID);
                oldBug.PriorityID = bug.PriorityID;
                oldBug.StatusID = bug.StatusID;
                oldBug.Description = bug.Description;

                bugBL.EditBug(oldBug);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Edit Error", "Error! Can not edit this Bug, Model State is invalid");
            }
            return View();
        }
        //Hien thi View Xoa Bug
        [Authorize(Roles = "DeleteBug")]
        public ActionResult DeleteBug(string bugID)
        {
            BugBL bugBL = new BugBL();
            Bug bug = bugBL.GetBugByID(bugID);
            UserBL userBL = new UserBL();
            UserGroupBL userGroupBL = new UserGroupBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            User user = userBL.GetUserByID(userID);
            //Define Admin Group ID is 1
            if (bug.Owner.Equals(userID) || user.UserGroupID == 1)
            {
                return View(bug);
            }
            else
            {
                TempData["Message"] = "Ban khong co quyen thuc hien chuc nang nay, vui long lien he voi Admin";
                return Redirect("/Home/Error");
            }
        }
        //Xoa bug
        [HttpPost]
        [Authorize(Roles = "DeleteBug")]
        public ActionResult DeleteBug(Bug bug)
        {
            BugBL bugBL = new BugBL();
            if (ModelState.IsValid)
            {
                if (bugBL.DeleteBug(bug))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Error! Can not delete this project, Update Database Fail";
                }
            }
            else
            {
                TempData["Message"] = "Error! Can not delete this project, Data is not valid";
            }
            return View();
        }
        //Liet ke cac bug co status inprocess cua tester hien tai, chi co tester duoc thuc hien
        [Authorize(Roles = "ViewTester_InprocessTest")]
        public ActionResult Inprocess(int? page)
        {
            BugBL bugBL = new BugBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            //List<Bug> listBug = bugBL.GetAllInprocessBugByTesterID(userID);
            IPagedList<Bug> listBug = bugBL.GetPageListInprocessBugByTesterID(userID, page ?? 1, PageSize);
            return View(listBug);
        }
    }
}