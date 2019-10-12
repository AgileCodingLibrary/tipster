using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FazTipster.Models.Subscription
{
    public class Plan
    {
        public string PayPalPlanId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        public static List<Plan> Plans => new List<Plan>()
        {
            new Plan()
            {
                Name = "AndyTipster Monthly Package",
                Price = 1300,
                PayPalPlanId = "P-8FA01768GN086944DTE4J2PI", // Created in the BillingPlansController.
                Description = "Membership group that's amassed Thousands of ££ Profit Since Feb 2013",
            },
            new Plan()
            {
                Name = "AndyTipster Three Months Package",
                Price = 3500,
                PayPalPlanId = "P-8NM2876475709704TTE4KBHA", // Created in the BillingPlansController.
                Description = "Membership group that's amassed Thousands of ££ Profit Since Feb 2013",
            },
              new Plan()
            {
                Name = "Irish Horse Racing - Monthly Subscription",
                Price = 1000,
                PayPalPlanId = "P-49A56000A6163212YTE4KIQI", // Created in the BillingPlansController.
                Description = "Proven Success on facebook With Years of Gains at level Stakes",
            },
                  new Plan()
            {
                Name = "Irish Horse Racing - Three Months Subscription",
                Price = 2750,
                PayPalPlanId = "P-5U268280XB476211XTE4KPTY", // Created in the BillingPlansController.
                Description = "Proven Success on facebook With Years of Gains at level Stakes",
            },
                 new Plan()
            {
                Name = "Ultimate pack - Monthly Subscription",
                Price = 1700,
                PayPalPlanId = "P-8AC488780J6779351TE4KW7A", // Created in the BillingPlansController.
                Description = "The combination of all sports- Horse Racing from the UK and IRE aswell as other sports",
            },
                      new Plan()
            {
                Name = "Ultimate pack - Three Months Subscription",
                Price = 4500,
                PayPalPlanId = "P-9H0036907S152411BTE4K53Q", // Created in the BillingPlansController.
                Description = "The combination of all sports- Horse Racing from the UK and IRE aswell as other sports",
            }
        };
    }


}