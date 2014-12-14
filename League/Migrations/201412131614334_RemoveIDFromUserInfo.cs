namespace League.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIDFromUserInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Id", c => c.Int());
        }
    }
}
