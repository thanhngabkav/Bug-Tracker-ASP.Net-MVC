using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
namespace WebApp.Areas.Admin.Controllers
{
    public class BugStatuesController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang quaan li Bug Status (Co cho phep chon mau bieu thi cho status khi create -- chua lam)
         * - Liet ke cac bug status
         * - Them, xoa, sua bug status
         * 
         * */
        // GET: Admin/BugStatusManagement
        [Authorize(Roles = "ViewAllBugStatus")]
        public ActionResult Index()
        {
            BugStatusBL bugStatusBL = new BugStatusBL();
            List<BugStatus> listStatus = bugStatusBL.GetAllBugStatus();
            return View(listStatus);
        }
    }
}