using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipManager.Db.Models
{
    public class Championship : IEntity
    {
        public Guid ID { get; set; }

        [Required] public string Name { get; set; }

        [Required] public bool IsFinished { get; set; }

        [Required] public Organizer Organizer { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}