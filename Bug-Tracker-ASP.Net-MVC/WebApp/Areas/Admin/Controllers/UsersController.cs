using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogic;
using WebApp.Models;
using PagedList;
namespace WebApp.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang quan li user trong he thong
         * - Liet ke tat cac cac user
         * - Liet ke cac user theo nhom user
         * - Create, update(Chua lam), delete
         * 
         * */
        private const int PageSize = 20;
        // GET: Admin/Users
        //Liet ke tat cac user trong he thong
        [Authorize(Roles ="AdminWorkSpace")]
        public ActionResult Index(int? page)
        {
            UserBL userBL = new UserBL();
            //List<User> listUser = userBL.GetAllUser();
            IPagedList<User> listUser = userBL.GetPageListUser(page ?? 1, PageSize);
            return View(listUser);
        }
        //Liet ke cac user theo userGroup
        [Authorize(Roles = "ViewAllUserGroup")]
        public ActionResult UserGroup(int userGroupID,int? page)
        {
            UserBL userBL = new UserBL();
            //List<User> listUser = userBL.GetUsersByUserGroup(userGroupID);
            IPagedList<User> listUser = userBL.GetPageListUserByUserGroup(userGroupID, page ?? 1, PageSize);
            UserGroupBL userGroupBL = new UserGroupBL();
            ViewBag.UserGroup = userGroupBL.GetUserGroupByUserGroupID(userGroupID).UserGroupName;
            ViewBag.UserGroupID = userGroupID;
            return View(listUser);
        }
        //Hien thi thong tin chi tiet 1 user, chi co admin duoc thuc hien chuc nang nay
        [Authorize(Roles = "ViewUserDetailsAsAdmin")]
        public ActionResult Details(string userID)
        {
            UserBL userBL = new UserBL();
            User user = userBL.GetUserByID(userID);
            return View(user);
        }
        //Hien thi view tao user, chi co admin duoc thuc hien chuc nang nay
        [Authorize(Roles ="CreateUser")]
        public ActionResult CreateUser()
        {
            UserGroupBL userGroupBL = new UserGroupBL();
            ViewBag.UserGroupID = new SelectList(userGroupBL.GetAllUserGroup(), "UserGroupID", "UserGroupName");
            return View();
        }
        [ServerResourceActionFilter]
        public bool IsUniqueUserName(string userName)
        {
            if (userName != null)
            {
                UserBL userBL = new UserBL();
                if (userBL.GetUserByUserName(userName) != null)
                    return false;
            }
            return true;
        }
        [ServerResourceActionFilter]
        public bool IsUniqueUserID(string userID)
        {
            if (userID != null)
            {
                UserBL userBL = new UserBL();
                User x = userBL.GetUserByID(userID);
                if (userBL.GetUserByID(userID) != null)
                    return false;
            }
            return true;
        }
        //Tao user, chi co admin duoc thuc hien chuc nang nay
        [Authorize(Roles = "CreateUser")]
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsUniqueUserName(user.UserName))
                {
                    UserBL userBL = new UserBL();
                    userBL.CreateUser(user);
                    ViewBag.ErrorMess = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Create New User Fail, User Name is Used";
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Create New User Fail, Data is invalid!";
                return View();
            }
        }
        //Hien thi view DeleteUser, chi co admin duoc thuc hien chuc nang nay
        [Authorize(Roles = "DeleteUser")]
        public ActionResult DeleteUser(string userID)
        {
            UserBL userBL = new UserBL();
            User user = userBL.GetUserByID(userID);
            if (user.UserGroupID == 1)
            {
                TempData["Message"] = "Bạn không có quyền xóa Admin!";
                return Redirect("/Home/Error");
            }
            return View(user);
        }
        //Delete user, chi co admin duoc thuc hien chuc nang nay
        [Authorize(Roles = "DeleteUser")]
        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            UserBL userBL = new UserBL();
            user = userBL.GetUserByID(user.UserID);
            userBL.DeleteUser(user);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string userID)
        {
            UserGroupBL userGroupBL = new UserGroupBL();
            ViewBag.UserGroupID = new SelectList(userGroupBL.GetAllUserGroup(), "UserGroupID", "UserGroupName");
            return View();
        }

    }
}