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
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureState")]
        public FixtureState State { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "FixturePeriod")]
        public FixturePeriod Period { get; set; }

        public virtual Fixture Fixture { get; set; }
    }
}