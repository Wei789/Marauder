namespace Marauder.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Administrators", "Account", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Administrators", "Password", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Administrators", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Administrators", "Account", c => c.String(nullable: false));
        }
    }
}
