using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using WebApp.Models;
using BusinessLogic;
namespace WebApp.Controllers
{
    public class Z_Old_ProjectController : Controller
    {
        // GET: Project
        //Cac chuc nang nay danh cho tat ca user (ke ca anonymus)
        public ActionResult Index()
        {
            Z_Old_AnonymusUserBL anonymusUser = new Z_Old_AnonymusUserBL();
            List<Project> listProject = anonymusUser.GetAllProject();
            return View(listProject);
        }
        public ActionResult Details(string projectID)
        {
            Z_Old_AnonymusUserBL anonymusUser = new Z_Old_AnonymusUserBL();
            Project project = anonymusUser.GetProjectById(projectID);
            return View(project);
        }
        //Chuc nang nay thuoc ve developer duoc allot project do
        public ActionResult Bugs(string projectID)
        {
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            Z_Old_DeveloperBL developerBL = new Z_Old_DeveloperBL();
            List<Bug> listBug = developerBL.GetDeveloperBugByProjectID(projectID,userID);
            return View(listBug);
        }
    }
}