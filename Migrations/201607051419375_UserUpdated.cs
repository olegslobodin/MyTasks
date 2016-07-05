namespace MyTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Password");
        }
    }
}
