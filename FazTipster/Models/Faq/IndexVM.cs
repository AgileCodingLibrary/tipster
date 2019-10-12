using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FazTipster.Entities;

namespace FazTipster.Models.Faq
{
    public class IndexVM
    {
        public List<Questions> Questions { get; set; } = new List<Questions>();
    }
}