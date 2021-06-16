namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentTraineeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentTrainees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentTrainees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnrollmentTrainees", "CourseId", "dbo.Courses");
            DropIndex("dbo.EnrollmentTrainees", new[] { "CourseId" });
            DropIndex("dbo.EnrollmentTrainees", new[] { "UserId" });
            DropTable("dbo.EnrollmentTrainees");
        }
    }
}
