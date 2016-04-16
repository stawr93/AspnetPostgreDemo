namespace AspnetPostgreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_Id" });
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        OrderId = c.Long(nullable: false),
                        BookId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.BookId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
            
            DropColumn("dbo.Books", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Order_Id", c => c.Long());
            DropForeignKey("dbo.OrderBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderBooks", new[] { "BookId" });
            DropIndex("dbo.OrderBooks", new[] { "OrderId" });
            DropTable("dbo.OrderBooks");
            CreateIndex("dbo.Books", "Order_Id");
            AddForeignKey("dbo.Books", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
