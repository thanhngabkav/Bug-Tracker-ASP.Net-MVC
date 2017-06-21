using System.Web.Mvc;
using Models;
using BusinessLogic;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /**
         * Controller nay hien thi cac thong tin ve website
         * */
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Future()
        {
            return View();
        }
    }
}