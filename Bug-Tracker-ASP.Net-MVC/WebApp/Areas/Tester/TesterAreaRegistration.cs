using System.Web.Mvc;

namespace WebApp.Areas.Tester
{
    public class TesterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Tester";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Tester_default",
                "Tester/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp.Areas.Tester.Controllers" }
            );
        }
    }
}