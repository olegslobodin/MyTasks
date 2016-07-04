namespace MyTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        SecretKey = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SecretKey);
            
            AddColumn("dbo.Task", "User_SecretKey", c => c.Int());
            AlterColumn("dbo.TaskGroup", "Name", c => c.String());
            CreateIndex("dbo.Task", "User_SecretKey");
            AddForeignKey("dbo.Task", "User_SecretKey", "dbo.User", "SecretKey");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "User_SecretKey", "dbo.User");
            DropIndex("dbo.Task", new[] { "User_SecretKey" });
            AlterColumn("dbo.TaskGroup", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Task", "User_SecretKey");
            DropTable("dbo.User");
        }
    }
}
