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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(e => e.AwayTeam)
                .WithMany(e => e.AwayGames)
                .HasForeignKey(e => e.AwayTeamId)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .HasOne(e => e.HomeTeam)
                .WithMany(e => e.HomeGames)
                .HasForeignKey(e => e.HomeTeamId)
                .IsRequired();

            modelBuilder.Entity<Week>()
                .HasMany(e => e.Byes)
                .WithOne(e => e.Bye)
                .HasForeignKey(e => e.ByeId)
                .IsRequired(false);
        }
    }
}
