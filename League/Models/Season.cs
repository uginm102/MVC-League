using System;
using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "SeasonName")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "SeasonStartDate")]
        public DateTime Start { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "SeasonEndDate")]
        public DateTime Stop { get; set; }
    }
}