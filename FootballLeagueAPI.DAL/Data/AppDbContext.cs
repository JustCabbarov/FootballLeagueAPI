using FootballLeague.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
        .HasOne(m => m.HostTeam)
        .WithMany()
        .HasForeignKey(m => m.HostTeamId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.GuestTeam)
                .WithMany()
                .HasForeignKey(m => m.GuestTeamId)
                .OnDelete(DeleteBehavior.Restrict);

           
        
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Stadium)
                .WithOne(s => s.Team)
                .HasForeignKey<Team>(t => t.StadiumId); // Foreign key Team-dədir
        }

        

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<MatchGoal> MatchGoals { get; set; }
    }
}
