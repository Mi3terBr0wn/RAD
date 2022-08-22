namespace RAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductConsumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsumptionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumptions", t => t.ConsumptionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ConsumptionId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IncomeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        IncomeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incomes", t => t.IncomeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.IncomeId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomeProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Incomes", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.IncomeProducts", "IncomeId", "dbo.Incomes");
            DropForeignKey("dbo.ProductConsumptions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductConsumptions", "ConsumptionId", "dbo.Consumptions");
            DropIndex("dbo.Incomes", new[] { "ProviderId" });
            DropIndex("dbo.IncomeProducts", new[] { "IncomeId" });
            DropIndex("dbo.IncomeProducts", new[] { "ProductId" });
            DropIndex("dbo.ProductConsumptions", new[] { "ProductId" });
            DropIndex("dbo.ProductConsumptions", new[] { "ConsumptionId" });
            DropTable("dbo.Providers");
            DropTable("dbo.Incomes");
            DropTable("dbo.IncomeProducts");
            DropTable("dbo.Products");
            DropTable("dbo.ProductConsumptions");
            DropTable("dbo.Consumptions");
        }
    }
}
