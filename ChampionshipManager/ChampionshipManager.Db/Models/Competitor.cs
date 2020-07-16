using System;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipManager.Db.Models
{
    public class Competitor : IEntity
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public Skill Skill { get; set; }
        public Gender Gender { get; set; }

        [Required]
        public Organizer Organizer { get; set; }

        public Team Team { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
}