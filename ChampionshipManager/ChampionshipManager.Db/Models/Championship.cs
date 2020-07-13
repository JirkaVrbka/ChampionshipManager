using System;
using System.Collections.Generic;

namespace ChampionshipManager.Db.Models
{
    public class Championship : IEntity
    {
        public Guid ID { get; set; }

        public Organizer Organizer { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<Tournament> Tournaments { get; set; }

    }
}