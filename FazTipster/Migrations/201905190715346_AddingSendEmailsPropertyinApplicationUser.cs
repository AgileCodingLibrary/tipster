namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSendEmailsPropertyinApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SendEmails", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SendEmails");
        }
    }
}
