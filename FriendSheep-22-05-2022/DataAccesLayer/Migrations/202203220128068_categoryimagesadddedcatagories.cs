namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryimagesadddedcatagories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Categoryimages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Categoryimages");
        }
    }
}
