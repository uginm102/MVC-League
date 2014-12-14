using System.ComponentModel.DataAnnotations;

namespace League.Models
{
    public class Stadium
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "StadiumName")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "StadiumAddress")]
        public string Address { get; set; }
    }
}