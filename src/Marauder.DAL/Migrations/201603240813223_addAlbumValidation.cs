namespace Marauder.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAlbumValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Albums", "AlbumArtUrl", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "AlbumArtUrl", c => c.String());
            AlterColumn("dbo.Albums", "Title", c => c.String());
        }
    }
}
