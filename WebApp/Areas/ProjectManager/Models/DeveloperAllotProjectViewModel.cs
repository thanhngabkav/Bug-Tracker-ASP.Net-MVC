using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace WebApp.Areas.ProjectManager.Models
{
    public class DeveloperAllotProjectViewModel
    {
        public string DeverloperID { set; get; }
        public List<string> ProjectID { set; get; }
    }
}