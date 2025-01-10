using Microsoft.EntityFrameworkCore;
using RbTrackerBE.Models;

namespace RbTrackerBE.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamInYear> TeamsInYears { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Year> Years { get; set; }
    }
}
