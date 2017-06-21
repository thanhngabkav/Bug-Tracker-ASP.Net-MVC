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
    public class Z_Old_AdminController : Controller
    {
        // GET: Admin
        //Finished -- Cac chuc nang quan li Account (Create,Delete,GetAll) (Kiem tra username co duy nhat khong (Ajax va server)
        //Cac chuc nang quang li Project (Create,Delete,Edit) (Ko Kiem tra ten project co duy nhat khong)
        //Cac chuc nang quan li Report
        //Cac chuc nang quan li Status/Priority (Co the tam thoi chua  lam)
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountManagement()
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            List<User> listUser = adminBL.GetAllUser();
            return View(listUser);
        }
        public ActionResult CreateUser()
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            ViewBag.UserGroupID = new SelectList(adminBL.GetAllUserGroup(), "UserGroupID", "UserGroupName");
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsUniqueUserName(user.UserName))
                {
                    Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
                    adminBL.CreateUser(user);
                    ViewBag.ErrorMess = "";
                    return RedirectToAction("AccountManagement");
                }else
                {
                    ViewBag.ErrorMess = "Create New User Fail, User Name is Used";
                    return View();
                }
            }else
            {
                ViewBag.ErrorMess = "Create New User Fail, Data is invalid!";
                return View();
            }
        }
        [ServerResourceActionFilter]
        public bool IsUniqueUserName(string userName)
        {
            if (userName != null)
            {
                Z_Old_UserBL userBL = new Z_Old_UserBL();
                if (userBL.GetUserByUserName(userName) != null)
                    return false;
            }
            return true;
        }
        public ActionResult DelteteUser(string userID)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            if (ModelState.IsValid)
            {
                adminBL.DeleteUser(user);
                return RedirectToAction("AcountManagement");
            }else
            {
                return View();
            }
        }
        public ActionResult ProjectManagement()
        {
            Z_Old_AnonymusUserBL userBL = new Z_Old_AnonymusUserBL();
            List<Project> listPoject = userBL.GetAllProject();
            return View(listPoject);
        }
        // Rang buoc mac dinh ProjectManager co ID la 2
        public ActionResult CreateProject()
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            List<User> listManager = adminBL.GetUsersByUserGroup(2);
            List<ProjectManagementViewModel> listManagerViewModel = new List<ProjectManagementViewModel>();
            foreach(User x in listManager)
            {
                ProjectManagementViewModel managerView = new ProjectManagementViewModel {
                    ManagerID = x.UserID,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Label = x.UserName + "(" + x.FullName + ")" 
                };
                listManagerViewModel.Add(managerView);
            }
            ViewBag.ProjectManageID = new SelectList(listManagerViewModel,"ManagerID","Label");
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
                if (adminBL.CreateProject(project))
                {
                    ViewBag.ErrorMess = "";
                    return RedirectToAction("ProjectManagement");
                }else
                {
                   ViewBag.ErrorMess = "Error! Can not create project, Insert Database fail";
                }
            }else
            {
                ViewBag.ErrorMess = "Error! Can not create project, model state is invalid";
            }
            return View();
        }
        public ActionResult DeleteProject(string projectID)
        {
            Z_Old_AnonymusUserBL anonymusUserBL = new Z_Old_AnonymusUserBL();
            Project project = anonymusUserBL.GetProjectById(projectID);
            return View(project);
        }
        [HttpPost]
        public ActionResult DeleteProject(Project project)
        {
            if (ModelState.IsValid)
            {
                Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
                if (adminBL.DeleteProject(project))
                {
                    ViewBag.ErrorMess = "";
                    return RedirectToAction("ProjectManagement");
                }else
                {
                    ViewBag.ErrorMess = "Error! Can not Delete this project, Update  database fail";
                }
            }else
            {
                ViewBag.ErrorMess = "Error! Can not Delete this project, model state is invalid";
            }
            return View();
        }
        public ActionResult EditProject(string projectID)
        {
            Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
            List<User> listManager = adminBL.GetUsersByUserGroup(2);
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
            ViewBag.ProjectManageID = new SelectList(listManagerViewModel, "ManagerID", "Label");
            Z_Old_AnonymusUserBL anonymusUserBL = new Z_Old_AnonymusUserBL();
            Project project = anonymusUserBL.GetProjectById(projectID);
            return View(project);
        }
        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            if (ModelState.IsValid)
            {
                Z_Old_AdminBL adminBL = new Z_Old_AdminBL();
                adminBL.EditProject(project);
                ViewBag.ErrorMess = "";
                return RedirectToAction("ProjectManagement");
            }
            else
            {
                ViewBag.ErrorMess = "Error! Can not Delete this project, model state is invalid";
            }
            return View();
        }
    }
}