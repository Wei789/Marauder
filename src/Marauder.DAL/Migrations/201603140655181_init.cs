namespace Marauder.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorID = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LoginIp = c.String(),
                        LoginTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AdministratorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Administrators");
        }
    }
}
