﻿ using System.Web.Mvc;

namespace WebApp.Areas.ProjectManager
{
    public class ProjectManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectManager_default",
                "ProjectManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp.Areas.ProjectManager.Controllers" }
            );
        }
    }
}