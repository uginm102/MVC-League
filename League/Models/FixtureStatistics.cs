using League.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class FixtureStatistics
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureAction")]
        public FixtureAction Action { get; set; }

        public virtual Fixture Fixture { get; set; }

        public virtual Player Player { get; set; }
    }
}