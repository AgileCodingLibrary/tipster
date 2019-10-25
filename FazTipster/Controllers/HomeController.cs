using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FazTipster.ViewModels;

namespace FazTipster.Controllers
{
    public class HomeController : Controller
    {
        private Models.ApplicationDbContext _dbContext => HttpContext.GetOwinContext().Get<Models.ApplicationDbContext>();

        public ActionResult Index()
        {
            var landingPage = _dbContext.LandingPages.FirstOrDefault();
            return View(landingPage);
        }

        [Authorize]
        public ActionResult AndyTipsterTips()
        {
            //check the state of user Paypal subscription.
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _dbContext.Users.Where(x => x.Id == currentUserId).FirstOrDefault();
            var apiContext = GetApiContext();

            var tips = _dbContext.Tips.FirstOrDefault();

            if (currentUser.PayPalAgreementId != null )
            {
                var agreement = Agreement.Get(apiContext, currentUser.PayPalAgreementId);

                if (agreement != null)
                {
                    currentUser.SubscriptionState = agreement.state;
                }

                if (currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "AndyTipster Monthly Package" ||
                    currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "AndyTipster Three Months Package" ||
                     currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Monthly Subscription" ||
                     currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Three Months Subscription" )
                {
                    return View(tips);
                }
            }

            if (User.IsInRole("Masteradmin"))
            {
                return View(tips);
            }

            return View("NotAuthorized");
        }

        [Authorize]
        public ActionResult IrishRacingTips()
        {
            //check the state of user Paypal subscription.
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _dbContext.Users.Where(x => x.Id == currentUserId).FirstOrDefault();
            var apiContext = GetApiContext();

            var tips = _dbContext.Tips.FirstOrDefault();

            if (currentUser.PayPalAgreementId != null)
            {
                var agreement = Agreement.Get(apiContext, currentUser.PayPalAgreementId);

                if (agreement != null)
                {
                    currentUser.SubscriptionState = agreement.state;
                }

                if (currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Irish Horse Racing - Monthly Subscription" ||
                    currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Irish Horse Racing - Three Months Subscription" ||
                     currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Monthly Subscription" ||
                     currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Three Months Subscription")
                {
                    return View(tips);
                }
            }

            if (User.IsInRole("Masteradmin"))
            {
                return View(tips);
            }

            return View("NotAuthorized");
        }

        [Authorize]
        public ActionResult UltimatePackTips()
        {
            //check the state of user Paypal subscription.
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _dbContext.Users.Where(x => x.Id == currentUserId).FirstOrDefault();
            //bool IsAdmin = User.IsInRole("Masteradmin");

            var apiContext = GetApiContext();

            var tips = _dbContext.Tips.FirstOrDefault();

            if (currentUser.PayPalAgreementId != null)
            {
                var agreement = Agreement.Get(apiContext, currentUser.PayPalAgreementId);

                if (agreement != null)
                {
                    currentUser.SubscriptionState = agreement.state;
                }

                if (currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Monthly Subscription" ||
                     currentUser.SubscriptionState == "Active" && currentUser.SubscriptionDescription == "Ultimate pack - Three Months Subscription" )
                {
                    return View(tips);
                }
            }

            if (User.IsInRole("Masteradmin"))
            {
                return View(tips);
            }

            return View("NotAuthorized");
        }

        public ActionResult Faq()
        {
            var questions = _dbContext.Questions.ToList();

            return View(questions);
        }

        public ActionResult HowToSubscribe()
        {
            ViewBag.Title = "Step to start receiving your daily tips";

            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            var vm = _dbContext.Abouts.FirstOrDefault();

            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NotAuthorized()
        {
            ViewBag.Message = "NotAuthorized";

            return View();
        }

        [Authorize(Roles = "Masteradmin")]
        public ActionResult EmailList()
        {
            List<EmailListViewModel> vm = _dbContext.Users.Where(y => y.SendEmails == true).Select( x => 
            new EmailListViewModel() {

                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();

            return View(vm);
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }
    }
}