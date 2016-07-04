namespace MyTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        TaskGroup_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TaskGroup", t => t.TaskGroup_ID)
                .Index(t => t.TaskGroup_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "TaskGroup_ID", "dbo.TaskGroup");
            DropIndex("dbo.Task", new[] { "TaskGroup_ID" });
            DropTable("dbo.Task");
            DropTable("dbo.TaskGroup");
        }
    }
}
