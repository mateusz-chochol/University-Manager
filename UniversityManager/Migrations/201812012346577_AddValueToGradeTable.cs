namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValueToGradeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "Value", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "Value");
        }
    }
}
