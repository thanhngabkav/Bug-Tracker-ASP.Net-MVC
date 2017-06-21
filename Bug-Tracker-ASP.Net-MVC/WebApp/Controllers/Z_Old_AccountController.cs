using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using WebApp.Models;
using BusinessLogic;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class Z_Old_AccountController : Controller
    {
        // GET: Account
        //Cac chuc nang chua hoan thien: Register(Co the khong can), Forgot Password
        [Authorize]
        public ActionResult MyAcount()
        {
            UserSession userSession = (UserSession)Session[UserSession.SessionName];
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            User user = userBL.GetUserByID(userSession.UserID);
            return View(user);
        }
        [Authorize]
        public ActionResult Edit()
        {
            UserSession userSession = (UserSession)Session[UserSession.SessionName];
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            User user = userBL.GetUserByID(userSession.UserID);
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserSession userSession = (UserSession)Session[UserSession.SessionName];
                Z_Old_UserBL userBL = new Z_Old_UserBL();
                if (userBL.GetUserByUserName(user.UserName) != null)
                {
                    ViewBag.UserNameError = "UserName is used";
                    return View();
                }
                User currentUser = userBL.GetUserByID(userSession.UserID);
                SHA_2 mySHA = new SHA_2();
                if (mySHA.Hash(user.UserID + user.Password).Equals(currentUser.Password))
                {
                    userBL.EditUser(user);
                    ViewBag.PasswordError = "";
                    ViewBag.UserNameError = "";
                    return RedirectToAction("Account", "Index");                    
                }
                else
                {
                    ViewBag.PasswordError = "Password is not correct";
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Details(string userID)
        {
            Z_Old_UserBL userBL = new Z_Old_UserBL();
            User user = userBL.GetUserByID(userID);
            return View(user);
        }
      
    }
}