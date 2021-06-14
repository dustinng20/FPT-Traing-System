namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKCourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Category", c => c.String(nullable: false));
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropColumn("dbo.Courses", "CategoryId");
        }
    }
}
