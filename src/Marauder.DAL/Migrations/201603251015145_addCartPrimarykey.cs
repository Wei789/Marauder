namespace Marauder.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCartPrimarykey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "CartId", c => c.String());
            AlterColumn("dbo.Carts", "RecordId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "RecordId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "RecordId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "CartId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Carts", "CartId");
        }
    }
}
