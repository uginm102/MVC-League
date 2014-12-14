using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace League.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "ContractStartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "ContractEndDate")]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "ContractDateOfTermination")]
        public DateTime? DateOfTermination { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "ContractPerson")]
        public virtual Person Person { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "ContractTeam")]
        public virtual Team Team { get; set; }
    }
}