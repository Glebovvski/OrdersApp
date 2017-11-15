namespace TestAppOrders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: true),
                        Manager = c.Int(nullable: false),
                        Annotation = c.String(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
