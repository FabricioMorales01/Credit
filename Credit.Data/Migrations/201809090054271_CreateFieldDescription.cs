namespace Credit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFieldDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Debts", "Description");
        }
    }
}
