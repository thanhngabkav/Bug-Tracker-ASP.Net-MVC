using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
using PagedList;
namespace DataAccess
{
    public class ProjectDataAccess
    {
        private BugTrackerDBContext db;
        public ProjectDataAccess()
        {
            db = new BugTrackerDBContext();
        }
        public bool CreateProject(Project project)
        {
            try
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditProject(Project project)
        {
            try
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProject(Project project)
        {
            try
            {
                List<Bug> listBug = db.Bugs.Where(x => x.ProjectID.Equals(project.ProjectID)).ToList();
                foreach (Bug b in listBug) {
                    db.Bugs.Remove(b);
                    db.SaveChanges();
                 }
                db.Projects.Remove(project);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }
        public List<Project> GetAllProject()
        {
            try
            {
                List<Project> listProject = db.Projects.OrderByDescending(x => x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public List<Project> FindProjectByName(string projectName)
        {
            try
            {
                List<Project> listProject = db.Projects.Where(x => x.Name.Contains(projectName)).OrderByDescending(x => x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public Project GetProjectById(string projectID)
        {
            try
            {
                Project project = db.Projects.Find(projectID);
                return project;
            }
            catch
            {
                return null;
            }
        }
        public List<Project> GetListProjectByDeveloperID(string developerID)
        {
            try
            {
                List<Project> listProject = (from p in db.Projects
                                             join a in db.AllotProjects on p.ProjectID equals a.ProjectID
                                             where a.DeveloperID.Equals(developerID)
                                             select p).OrderByDescending(x=>x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public List<Project> GetListProjectByManagerID(string managerID)
        {
            try
            {
                List<Project> listProject = db.Projects.Where(x => x.ManagerID.Equals(managerID)).ToList();
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Project> GetPageListProject(int page, int pageSize)
        {
            try
            {
                IPagedList<Project> listProject = db.Projects.OrderByDescending(x => x.InitTime).ToPagedList(page, pageSize);
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Project> GetPageListFindProjectByName(string projectName, int page, int pageSize)
        {
            try
            {
                IPagedList<Project> listProject = db.Projects.Where(x => x.Name.Contains(projectName)).OrderByDescending(x => x.InitTime).ToPagedList(page,pageSize);
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Project> GetPageListProjectByDeveloperID(string developerID,int page, int pageSize)
        {
            try
            {
                IPagedList<Project> listProject = (from p in db.Projects
                                             join a in db.AllotProjects on p.ProjectID equals a.ProjectID
                                             where a.DeveloperID.Equals(developerID)
                                             select p).OrderByDescending(l=>l.InitTime).ToPagedList(page,pageSize);
                return listProject;
            }
            catch
            {
                return null;
            }
        }
        public IPagedList<Project> GetPageListProjectByManagerID(string managerID,int page, int pageSize)
        {
            try
            {
                IPagedList<Project> listProject = db.Projects.Where(x => x.ManagerID.Equals(managerID)).OrderByDescending(x=>x.InitTime).ToPagedList(page,pageSize);
                return listProject;
            }
            catch
            {
                return null;
            }
        }
    }
}
