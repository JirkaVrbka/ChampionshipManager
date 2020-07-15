using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipManager.Db.Models
{
    public class Tournament : IEntity
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public TournamentType TournamentType { get; set; }
        [Required]
        public bool IsFinished { get; set; }

        [Required]
        public Championship Championship { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<Game> Games { get; set; }
    }

    public enum TournamentType
    {
        AgainstEverybody,
        Spider,
    }
}