namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCourseModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "UserId" });
            DropColumn("dbo.Courses", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "UserId");
            AddForeignKey("dbo.Courses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
