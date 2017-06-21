using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DataAccess
{
    public class AdminDataAccess
    {
        private BugTrackerDBContext db;
        public AdminDataAccess()
        {
            db = new BugTrackerDBContext();
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
    }
}
