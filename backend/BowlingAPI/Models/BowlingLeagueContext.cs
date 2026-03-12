using Microsoft.EntityFrameworkCore;

// BowlingLeagueContext.cs
// BowlingLeagueContext class that represents the database context for the bowling 
// league, including DbSet properties

namespace BowlingAPI.Models
{
    public class BowlingLeagueContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes it to the base class 
        // constructor
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        // Override the OnModelCreating method to configure the model and relationships
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