namespace League.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestatustostate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FixtureStatus", "Status_ID", "dbo.FixtureStatus");
            DropIndex("dbo.FixtureStatus", new[] { "Status_ID" });
            AddColumn("dbo.FixtureStatus", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.FixtureStatus", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.FixtureStatus", "Status_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FixtureStatus", "Status_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FixtureStatus", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.FixtureStatus", "State");
            CreateIndex("dbo.FixtureStatus", "Status_ID");
            AddForeignKey("dbo.FixtureStatus", "Status_ID", "dbo.FixtureStatus", "ID");
        }
    }
}
