namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initaial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeveloperAllotProjects",
                c => new
                    {
                        DeveloperID = c.String(nullable: false, maxLength: 128),
                        ProjectID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DeveloperID, t.ProjectID })
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.DeveloperID, cascadeDelete: true)
                .Index(t => t.DeveloperID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                        Email = c.String(),
                        Phone = c.String(),
                        UserGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserGroupID);
            
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        BugID = c.String(nullable: false, maxLength: 128),
                        DetectionTime = c.DateTime(nullable: false),
                        Owner = c.String(maxLength: 128),
                        Description = c.String(),
                        PriorityID = c.Int(nullable: false),
                        ProjectID = c.String(maxLength: 128),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BugID)
                .ForeignKey("dbo.BugPriorities", t => t.PriorityID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.BugStatus", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Owner)
                .Index(t => t.Owner)
                .Index(t => t.PriorityID)
                .Index(t => t.ProjectID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.BugPriorities",
                c => new
                    {
                        PriorityID = c.Int(nullable: false, identity: true),
                        PriorityName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PriorityID)
                .Index(t => t.PriorityName, unique: true);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        ManagerID = c.String(nullable: false, maxLength: 128),
                        InitTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.ManagerID, cascadeDelete: false)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.BugStatus",
                c => new
                    {
                        BugStatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BugStatusID)
                .Index(t => t.StatusName, unique: true);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserGroupID = c.Int(nullable: false, identity: true),
                        UserGroupName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserGroupID)
                .Index(t => t.UserGroupName, unique: true);
            
            CreateTable(
                "dbo.UserGroup_Role",
                c => new
                    {
                        UserGroupID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserGroupID, t.RoleID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleID)
                .Index(t => t.RoleName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.UserGroup_Role", "UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.UserGroup_Role", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.DeveloperAllotProjects", "DeveloperID", "dbo.Users");
            DropForeignKey("dbo.Bugs", "Owner", "dbo.Users");
            DropForeignKey("dbo.Bugs", "StatusID", "dbo.BugStatus");
            DropForeignKey("dbo.Projects", "ManagerID", "dbo.Users");
            DropForeignKey("dbo.DeveloperAllotProjects", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Bugs", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Bugs", "PriorityID", "dbo.BugPriorities");
            DropIndex("dbo.Roles", new[] { "RoleName" });
            DropIndex("dbo.UserGroup_Role", new[] { "RoleID" });
            DropIndex("dbo.UserGroup_Role", new[] { "UserGroupID" });
            DropIndex("dbo.UserGroups", new[] { "UserGroupName" });
            DropIndex("dbo.BugStatus", new[] { "StatusName" });
            DropIndex("dbo.Projects", new[] { "ManagerID" });
            DropIndex("dbo.Projects", new[] { "Name" });
            DropIndex("dbo.BugPriorities", new[] { "PriorityName" });
            DropIndex("dbo.Bugs", new[] { "StatusID" });
            DropIndex("dbo.Bugs", new[] { "ProjectID" });
            DropIndex("dbo.Bugs", new[] { "PriorityID" });
            DropIndex("dbo.Bugs", new[] { "Owner" });
            DropIndex("dbo.Users", new[] { "UserGroupID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.DeveloperAllotProjects", new[] { "ProjectID" });
            DropIndex("dbo.DeveloperAllotProjects", new[] { "DeveloperID" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserGroup_Role");
            DropTable("dbo.UserGroups");
            DropTable("dbo.BugStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.BugPriorities");
            DropTable("dbo.Bugs");
            DropTable("dbo.Users");
            DropTable("dbo.DeveloperAllotProjects");
        }
    }
}
