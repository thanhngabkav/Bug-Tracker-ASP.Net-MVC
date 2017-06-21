using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    /**
     * Controller nay thuc hien cac chuc nang quan li report
     * 
     * (Chua Lam)
     * 
     * 
     * */
    public class ReportsController : Controller
    {
        [Authorize(Roles = "ViewAllReport")]
        // GET: Admin/ReportManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}