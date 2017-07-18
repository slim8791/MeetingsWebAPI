namespace MeetingsWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Lattitude", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Longitude", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Lattitude", c => c.Double(nullable: false));
        }
    }
}
