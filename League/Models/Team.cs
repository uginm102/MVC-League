using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "TeamName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "TeamStadium")]
        public virtual Stadium Stadium { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "TeamCoach")]
        public virtual Coach Coach { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "TeamPlayers")]
        public virtual ICollection<Player> Players { get; set; }
    }
}