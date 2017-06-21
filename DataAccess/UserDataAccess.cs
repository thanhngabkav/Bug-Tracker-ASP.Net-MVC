using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace DataAccess
{
    public class UserDataAccess
    {
        private BugTrackerDBContext db;
        public UserDataAccess()
        {
            db = new BugTrackerDBContext();
        }
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
                List<Bug> userBug = db.Bugs.Where(x => x.Owner.Equals(user.UserID)).ToList();
                foreach(Bug b in userBug)
                {
                    b.Owner = null;
                }
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        public List<User> GetUsersByUserGroup(int userGroupID)
        {
            return db.Users.Where(x => x.UserGroupID == userGroupID).ToList();
        }
        public List<User> GetListAllotedDeveloperByProjectID(string projectID)
        {
            List<User> listUser = (from d in db.Users
                                   join a in db.AllotProjects on d.UserID equals a.DeveloperID
                                   where a.ProjectID.Equals(projectID)
                                   select d).ToList();
            return listUser;
        }
        public IPagedList<User> GetPageListUser(int page,int pageSize)
        {
            return db.Users.OrderBy(x=>x.UserGroupID).ToPagedList(page,pageSize);
        }
        public IPagedList<User> GetPageListUserByUserGroup(int userGroupID, int page,int pageSize)
        {
            return db.Users.Where(x => x.UserGroupID == userGroupID).OrderBy(x=>x.UserName).ToPagedList(page,pageSize);
        }
        public IPagedList<User> GetPageListAllotedDeveloperByProjectID(string projectID, int page, int pageSize)
        {
            IPagedList<User> listUser = (from d in db.Users
                                   join a in db.AllotProjects on d.UserID equals a.DeveloperID
                                   where a.ProjectID.Equals(projectID)
                                   select d).OrderBy(x => x.UserName).ToPagedList(page,pageSize);
            return listUser;
        }
    }
}
