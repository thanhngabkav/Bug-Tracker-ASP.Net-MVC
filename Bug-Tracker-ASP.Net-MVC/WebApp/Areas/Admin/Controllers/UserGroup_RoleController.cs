using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    
    public class UserGroup_RoleController : Controller
    {
        // GET: Admin/UserGroup_Role
        [Authorize(Roles = "ViewAllUserGroup_Role")]
        public ActionResult Index()
        {
            return View();
        }
    }
}