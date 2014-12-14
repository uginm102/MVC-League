using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace League.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof (Resources.Resources), Name = "PersonLastName")]
        public string LastName { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "PersonFirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources.Resources), Name = "PersonDOB")]
        public DateTime DOB { get; set; }

        [Display(ResourceType = typeof (Resources.Resources), Name = "PersonFullName")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}