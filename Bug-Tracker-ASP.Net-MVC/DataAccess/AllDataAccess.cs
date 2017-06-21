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
        //ProjectDataAccess
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
        public List<Project> GetAllProject()
        {
            try
            {
                List<Project> listProject = db.Projects.OrderByDescending(x=>x.InitTime).ToList();
                return listProject;
            }
            catch
            {
                return new List<Project>();
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
                return new List<Project>();
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
                return new Project();
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
                return new List<Project>();
            }
        }

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
        public UserGroup GetUserGroupByUserGroupID(int userGroupID)
        {
            try
            {
                return db.UserGroups.Find(userGroupID);
            }
            catch
            {
                return new UserGroup();
            }
        }
        public List<UserGroup> GetAllUserGroup()
        {
            try
            {
                return db.UserGroups.ToList();
            }
            catch(Exception ex)
            {
                return new List<UserGroup>() ;
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

        //Role
        public string[] GetUserRoles(int userGroupID)
        {
            List<string> userRoles = new List<string>();
            List<UserGroup_Role> list = db.UserGroup_Roles.Where(x => x.UserGroupID.Equals(userGroupID)).ToList();
            foreach (UserGroup_Role x in list)
            {
                userRoles.Add(db.Roles.Find(x.RoleID).RoleName);
            }
            return userRoles.ToArray();
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
        public List<User> GetAllUser()
        {
            return db.Users.ToList();
        }
        public User GetUserByID(string userID)
        {
            return db.Users.Find(userID);
        }
        public User GetUserByUserName(string userName)
        {
            return db.Users.Where(x => x.UserName.Equals(userName)).SingleOrDefault();
        }
        // Get UserByUserGroup
        public List<User> GetUsersByUserGroup(int userGroupID)
        {
            return db.Users.Where(x => x.UserGroupID == userGroupID).ToList();
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
        public List<BugStatus> GetAllBugStatus()
        {
            try
            {
                return db.BugStatuses.ToList();
            }
            catch
            {
                return new List<BugStatus>() ;
            }
        }
        public BugStatus GetBugStatusByID(int bugStatusID)
        {
            return db.BugStatuses.Where(x => x.BugStatusID == bugStatusID).SingleOrDefault();
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
        public List<BugPriority> GetAllBugPriority()
        {
            try
            {
                return db.BugPriorities.ToList();
            }
            catch
            {
                return new List<BugPriority>();
            }
        }
        public BugPriority GetBugPriorityByID(int priorityID)
        {
            return db.BugPriorities.Where(x => x.PriorityID == priorityID).SingleOrDefault();
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
                return new List<Bug>();
            }
        }
        public List<Bug> GetAllBug()
        {
            try
            {
                List<Bug> listBug = db.Bugs.OrderBy(x=>x.Priority).ThenBy(x=>x.StatusID).ToList();
                return listBug;
            }
            catch
            {
                return new List<Bug>();
            }
        }
        public List<Bug> GetAllInprocessBugByTesterID(string testerID)
        {
            //define buf inprocess has statusID is 2
            try
            {
                return db.Bugs.Where(x => x.StatusID == 2 & x.Owner.Equals(testerID)).ToList();
            }
            catch
            {
                return new List<Bug>();
            }
        }
        public Bug GetBugByID(string bugID)
        {
            try
            {
                return db.Bugs.Where(x => x.BugID.Equals(bugID)).SingleOrDefault();
            }
            catch
            {
                return new Bug();
            }
        }
        public List<Bug> GetAllBugByProjectID(string projectID)
        {
            try
            {
                return db.Bugs.Where(x => x.ProjectID.Equals(projectID)).ToList();
            }
            catch
            {
                return new List<Bug>();
            }
        }
        //Developer DataAccess
        public List<Project> GetListProjectByDeveloperID(string developerID)
        {
            try
            {
                List<Project> listProject = (from p in db.Projects
                                             join a in db.AllotProjects on p.ProjectID equals a.ProjectID
                                             where a.DeveloperID.Equals(developerID)
                                             select p).ToList();
                return listProject;
            }
            catch
            {
                return new List<Project>();
            }
        }
        public List<Bug> GetDeveloperBug(string developerID)
        {
            try
            {
                List<Bug> listBug = (from b in db.Bugs
                                     join a in db.AllotProjects on b.ProjectID equals a.ProjectID
                                     where a.DeveloperID.Equals(developerID)
                                     select b).ToList();
                return listBug;
            }
            catch
            {
                return new List<Bug>();
            }
        }
        public List<User> GetListAllotedDeveloperByProjectID(string projectID)
        {
            List<User> listUser = (from d in db.Users
                                   join a in db.AllotProjects on d.UserID equals a.DeveloperID
                                   where a.ProjectID.Equals(projectID)
                                   select d).ToList();
            return listUser;
        }
        //Developer Allot Project Data Access
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
        public List<DeveloperAllotProject> GetDeveloperAllotProjectByProjectID(string projectID)
        {
            return db.AllotProjects.Where(x => x.ProjectID.Equals(projectID)).ToList();
        }       
        public DeveloperAllotProject GetAllotProjectByDeveloperID_ProjectID(string developerID, string projectID)
        {
            return db.AllotProjects.Where(x => x.DeveloperID.Equals(developerID) && x.ProjectID.Equals(projectID)).SingleOrDefault();
        }
    }
}
