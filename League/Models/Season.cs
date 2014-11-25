using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Season
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Season end date")]
        public DateTime Start { get; set; }


        [Required]
        [Display(Name = "Season start date")]
        public DateTime Stop { get; set; }
    }
}