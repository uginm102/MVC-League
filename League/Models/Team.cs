using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Team
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual Stadium Stadium { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}