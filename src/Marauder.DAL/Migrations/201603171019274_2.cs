namespace Marauder.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Administrators", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Administrators", "Name", c => c.String(nullable: false));
        }
    }
}
