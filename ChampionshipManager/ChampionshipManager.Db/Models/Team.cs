using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChampionshipManager.Db.Models
{
    public class Team : IEntity
    {
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public Organizer Organizer { get; set; }

        public List<Competitor> Competitors { get; set; }
    }
}