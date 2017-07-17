namespace MeetingsWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        CoffeeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Adresse = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.CoffeeId);
            
            CreateTable(
                "dbo.Meets",
                c => new
                    {
                        MeetId = c.Int(nullable: false, identity: true),
                        DateMeet = c.DateTime(nullable: false),
                        Decription = c.String(),
                        CoffeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeetId)
                .ForeignKey("dbo.Coffees", t => t.CoffeeId, cascadeDelete: true)
                .Index(t => t.CoffeeId);
            
            AddColumn("dbo.People", "Meet_MeetId", c => c.Int());
            CreateIndex("dbo.People", "Meet_MeetId");
            AddForeignKey("dbo.People", "Meet_MeetId", "dbo.Meets", "MeetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Meet_MeetId", "dbo.Meets");
            DropForeignKey("dbo.Meets", "CoffeeId", "dbo.Coffees");
            DropIndex("dbo.People", new[] { "Meet_MeetId" });
            DropIndex("dbo.Meets", new[] { "CoffeeId" });
            DropColumn("dbo.People", "Meet_MeetId");
            DropTable("dbo.Meets");
            DropTable("dbo.Coffees");
        }
    }
}
