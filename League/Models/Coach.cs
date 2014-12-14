using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Coach : Person
    {
        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "CoachTeam")]
        public virtual Team Team { get; set; }
    }
}