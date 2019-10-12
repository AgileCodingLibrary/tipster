namespace FazTipster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscriptionDetailsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SubscriptionId", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionDescription", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionState", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionEmail", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionFirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionLastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubscriptionPostalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SubscriptionPostalCode");
            DropColumn("dbo.AspNetUsers", "SubscriptionLastName");
            DropColumn("dbo.AspNetUsers", "SubscriptionFirstName");
            DropColumn("dbo.AspNetUsers", "SubscriptionEmail");
            DropColumn("dbo.AspNetUsers", "SubscriptionState");
            DropColumn("dbo.AspNetUsers", "SubscriptionDescription");
            DropColumn("dbo.AspNetUsers", "SubscriptionId");
        }
    }
}
