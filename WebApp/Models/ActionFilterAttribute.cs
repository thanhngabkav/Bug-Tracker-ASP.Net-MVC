using System;
using System.Web.Mvc;
using System.Web.Routing;
namespace WebApp.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ActionFiltersAttribute : ActionFiltersAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}