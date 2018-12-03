namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSomeRedundantFieldInModelsClassesAndMovedSomeAround : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            AddColumn("dbo.Tests", "Weight", c => c.Single(nullable: false));
            DropColumn("dbo.Grades", "SubjectId");
            DropColumn("dbo.Grades", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "Weight", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "SubjectId", c => c.Int(nullable: false));
            DropColumn("dbo.Tests", "Weight");
            CreateIndex("dbo.Grades", "SubjectId");
            AddForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
