using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
namespace WebApp.Areas.Admin.Controllers
{
    /**(Chua lam)
     * Controller nay thuc hien cac chuc nang quan li UserGroup
     * - Liet ke tat ca cac User Group
     * - Create, Edit, Delete UserGroup (DELETE ALL USER IN THIS GROUP)
     * */
    public class UserGroupController : Controller
    {
        // GET: Admin/UserGroup
        [Authorize(Roles = "ViewAllUserGroup")]
        public ActionResult Index()
        {
            UserGroupBL userGroupBL = new UserGroupBL();
            List<UserGroup> listUserGroup = userGroupBL.GetAllUserGroup();
            return View(listUserGroup);
        }
    }
}