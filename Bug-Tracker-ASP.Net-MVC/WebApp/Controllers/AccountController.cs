using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        /**
         *Controller nay thuc hien cac chuc nang quan li Account va hien thi thong tin ve 1 Account nao do
         * Cac chuc nang quan li Account gom: Chinh sua thong tin (Edit) va thay doi password (ChangePass), thay doi avata (Chua lam)
         * */
        //Hien thi thong tin chi tiet ve user hien tai
        public ActionResult MyAccount()
        {
            UserBL userBL = new UserBL();
            User user = userBL.GetUserByID(((UserSession)Session[UserSession.SessionName]).UserID);
            return View(user);
        }
        //Hien thi thong tin chi so luoc ve 1 user, chi user da dang nhap moi duoc thuc hien
        public ActionResult Details(string userID)
        {
            UserBL userBL = new UserBL();
            User user = userBL.GetUserByID(userID);
            return View(user);
        }
        
        
    }
}