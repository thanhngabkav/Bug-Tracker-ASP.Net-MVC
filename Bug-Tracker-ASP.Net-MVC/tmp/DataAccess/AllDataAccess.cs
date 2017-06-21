using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace DataAccess
{
    public class AllDataAccess
    {
        private BugTrackerDBContext db;
        public AllDataAccess()
        {
            db = new BugTrackerDBContext();

        }
        //All User Data Access
        public List<Project> GetAllProject()
        {
            try
            {
                List<Project> listProject = db.Projects.OrderByDescending(x=>x.InitTime).ToList();
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
                List<Project> listProject = db.Projects.Where(x => x.Name.Contains(projectName)).OrderByDescending(x=>x.InitTime).ToList();
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
        //Admin Data Access
        //User Group
        public bool CreateUserGroup(UserGroup userGroup)
        {
            try
            {
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUserGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUserGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //UserGroup_Role
        public bool CreateUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.UserGroup_Roles.Add(usergroup_role);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.Entry(usergroup_role).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUserGroupRole(UserGroup_Role usergroup_role)
        {
            try
            {
                db.Entry(usergroup_role).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //User
        public bool CreateUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Bug Status
        public bool CreateBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.BugStatuses.Add(bugstatus);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.Entry(bugstatus).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBugStatus(BugStatus bugstatus)
        {
            try
            {
                db.Entry(bugstatus).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Bug Priority
        public bool CreateBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.BugPriorities.Add(bugpriority);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.Entry(bugpriority).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBugPriority(BugPriority bugpriority)
        {
            try
            {
                db.Entry(bugpriority).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Project
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
                db.Entry(project).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Tester Data Access
        // Bug
        public bool CreateBug(Bug bug)
        {
            try
            {
                db.Bugs.Add(bug);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditBug(Bug bug)
        {
            try
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBug(Bug bug)
        {
            try
            {
                db.Entry(bug).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Bug> GetListBugByTester(string testerID) 
        {
            try
            {
                List<Bug> listBug = db.Bugs.Where(x => x.Owner.Equals(testerID)).OrderByDescending(x=>x.DetectionTime).ToList();
                return listBug;
            }
            catch
            {
                return null;
            }
        }
        //Project Manager Data Access
        public bool CreateDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.AllotProjects.Add(allotproject);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.Entry(allotproject).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDeveloperAllotProject(DeveloperAllotProject allotproject)
        {
            try
            {
                db.Entry(allotproject).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
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
    }
}
