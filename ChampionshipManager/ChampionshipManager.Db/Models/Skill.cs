using System;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipManager.Db.Models
{
    public class Skill : IEntity
    {
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public Organizer Organizer { get; set; }
        
    }
}