namespace MeetingsWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personmeet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonMeets",
                c => new
                    {
                        MeetId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MeetId, t.PersonId })
                .ForeignKey("dbo.Meets", t => t.MeetId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.MeetId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonMeets", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonMeets", "MeetId", "dbo.Meets");
            DropIndex("dbo.PersonMeets", new[] { "PersonId" });
            DropIndex("dbo.PersonMeets", new[] { "MeetId" });
            DropTable("dbo.PersonMeets");
        }
    }
}
