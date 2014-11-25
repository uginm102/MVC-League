using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Contract
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Contract start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Contract end date")]
        public DateTime EndDate { get; set; }

        public DateTime? DateOfTermination { get; set; }

        [Required]
        public virtual Person Person { get; set; }

        [Required]
        [Display(Name = "Team")]
        public virtual Team Team { get; set; }
    }
}