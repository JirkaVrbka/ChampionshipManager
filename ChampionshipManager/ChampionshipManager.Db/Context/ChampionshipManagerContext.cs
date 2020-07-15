using System;
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
        
        public ChampionshipManagerContext(DbContextOptions<ChampionshipManagerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}