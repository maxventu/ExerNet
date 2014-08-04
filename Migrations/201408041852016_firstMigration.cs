namespace Exernet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.ExernetTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Text = c.String(),
                        Block = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Charts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChartURL = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UploadDate = c.DateTime(nullable: false),
                        Text = c.String(),
                        Correct = c.Boolean(nullable: false),
                        Points = c.Int(nullable: false),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Formulae",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormulaURL = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoURL = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExernetTasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.ApplicationUserComments",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Comment_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.LikeApplicationUsers",
                c => new
                    {
                        Like_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Like_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Likes", t => t.Like_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Like_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SolutionApplicationUsers",
                c => new
                    {
                        Solution_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Solution_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Solutions", t => t.Solution_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Solution_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserExernetTasks",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ExernetTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ExernetTask_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ExernetTasks", t => t.ExernetTask_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ExernetTask_Id);
            
            CreateTable(
                "dbo.TagExernetTasks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        ExernetTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.ExernetTask_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.ExernetTasks", t => t.ExernetTask_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.ExernetTask_Id);
            
            AddColumn("dbo.AspNetUsers", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.TagExernetTasks", "ExernetTask_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.TagExernetTasks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Images", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.Formulae", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.ApplicationUserExernetTasks", "ExernetTask_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.ApplicationUserExernetTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SolutionApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SolutionApplicationUsers", "Solution_Id", "dbo.Solutions");
            DropForeignKey("dbo.Solutions", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.LikeApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LikeApplicationUsers", "Like_Id", "dbo.Likes");
            DropForeignKey("dbo.Likes", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.ApplicationUserComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.ApplicationUserComments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.Charts", "Task_Id", "dbo.ExernetTasks");
            DropForeignKey("dbo.Answers", "Task_Id", "dbo.ExernetTasks");
            DropIndex("dbo.TagExernetTasks", new[] { "ExernetTask_Id" });
            DropIndex("dbo.TagExernetTasks", new[] { "Tag_Id" });
            DropIndex("dbo.ApplicationUserExernetTasks", new[] { "ExernetTask_Id" });
            DropIndex("dbo.ApplicationUserExernetTasks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SolutionApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SolutionApplicationUsers", new[] { "Solution_Id" });
            DropIndex("dbo.LikeApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.LikeApplicationUsers", new[] { "Like_Id" });
            DropIndex("dbo.ApplicationUserComments", new[] { "Comment_Id" });
            DropIndex("dbo.ApplicationUserComments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Videos", new[] { "Task_Id" });
            DropIndex("dbo.Images", new[] { "Task_Id" });
            DropIndex("dbo.Formulae", new[] { "Task_Id" });
            DropIndex("dbo.Solutions", new[] { "Task_Id" });
            DropIndex("dbo.Likes", new[] { "Task_Id" });
            DropIndex("dbo.Comments", new[] { "Task_Id" });
            DropIndex("dbo.Charts", new[] { "Task_Id" });
            DropIndex("dbo.Answers", new[] { "Task_Id" });
            DropColumn("dbo.AspNetUsers", "Rating");
            DropTable("dbo.TagExernetTasks");
            DropTable("dbo.ApplicationUserExernetTasks");
            DropTable("dbo.SolutionApplicationUsers");
            DropTable("dbo.LikeApplicationUsers");
            DropTable("dbo.ApplicationUserComments");
            DropTable("dbo.Videos");
            DropTable("dbo.Tags");
            DropTable("dbo.Images");
            DropTable("dbo.Formulae");
            DropTable("dbo.Solutions");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Charts");
            DropTable("dbo.ExernetTasks");
            DropTable("dbo.Answers");
        }
    }
}
