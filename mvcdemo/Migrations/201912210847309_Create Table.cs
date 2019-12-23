namespace mvcdemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        AddressLine = c.String(name: "Address Line", nullable: false, maxLength: 100),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemName = c.String(),
                        ItemId = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitName = c.String(nullable: false),
                        UnitId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UnitId);
            
            CreateTable(
                "dbo.SaleInvoiceHeaders",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        InvoiceNo = c.String(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SaleInvoiceLines",
                c => new
                    {
                        Quantity = c.Decimal(nullable: false, precision: 2, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 2, scale: 2),
                        SaleLineId = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleLineId)
                .ForeignKey("dbo.SaleInvoiceLines", t => t.ItemId)
                .ForeignKey("dbo.SaleInvoiceHeaders", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleInvoiceLines", "SaleId", "dbo.SaleInvoiceHeaders");
            DropForeignKey("dbo.SaleInvoiceLines", "ItemId", "dbo.SaleInvoiceLines");
            DropForeignKey("dbo.SaleInvoiceHeaders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Items", "UnitId", "dbo.Units");
            DropIndex("dbo.SaleInvoiceLines", new[] { "ItemId" });
            DropIndex("dbo.SaleInvoiceLines", new[] { "SaleId" });
            DropIndex("dbo.SaleInvoiceHeaders", new[] { "CustomerId" });
            DropIndex("dbo.Items", new[] { "UnitId" });
            DropTable("dbo.SaleInvoiceLines");
            DropTable("dbo.SaleInvoiceHeaders");
            DropTable("dbo.Units");
            DropTable("dbo.Items");
            DropTable("dbo.Customers");
        }
    }
}
