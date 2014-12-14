using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Fixture
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureKickOff")]
        public DateTime KickOff { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureHomeTeam")]
        public virtual Team HomeTeam { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureAwayTeam")]
        public virtual Team AwayTeam { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureSeason")]
        public virtual Season Season { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "FixtureReferee")]
        public virtual Referee Referee { get; set; }
    }
}