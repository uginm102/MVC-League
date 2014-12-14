using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Player : Person
    {
        [Display(ResourceType = typeof (Resources.Resources), Name = "PlayerTeam")]
        public virtual Team Team { get; set; }
    }
}