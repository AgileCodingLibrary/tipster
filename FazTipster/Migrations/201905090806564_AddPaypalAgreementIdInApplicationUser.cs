namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaypalAgreementIdInApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PayPalAgreementId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PayPalAgreementId");
        }
    }
}
