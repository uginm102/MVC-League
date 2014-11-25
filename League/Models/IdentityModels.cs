using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace League.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual UserInfo UserInfo { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Fixture> Fixture { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<FixtureStatistics> FixtureStatistics { get; set; }
        public DbSet<FixtureStatus> FixtureStatus { get; set; }
        public DbSet<Season> Season { get; set; }
    }
}