namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePackageOfferedModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackageOffereds", "AboutId", "dbo.Abouts");
            DropIndex("dbo.PackageOffereds", new[] { "AboutId" });
            AddColumn("dbo.Abouts", "PackageOneHeading", c => c.String());
            AddColumn("dbo.Abouts", "PackageOneDetails", c => c.String(nullable: false, maxLength: 2000));
            AddColumn("dbo.Abouts", "PackageTwoHeading", c => c.String());
            AddColumn("dbo.Abouts", "PackageTWoDetails", c => c.String(nullable: false, maxLength: 2000));
            AddColumn("dbo.Abouts", "PackageThreeHeading", c => c.String());
            AddColumn("dbo.Abouts", "PackageThreeDetails", c => c.String(nullable: false, maxLength: 2000));
            DropTable("dbo.PackageOffereds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PackageOffereds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 2000),
                        AboutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Abouts", "PackageThreeDetails");
            DropColumn("dbo.Abouts", "PackageThreeHeading");
            DropColumn("dbo.Abouts", "PackageTWoDetails");
            DropColumn("dbo.Abouts", "PackageTwoHeading");
            DropColumn("dbo.Abouts", "PackageOneDetails");
            DropColumn("dbo.Abouts", "PackageOneHeading");
            CreateIndex("dbo.PackageOffereds", "AboutId");
            AddForeignKey("dbo.PackageOffereds", "AboutId", "dbo.Abouts", "Id", cascadeDelete: true);
        }
    }
}
