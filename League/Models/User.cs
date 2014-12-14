using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace League.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public virtual UserInfo UserInfo { get; set; }
    }

    
}