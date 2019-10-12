namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTipsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AndyTipsterTips = c.String(nullable: false, maxLength: 2000),
                        IrishHorseTips = c.String(nullable: false, maxLength: 2000),
                        UltimateTips = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tips");
        }
    }
}
