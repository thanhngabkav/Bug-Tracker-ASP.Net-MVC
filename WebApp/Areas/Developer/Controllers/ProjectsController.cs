using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using WebApp.Models;
using PagedList;
namespace WebApp.Areas.Developer.Controllers
{
    /**
     * Contrller nay liet ke tat cac ca project ma developer hien tai duoc giao
     * */
    public class ProjectsController : Controller
    {
        private const int PageSize = 20;
        // GET: Developer/Projects
        //Liet ke tat cac ca project ma developer hien tai duoc allot, chi developer duoc thuc hien chuc nang nay

        [Authorize(Roles = "DeveloperProject")]
        public ActionResult Index(int? page)
        {
            ProjectBL projectBL = new ProjectBL();
            string userID = ((UserSession)Session[UserSession.SessionName]).UserID;
            // List<Project> listProject = projectBL.GetListProjectByDeveloperID(userID);
            IPagedList<Project> listProject = projectBL.GetPageListProjectByDeveloperID(userID,page??1,PageSize);
            return View(listProject);
        }
    }
}