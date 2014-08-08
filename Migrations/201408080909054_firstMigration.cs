namespace Exernet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserExernetTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserExernetTasks", "ExernetTask_Id", "dbo.ExernetTasks");
            DropIndex("dbo.ApplicationUserExernetTasks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserExernetTasks", new[] { "ExernetTask_Id" });
            AddColumn("dbo.ExernetTasks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExernetTasks", "UserId");
            AddForeignKey("dbo.ExernetTasks", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "ProfileFotoURL");
            DropTable("dbo.ApplicationUserExernetTasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserExernetTasks",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ExernetTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ExernetTask_Id });
            
            AddColumn("dbo.AspNetUsers", "ProfileFotoURL", c => c.String());
            DropForeignKey("dbo.ExernetTasks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExernetTasks", new[] { "UserId" });
            DropColumn("dbo.ExernetTasks", "UserId");
            CreateIndex("dbo.ApplicationUserExernetTasks", "ExernetTask_Id");
            CreateIndex("dbo.ApplicationUserExernetTasks", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserExernetTasks", "ExernetTask_Id", "dbo.ExernetTasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserExernetTasks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
