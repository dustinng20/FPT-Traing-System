namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentTrainerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentTrainers",
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
            DropForeignKey("dbo.EnrollmentTrainers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnrollmentTrainers", "CourseId", "dbo.Courses");
            DropIndex("dbo.EnrollmentTrainers", new[] { "CourseId" });
            DropIndex("dbo.EnrollmentTrainers", new[] { "UserId" });
            DropTable("dbo.EnrollmentTrainers");
        }
    }
}
