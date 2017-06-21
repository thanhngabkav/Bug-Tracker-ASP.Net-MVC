using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
namespace WebApp.Areas.Admin.Controllers
{
    public class BugPrioritiesController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang quan li Bug Priotity (bug priority co the co gia tri mau duoc chon luc create -- chua lam)
         * - Liet ke cac Priority
         * - Tao moi Priority 
         * - Xoa Priority
         * - Sua Priority
         * */
        // GET: Admin/BugPriorities
        [Authorize(Roles = "ViewAllBugPriority")]
        public ActionResult Index()
        {
            BugPriorityBL bugPriorityBL = new BugPriorityBL();
            List<BugPriority> listBugPriority = bugPriorityBL.GetAllBugPriority();
            return View(listBugPriority);
        }
    }
}