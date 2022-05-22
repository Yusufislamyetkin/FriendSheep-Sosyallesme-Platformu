namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig_contant_messagedateupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MessageDateT", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MessageDateT");
        }
    }
}
