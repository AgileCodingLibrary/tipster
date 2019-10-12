namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAboutNavigationPropertyInPackageOfferedModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackageOffereds", "About_Id", "dbo.Abouts");
            DropIndex("dbo.PackageOffereds", new[] { "About_Id" });
            RenameColumn(table: "dbo.PackageOffereds", name: "About_Id", newName: "AboutId");
            AlterColumn("dbo.PackageOffereds", "AboutId", c => c.Int(nullable: false));
            CreateIndex("dbo.PackageOffereds", "AboutId");
            AddForeignKey("dbo.PackageOffereds", "AboutId", "dbo.Abouts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageOffereds", "AboutId", "dbo.Abouts");
            DropIndex("dbo.PackageOffereds", new[] { "AboutId" });
            AlterColumn("dbo.PackageOffereds", "AboutId", c => c.Int());
            RenameColumn(table: "dbo.PackageOffereds", name: "AboutId", newName: "About_Id");
            CreateIndex("dbo.PackageOffereds", "About_Id");
            AddForeignKey("dbo.PackageOffereds", "About_Id", "dbo.Abouts", "Id");
        }
    }
}
