using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Models
{
    public class BowlingLeagueContext : DbContext
    {
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>().ToTable("Bowlers");
            modelBuilder.Entity<Team>().ToTable("Teams");

            modelBuilder.Entity<Bowler>().HasKey(b => b.BowlerId);
            modelBuilder.Entity<Team>().HasKey(t => t.TeamId);

            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany()
                .HasForeignKey(b => b.TeamId);
        }
    }
}