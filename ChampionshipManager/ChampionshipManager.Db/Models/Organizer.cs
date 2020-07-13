using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipManager.Db.Models
{
    public class Organizer : IEntity
    {
        public Guid ID { set; get; }

        [Required]
        public string Name { get; set; }

        public string HashedPassword { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Competitor> Competitors { get; set; }
    }
}