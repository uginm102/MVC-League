using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace League.Models
{
    public class LeagueDbContext : IdentityDbContext<User>
    {
        public LeagueDbContext()
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
        public DbSet<Person> Person { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Team>().HasRequired(a => a.Coach).WithRequiredPrincipal(b => b.Team);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}