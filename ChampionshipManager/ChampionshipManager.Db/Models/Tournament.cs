using System;
using System.Collections.Generic;

namespace ChampionshipManager.Db.Models
{
    public class Tournament : IEntity
    {
        public Guid ID { get; set; }

        public TournamentType TournamentType { get; set; }

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