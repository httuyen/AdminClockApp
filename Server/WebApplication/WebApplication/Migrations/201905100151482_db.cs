namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "datecreate", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "datecreate", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
