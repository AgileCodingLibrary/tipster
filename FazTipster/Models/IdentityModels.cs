using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using FazTipster.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FazTipster.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool SendEmails { get; set; }

        public string SubscriptionId { get; set; }
        public string SubscriptionDescription { get; set; }
        public string SubscriptionState { get; set; }
        public string SubscriptionEmail { get; set; }
        public string SubscriptionFirstName { get; set; }
        public string SubscriptionLastName { get; set; }
        public string SubscriptionPostalCode { get; set; }

        public string PayPalAgreementId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Entities.Subscription> Subscriptions { get; set; }
        public DbSet<Entities.Questions> Questions { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Tips> Tips { get; set; }

        public DbSet<LandingPage> LandingPages { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}