using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
using PagedList;
using PagedList.Mvc;
namespace WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang hien thi thong tin project (Khong thuc hien cac chuc nang quan li)
         * Cac chuc nang gom co:
         * - Hien thi tat ca cac project trong he thong
         * - Hien thi thong tin chi tiet ve 1 project (Co thong ke bug hoac bieu do -- chua lam)
         * - Hien thi cac project cua 1 manager
         * - Hien thi cac Developer cua 1 project
         * */
        private const int PageSize = 20;
        // GET: Projects
        //Chuc nang nay danh cho tat ca user (ke ca anonymus)
        public ActionResult Index(int? page)
        {
            ProjectBL projectBL = new ProjectBL();
            IPagedList<Project> listProject = projectBL.GetPageListProject(page ?? 1, PageSize); 
            return View(listProject);
        }
        //Hien thi thong tin chi tiet cua project, chi user da login moi duoc thuc hien
        [Authorize]
        public ActionResult Details(string projectID)
        {
            ProjectBL projectBL = new ProjectBL();
            Project project = projectBL.GetProjectById(projectID);
            return View(project);
        }
        
        //Liet ke cac Bugs trong 1 project, chi cac user da dang nhap moi duoc thuc hien chuc nang nay
        [Authorize]
        public ActionResult Bugs(string projectID,int? page)
        {
            BugBL bugBL = new BugBL();
            IPagedList<Bug> listBug = bugBL.GetPageListBugByProjectID(projectID,page??1,PageSize);
            return View(listBug);
        }
        //Liet ke cac project cua 1 manager, chi co user da dang nhap moi duoc thuc hien
        public ActionResult Manager(string managerID,int? page)
        {
            ProjectBL projectBL = new ProjectBL();
            IPagedList<Project> listProject = projectBL.GetPageListProjectByManagerID(managerID, page ?? 1, PageSize);
            return View(listProject);
        }
        //Liet ke cac developer duoc phan bo cho 1 project, chi user da login moi duoc thuc hien
        public ActionResult AllotedDeveper(string projectID,int? page)
        {
            UserBL userBL = new UserBL();
            IPagedList<User> listDeveloper = userBL.GetPageListAllotedDeveloperByProjectID(projectID, page??1, PageSize);
            ViewBag.ProjectID = projectID;
            return View(listDeveloper);
        }

    }
}