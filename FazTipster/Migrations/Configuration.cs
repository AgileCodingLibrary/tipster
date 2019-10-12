namespace FazTipster.Migrations
{
    using FazTipster.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FazTipster.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FazTipster.Models.ApplicationDbContext";
        }

        protected override void Seed(FazTipster.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Tips.Any())
            {
                // add tips

                Tips tips = new Tips();
                tips.AndyTipsterTips = "AndyTipsterTips tips go here.";
                tips.IrishHorseTips = "IrishHorseTips tips go here.";
                tips.UltimateTips = "UltimateTips tips go here.";

                context.Tips.Add(tips);
            }

            if (!context.Abouts.Any())
            {
                // add about 
                About about = new About();
                about.FirstTopParagraph = "First Top Paragraph";
                about.PackageOneDetails = "Package One Details";
                about.PackageOneHeading = "Package One Heading";
                about.PackagesTitle = "Packages Title";
                about.PackageThreeDetails = "Package Three Details";
            }


        }
    }
}
