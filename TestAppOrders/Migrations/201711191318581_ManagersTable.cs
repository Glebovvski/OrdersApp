namespace TestAppOrders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Manager_Id");
            AddForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers", "Id");
            DropColumn("dbo.Orders", "Manager");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Manager", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "Manager_Id", "dbo.Managers");
            DropIndex("dbo.Orders", new[] { "Manager_Id" });
            DropColumn("dbo.Orders", "Manager_Id");
            DropTable("dbo.Managers");
        }
    }
}
