using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using PagedList;
namespace BusinessLogic
{
    public class ProjectBL
    {
        private ProjectDataAccess projectDAL;
        public ProjectBL()
        {
            projectDAL = new ProjectDataAccess();
        }
        public bool CreateProject(Project project)
        {
            return projectDAL.CreateProject(project);
        }
        public bool EditProject(Project project)
        {
            return projectDAL.EditProject(project);
        }
        public bool DeleteProject(Project project)
        {
            return projectDAL.DeleteProject(project);
        }
        public List<Project> GetAllProject()
        {
            return projectDAL.GetAllProject();
        }
        public List<Project> FindProjectByName(string projectName)
        {
            return projectDAL.FindProjectByName(projectName);
        }
        public Project GetProjectById(string projectID)
        {
            return projectDAL.GetProjectById(projectID);
        }
        public List<Project> GetListProjectByDeveloperID(string developerID)
        {
            return projectDAL.GetListProjectByDeveloperID(developerID);
        }
        public List<Project> GetListProjectByManagerID(string managerID)
        {
            return projectDAL.GetListProjectByManagerID(managerID);
        }
        public IPagedList<Project> GetPageListProject(int page, int pageSize)
        {
            return projectDAL.GetPageListProject(page, pageSize);
        }
        public IPagedList<Project> GetPageListFindProjectByName(string projectName, int page, int pageSize)
        {
            return projectDAL.GetPageListFindProjectByName(projectName, page, pageSize);
        }
        public IPagedList<Project> GetPageListProjectByDeveloperID(string developerID, int page, int pageSize)
        {
            return projectDAL.GetPageListProjectByDeveloperID(developerID, page, pageSize);
        }
        public IPagedList<Project> GetPageListProjectByManagerID(string managerID, int page, int pageSize)
        {
            return projectDAL.GetPageListProjectByManagerID(managerID, page, pageSize);
        }
    }

}
