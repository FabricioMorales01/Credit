namespace Credit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DebtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Debtors", t => t.DebtorId, cascadeDelete: true)
                .Index(t => t.DebtorId);
            
            CreateTable(
                "dbo.Debtors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Debts", "DebtorId", "dbo.Debtors");
            DropIndex("dbo.Debts", new[] { "DebtorId" });
            DropTable("dbo.Debtors");
            DropTable("dbo.Debts");
        }
    }
}
