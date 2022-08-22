namespace RAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        IncomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incomes", t => t.IncomeId, cascadeDelete: true)
                .Index(t => t.IncomeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "IncomeId", "dbo.Incomes");
            DropIndex("dbo.Payments", new[] { "IncomeId" });
            DropTable("dbo.Payments");
        }
    }
}
