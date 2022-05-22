namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addGalerryy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryID = c.Int(nullable: false, identity: true),
                        PicturePath = c.String(maxLength: 150),
                        PictureName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.GalleryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
