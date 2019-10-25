namespace FazTipster.Migrations
{
    using FazTipster.Entities;
    using FazTipster.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            if (!context.LandingPages.Any())
            {
                Entities.LandingPage landingPage = new Entities.LandingPage();
                landingPage.LandingPageHtml = "<p>Site Admin needs to add landing page contents.";
                context.LandingPages.Add(landingPage);
                context.SaveChanges();

            }


            if (!context.Tips.Any())
            {
                // add tips

                Tips tips = new Tips();
                tips.AndyTipsterTips = "AndyTipsterTips tips go here.";
                tips.IrishHorseTips = "IrishHorseTips tips go here.";
                tips.UltimateTips = "UltimateTips tips go here.";

                context.Tips.Add(tips);
                context.SaveChanges();
            }

            if (!context.Abouts.Any())
            {
                // add about 
                About about = new About();

                about.Header = "About page header";
                about.FirstTopParagraph = "First Top Paragraph";
                about.SecondTopParagraph = "Second top paragraph";

                about.PackagesTitle = "Packages Title";

                about.PackageOneHeading = "Package One Heading";
                about.PackageOneDetails = "Package One Details";

                about.PackageTwoHeading = "Package Two Heading";
                about.PackageTWoDetails = "Package TWo Details";

                about.PackageThreeHeading = "Package Three Heading";
                about.PackageThreeDetails = "Package Three Details";

                context.Abouts.Add(about);
                context.SaveChanges();
            }

            if (!context.Questions.Any())
            {
                // add about 
                Questions question = new Questions();

                question.Question = "You have asked a question ?";
                question.Answer = "We will answer very soon.";

                context.Questions.Add(question);
                context.SaveChanges();
            }


            if (!context.Roles.Any(r => r.Name == "Masteradmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Masteradmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "fazahmed786"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "fazahmed786@hotmail.com", Email = "fazahmed786@hotmail.com" };

                manager.Create(user, "Abcd123$");
                manager.AddToRole(user.Id, "Masteradmin");
            }

        }
    }
}
