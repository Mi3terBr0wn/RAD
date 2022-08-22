﻿namespace RAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
