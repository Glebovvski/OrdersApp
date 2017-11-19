namespace TestAppOrders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredManager : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers");
            DropIndex("dbo.Orders", new[] { "Manager_Id" });
            AlterColumn("dbo.Orders", "Manager_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Manager_Id");
            AddForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers");
            DropIndex("dbo.Orders", new[] { "Manager_Id" });
            AlterColumn("dbo.Orders", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Manager_Id");
            AddForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers", "Id");
        }
    }
}
