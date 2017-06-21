using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using WebApp.Models;
using BusinessLogic;
using PagedList;
namespace WebApp.Areas.ProjectManager.Controllers
{
    /**
     * Controller nay hien cac chuc nang:
     * - Hien thi cac project ma manager hien tai quan li
     * - Hien thi View tao 1 bang phan cong project
     * - Hien thi Vew tao 1 bang phan cong project theo 1 project
     * - Tao 1 bang phan cong project
     * */
    public class ProjectsController : Controller
    {
        private const int DeverloperGroupID = 4;
        private const int PageSize = 20;
        // GET: ProjectManager/Projects
        //Hien thi tat ca cac project ma manager hien tai quan li
        [Authorize(Roles = "ProjectManagerWorkSpace")]
        public ActionResult Index(int? page)
        {
            string managerID = ((UserSession)Session[UserSession.SessionName]).UserID;
            ProjectBL projectBL = new ProjectBL();
            IPagedList<Project> listProject = projectBL.GetPageListProjectByManagerID(managerID,page??1,PageSize);
            return View(listProject);
        }
        //Hien thi View tao 1 bang phan cong Project
        // Tinh nang dang hoan thien
        [Authorize(Roles = "CreateAllotProject")]
        public ActionResult CreateAllotProject()
        {
            ProjectBL projectBL = new ProjectBL();
            string managerID = ((UserSession)Session[UserSession.SessionName]).UserID;
            List<Project> listProject = projectBL.GetListProjectByManagerID(managerID);
            UserBL userBL = new UserBL();
            //Define Developer Group ID = 4
            List<User> listDeveloper = userBL.GetUsersByUserGroup(DeverloperGroupID);
            ViewBag.ProjectID = new SelectList(listProject, "ProjectID", "Name");
            ViewBag.DeveloperID = new SelectList(listDeveloper, "UserID", "FullName");
            return View();
        }
        //Hien thi view tao 1 bang phan cong khi biet project
        [Authorize(Roles = "CreateAllotProject")]
        public ActionResult AddAllotProject(string projectID)
        {
            ProjectBL projectBL = new ProjectBL();
            Project project = projectBL.GetProjectById(projectID);
            ViewBag.ProjectID = projectID;
            ViewBag.ProjectName = project.Name;
            UserBL userBL = new UserBL();
            User currentUser = userBL.GetUserByID(((UserSession)Session[UserSession.SessionName]).UserID);
            if (project.ManagerID != currentUser.UserID)
            {
                TempData["Message"] = "Ban khong co quyen phan cong developer vao project nay, vui long lien he voi Admin";
                return Redirect("/Home/Error");
            }
            //Define Developer Group ID = 4
            List<User> listDeveloper = userBL.GetUsersByUserGroup(DeverloperGroupID);
            ViewBag.DeveloperID = new SelectList(listDeveloper, "UserID", "FullName");
            return View();
        }
        //Tao bang phan cong
        [HttpPost]
        [Authorize(Roles = "CreateAllotProject")]
        public ActionResult AddAllotProject(List<DeveloperAllotProject> allotProject)
        {
            if (ModelState.IsValid)
            {
                AllotProjectBL allprojectBL = new AllotProjectBL();
                allprojectBL.CreateDeveloperAllotProject(allotProject[0]);
                return Redirect("/Projects/AllotedDeveper?projectID=" + allotProject[0].ProjectID);
            }
            else
            {
                ViewBag.ErrorMess = "Error! Model State is invalid";
                return Redirect("/Home/Error");
            }
        }
    }
}