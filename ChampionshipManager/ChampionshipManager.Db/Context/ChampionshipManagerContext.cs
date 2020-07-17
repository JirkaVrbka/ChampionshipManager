using ChampionshipManager.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipManager.Db.Context
{
    public class ChampionshipManagerContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ChampionshipManagerContext(DbContextOptions<ChampionshipManagerContext> options) : base(options)
        {
            // TODO remove deleting of DB
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // modelBuilder.Entity<Organizer>()
        //     //     .HasIndex(e => new { e.ID, e.Name })
        //     //     .IsUnique(true);
        //     
        //     // TODO https://stackoverflow.com/questions/41246614/entity-framework-core-add-unique-constraint-code-first
        //     // modelBuilder.Entity<Skill>()
        //     //     .HasIndex(e => new { e.Organizer.ID, e.Name })
        //     //     .IsUnique(true);
        //     //
        //     // modelBuilder.Entity<Team>()
        //     //     .HasIndex(e => new { e.Organizer.ID, e.Name })
        //     //     .IsUnique(true);
        // }
    }
}