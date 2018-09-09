namespace Credit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFieldValueAndPorcentage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debts", "Value", c => c.Double(nullable: false));
            AddColumn("dbo.Debts", "Percentage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Debts", "Percentage");
            DropColumn("dbo.Debts", "Value");
        }
    }
}
