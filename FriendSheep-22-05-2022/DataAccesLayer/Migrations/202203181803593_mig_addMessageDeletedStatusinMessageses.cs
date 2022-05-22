namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addMessageDeletedStatusinMessageses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDeletedStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDeletedStatus");
        }
    }
}
