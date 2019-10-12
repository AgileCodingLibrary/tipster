namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAboutModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 200),
                        FirstTopParagraph = c.String(nullable: false, maxLength: 2000),
                        SecondTopParagraph = c.String(nullable: false, maxLength: 2000),
                        PackagesTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageOffereds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 2000),
                        About_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abouts", t => t.About_Id)
                .Index(t => t.About_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageOffereds", "About_Id", "dbo.Abouts");
            DropIndex("dbo.PackageOffereds", new[] { "About_Id" });
            DropTable("dbo.PackageOffereds");
            DropTable("dbo.Abouts");
        }
    }
}
