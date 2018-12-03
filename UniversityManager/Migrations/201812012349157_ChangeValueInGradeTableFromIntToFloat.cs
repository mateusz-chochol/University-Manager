namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeValueInGradeTableFromIntToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grades", "Value", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grades", "Value", c => c.Int(nullable: false));
        }
    }
}
