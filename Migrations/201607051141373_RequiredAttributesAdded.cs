namespace MyTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttributesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "TaskGroup_ID", "dbo.TaskGroup");
            DropIndex("dbo.Task", new[] { "TaskGroup_ID" });
            AlterColumn("dbo.TaskGroup", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "TaskGroup_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Task", "TaskGroup_ID");
            AddForeignKey("dbo.Task", "TaskGroup_ID", "dbo.TaskGroup", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "TaskGroup_ID", "dbo.TaskGroup");
            DropIndex("dbo.Task", new[] { "TaskGroup_ID" });
            AlterColumn("dbo.Task", "TaskGroup_ID", c => c.Int());
            AlterColumn("dbo.Task", "Content", c => c.String());
            AlterColumn("dbo.Task", "Name", c => c.String());
            AlterColumn("dbo.TaskGroup", "Name", c => c.String());
            CreateIndex("dbo.Task", "TaskGroup_ID");
            AddForeignKey("dbo.Task", "TaskGroup_ID", "dbo.TaskGroup", "ID");
        }
    }
}
