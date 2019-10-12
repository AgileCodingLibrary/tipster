namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanNameAndPayPalEmailIntoSubscriptionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "PayPalPlanName", c => c.String());
            AddColumn("dbo.Subscriptions", "PayPalPaymentEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "PayPalPaymentEmail");
            DropColumn("dbo.Subscriptions", "PayPalPlanName");
        }
    }
}
