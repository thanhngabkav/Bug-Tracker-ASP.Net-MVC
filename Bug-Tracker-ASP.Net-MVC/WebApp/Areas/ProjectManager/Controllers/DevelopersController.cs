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
     * Controller nay thuc hien cac chuc nang hien thi va phan bo project cho developer
     * - Hien thi tat ca cac developer
     * - Phan bo project cho 1 developer
     * */
    public class DevelopersController : Controller
    {   private const int DeverloperGroupID = 4;
        private const int PageSize = 20;
        // GET: ProjectManager/AllotProjectManagement
        //Hien thi tat cac cac Developer trong he thong
        [Authorize(Roles = "ProjectManagerWorkSpace")]
        public ActionResult Index(int? page)
        {
            UserBL userBL = new UserBL();
            //define deverloper group id = 4
            //<User> listDeveloper = userBL.GetUsersByUserGroup(DeverloperGroupID);
            IPagedList<User> listDeveloper = userBL.GetPageListUserByUserGroup(DeverloperGroupID,page??1, PageSize); 
            return View(listDeveloper);
        }
        //Hien thi View phan cong project dua vao developerID da biet
        [Authorize(Roles = "CreateAllotProject")]
        public ActionResult AllotProject(string developerID)
        {
            UserBL userBL = new UserBL();
            User user = userBL.GetUserByID(developerID);
            ViewBag.UserID = developerID;
            ViewBag.UserLabel = user.FullName+ " - " + user.UserID;
            ProjectBL projectBL = new ProjectBL();
            string managerID = ((UserSession)Session[UserSession.SessionName]).UserID;
            List<Project> listProject = projectBL.GetListProjectByManagerID(managerID);
            ViewBag.ProjectID = new SelectList(listProject,"ProjectID","Name");
            ViewBag.DeveloperID = developerID;
            return View();
        }
    }
}