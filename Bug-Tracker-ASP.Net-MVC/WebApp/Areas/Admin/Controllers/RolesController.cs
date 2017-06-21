using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
namespace WebApp.Areas.Admin.Controllers
{
    /**
     * Controller nay hien thi chi tiet cac Roles co trong he thong
     * 
     * 
     * 
     * */
    public class RolesController : Controller
    {
        // GET: Admin/Roles
        [Authorize(Roles = "ViewAllRoles")]
        public ActionResult Index()
        {
            RolesBL rolesBL = new RolesBL();
            List<Role> listRole = rolesBL.GetAllRole();
            return View(listRole);
        }
    }
}