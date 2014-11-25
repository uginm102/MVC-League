using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Fixture
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Kick off")]
        public DateTime KickOff { get; set; }

        [Display(Name = "Home team")]
        public virtual Team HomeTeam { get; set; }

        [Display(Name = "Away team")]
        public virtual Team AwayTeam { get; set; }

        public virtual Season Season { get; set; }

        public virtual Referee Referee { get; set; }
    }
}