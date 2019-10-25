namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LandingPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LandingPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandingPageHtml = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LandingPages");
        }
    }
}
