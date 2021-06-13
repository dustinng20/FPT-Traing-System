namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.Int(nullable: false));
        }
    }
}
