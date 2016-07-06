namespace MyTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrioritiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priority",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PriorityLevel = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Task", "PriorityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Task", "PriorityId");
            AddForeignKey("dbo.Task", "PriorityId", "dbo.Priority", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "PriorityId", "dbo.Priority");
            DropIndex("dbo.Task", new[] { "PriorityId" });
            DropColumn("dbo.Task", "PriorityId");
            DropTable("dbo.Priority");
        }
    }
}
