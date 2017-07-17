namespace MeetingsWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "LocationId");
            AddForeignKey("dbo.People", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "LocationId", "dbo.Locations");
            DropIndex("dbo.People", new[] { "LocationId" });
            DropColumn("dbo.People", "LocationId");
        }
    }
}
