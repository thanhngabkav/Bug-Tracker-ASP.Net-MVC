using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using WebApp.Models;
using PagedList;
using PagedList.Mvc;
namespace WebApp.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang lien quan den quan li project
         * - Liet ke tat ca cac project trong he thong (liet ke chi tiet)
         * - Them, xoa, sua, thong ke (chua lam) project 
         * 
         * 
         * */
        private const int ProjectManagerGroupID = 2;
        private const int PageSize = 2;
        // GET: Admin/Projects
        //Liet ke tat cac cac  project trong he thong
        [Authorize(Roles = "ViewAllProjectAsAdmin")]
        public ActionResult Index(int? page)
        {
            ProjectBL projectBL = new ProjectBL();
            //List<Project> listProject = projectBL.GetAllProject();
            IPagedList<Project> listProject = projectBL.GetPageListProject(page ?? 1, PageSize);
            return View(listProject);
        }
        //Hien thi View tao project khi chua biet manager
        [Authorize(Roles = "CreateProject")]
        public ActionResult CreateProject()
        {
            UserBL userBL = new UserBL();
            List<User> listManager = userBL.GetUsersByUserGroup(ProjectManagerGroupID);
            List<ProjectManagementViewModel> listManagerViewModel = new List<ProjectManagementViewModel>();
            foreach (User x in listManager)
            {
                ProjectManagementViewModel managerView = new ProjectManagementViewModel
                {
                    ManagerID = x.UserID,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Label = x.UserName + "(" + x.FullName + ")"
                };
                listManagerViewModel.Add(managerView);
            }
            ViewBag.ProjectManagerID = new SelectList(listManagerViewModel, "ManagerID", "Label");
            return View();
        }
        //Hien thi View tao project khi da biet manager
        [Authorize(Roles = "CreateProject")]
        public ActionResult AddProject(string managerID)
        {
            UserBL userBL = new UserBL();
            User manager = userBL.GetUserByID(managerID);
            ViewBag.ProjectManagerID = managerID;
            ViewBag.ProjectManager = manager.UserName + " - " + manager.FullName;
            return View();
        }
        //Tao project
        [Authorize(Roles = "CreateProject")]
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                ProjectBL projectBL = new ProjectBL();
                if (projectBL.CreateProject(project))
                {
                    ViewBag.ErrorMess = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] =   "Error! Can not create project, Insert Database fail";
                }
            }
            else
            {
                TempData["Message"] =   "Error! Can not create project, model state is invalid";
            }
            return View();
        }
        //Hien thi view xoa project
        [Authorize(Roles = "DeleteProject")]
        public ActionResult DeleteProject(string projectID)
        {
            ProjectBL projectBL = new ProjectBL();
            Project project = projectBL.GetProjectById(projectID);
            return View(project);
        }
        //Xoa Project
        [Authorize(Roles = "DeleteProject")]
        [HttpPost]
        public ActionResult DeleteProject(Project project)
        {
            
            ProjectBL projectBL = new ProjectBL();
            project = projectBL.GetProjectById(project.ProjectID);
            if (projectBL.DeleteProject(project))
            {
                TempData["Message"] =  "";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"]   = "Error! Can not Delete this project, Update  database fail";
                return Redirect("/Home/Error");
            }
            
        }
        //Hien thi View chinh sua mot project
        [Authorize(Roles = "EditProject")]
        public ActionResult EditProject(string projectID)
        {
            UserBL userBL = new UserBL();
            List<User> listManager = userBL.GetUsersByUserGroup(ProjectManagerGroupID);
            List<ProjectManagementViewModel> listManagerViewModel = new List<ProjectManagementViewModel>();
            foreach (User x in listManager)
            {
                ProjectManagementViewModel managerView = new ProjectManagementViewModel
                {
                    ManagerID = x.UserID,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Label = x.UserName + "(" + x.FullName + ")"
                };
                listManagerViewModel.Add(managerView);
            }
            ViewBag.ProjectManagerID = new SelectList(listManagerViewModel,"ManagerID", "Label");
            ProjectBL projectBL = new ProjectBL();
            Project project = projectBL.GetProjectById(projectID);
            return View(project);
        }
        //Edit project
        [Authorize(Roles = "EditProject")]
        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            if (ModelState.IsValid)
            {
                ProjectBL projectBL = new ProjectBL();
                projectBL.EditProject(project);
                ViewBag.ErrorMess = "";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Error! Can not Delete this project, model state is invalid";
            }
            return View();
        }

    }
}