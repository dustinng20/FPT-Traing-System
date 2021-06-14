namespace FPT_Traing_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", "Name_Index");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Categories", "Name", unique: true, name: "Name_Index");
        }
    }
}
