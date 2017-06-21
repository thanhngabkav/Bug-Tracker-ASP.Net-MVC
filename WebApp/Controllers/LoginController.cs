using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using BusinessLogic;
using Models;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        /**
         * Controller nay thuc hien cac chuc nang lien quan den thiet lap authen va author
         * Cac chuc nang gom:
         * - Login
         * - Logout
         * */
        // GET: Login
        public ActionResult Index()
        {
            UserSession userSession = (UserSession)Session[UserSession.SessionName];
            if ( userSession == null)
                return View();
            else {
                ViewBag.ErrorMess = "You Have Login!";
                return Redirect("/Home/Error");
            }
                
        }
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            UserBL userBL = new UserBL();
            if (ModelState.IsValid && loginModel.Username!=null)
            {
                if (userBL.Login(loginModel))
                {
                    User user = userBL.GetUserByUserName(loginModel.Username);
                    UserSession userSession = new UserSession { UserID = user.UserID, UserName = user.UserName };
                    Session.Add(UserSession.SessionName, userSession);
                    FormsAuthentication.SetAuthCookie(loginModel.Username, loginModel.Remember);
                  
                    ViewBag.LoginErrorMess = "";
                    return Redirect("/Home/Index");
                } else
                { 
                    ViewBag.LoginErrorMess = "! Username or Password is not correct";
                }
            }else
            {
                ViewBag.LoginErrorMess = "! Login Fail";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}