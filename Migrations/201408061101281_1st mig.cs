namespace Exernet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExernetTasks", "Title", c => c.String());
            AddColumn("dbo.ExernetTasks", "UploadDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExernetTasks", "UploadDate");
            DropColumn("dbo.ExernetTasks", "Title");
        }
    }
}
