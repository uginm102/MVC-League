using League.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class FixtureStatus
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "State")]
        public FixtureState State { get; set; }

        [Required]
        [Display(Name = "Status")]
        public FixturePeriod Period { get; set; }

        public virtual Fixture Fixture { get; set; }
    }
}