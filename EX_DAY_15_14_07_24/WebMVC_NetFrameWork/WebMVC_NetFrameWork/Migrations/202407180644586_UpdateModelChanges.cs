namespace WebMVC_NetFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
