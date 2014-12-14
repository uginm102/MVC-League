namespace League.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoachNeedsTeam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "ID", c => c.Int());
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Id", c => c.Int());
            AlterColumn("dbo.People", "ID", c => c.Int(nullable: false));
        }
    }
}
