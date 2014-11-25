namespace League.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSkeleton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .Index(t => t.Team_ID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DateOfTermination = c.DateTime(),
                        Person_ID = c.Int(nullable: false),
                        Team_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.Person_ID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_ID, cascadeDelete: true)
                .Index(t => t.Person_ID)
                .Index(t => t.Team_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Coach_ID = c.Int(),
                        Stadium_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.Coach_ID)
                .ForeignKey("dbo.Stadia", t => t.Stadium_ID)
                .Index(t => t.Coach_ID)
                .Index(t => t.Stadium_ID);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fixtures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KickOff = c.DateTime(nullable: false),
                        AwayTeam_ID = c.Int(),
                        HomeTeam_ID = c.Int(),
                        Referee_ID = c.Int(),
                        Season_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_ID)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_ID)
                .ForeignKey("dbo.People", t => t.Referee_ID)
                .ForeignKey("dbo.Seasons", t => t.Season_ID)
                .Index(t => t.AwayTeam_ID)
                .Index(t => t.HomeTeam_ID)
                .Index(t => t.Referee_ID)
                .Index(t => t.Season_ID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Stop = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FixtureStatistics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        Fixture_ID = c.Int(),
                        Player_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fixtures", t => t.Fixture_ID)
                .ForeignKey("dbo.People", t => t.Player_ID)
                .Index(t => t.Fixture_ID)
                .Index(t => t.Player_ID);
            
            CreateTable(
                "dbo.FixtureStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        Fixture_ID = c.Int(),
                        Status_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fixtures", t => t.Fixture_ID)
                .ForeignKey("dbo.FixtureStatus", t => t.Status_ID)
                .Index(t => t.Fixture_ID)
                .Index(t => t.Status_ID);
            
            AddColumn("dbo.AspNetUsers", "UserInfo_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserInfo_ID");
            AddForeignKey("dbo.AspNetUsers", "UserInfo_ID", "dbo.People", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserInfo_ID", "dbo.People");
            DropForeignKey("dbo.FixtureStatus", "Status_ID", "dbo.FixtureStatus");
            DropForeignKey("dbo.FixtureStatus", "Fixture_ID", "dbo.Fixtures");
            DropForeignKey("dbo.FixtureStatistics", "Player_ID", "dbo.People");
            DropForeignKey("dbo.FixtureStatistics", "Fixture_ID", "dbo.Fixtures");
            DropForeignKey("dbo.Fixtures", "Season_ID", "dbo.Seasons");
            DropForeignKey("dbo.Fixtures", "Referee_ID", "dbo.People");
            DropForeignKey("dbo.Fixtures", "HomeTeam_ID", "dbo.Teams");
            DropForeignKey("dbo.Fixtures", "AwayTeam_ID", "dbo.Teams");
            DropForeignKey("dbo.Contracts", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Stadium_ID", "dbo.Stadia");
            DropForeignKey("dbo.People", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Coach_ID", "dbo.People");
            DropForeignKey("dbo.Contracts", "Person_ID", "dbo.People");
            DropIndex("dbo.AspNetUsers", new[] { "UserInfo_ID" });
            DropIndex("dbo.FixtureStatus", new[] { "Status_ID" });
            DropIndex("dbo.FixtureStatus", new[] { "Fixture_ID" });
            DropIndex("dbo.FixtureStatistics", new[] { "Player_ID" });
            DropIndex("dbo.FixtureStatistics", new[] { "Fixture_ID" });
            DropIndex("dbo.Fixtures", new[] { "Season_ID" });
            DropIndex("dbo.Fixtures", new[] { "Referee_ID" });
            DropIndex("dbo.Fixtures", new[] { "HomeTeam_ID" });
            DropIndex("dbo.Fixtures", new[] { "AwayTeam_ID" });
            DropIndex("dbo.Contracts", new[] { "Team_ID" });
            DropIndex("dbo.Teams", new[] { "Stadium_ID" });
            DropIndex("dbo.People", new[] { "Team_ID" });
            DropIndex("dbo.Teams", new[] { "Coach_ID" });
            DropIndex("dbo.Contracts", new[] { "Person_ID" });
            DropColumn("dbo.AspNetUsers", "UserInfo_ID");
            DropTable("dbo.FixtureStatus");
            DropTable("dbo.FixtureStatistics");
            DropTable("dbo.Seasons");
            DropTable("dbo.Fixtures");
            DropTable("dbo.Stadia");
            DropTable("dbo.Teams");
            DropTable("dbo.Contracts");
            DropTable("dbo.People");
        }
    }
}
