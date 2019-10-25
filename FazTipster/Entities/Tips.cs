using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FazTipster.Entities
{
    public class Tips
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string AndyTipsterTips { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string IrishHorseTips { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string UltimateTips { get; set; }
    }


}