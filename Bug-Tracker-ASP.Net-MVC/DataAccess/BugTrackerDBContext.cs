using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace DataAccess
{
    public class BugTrackerDBContext:DbContext
    {
        //public BugTrackerDBContext() : base("DBContext_BugTracker") { }
        public DbSet<Bug> Bugs { set; get; }
        public DbSet<BugPriority> BugPriorities { set; get; }
        public DbSet<BugStatus> BugStatuses { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<UserGroup> UserGroups { set; get; }
        public DbSet<UserGroup_Role> UserGroup_Roles { set; get; }
        public DbSet<DeveloperAllotProject> AllotProjects { set; get; }
    }
}
