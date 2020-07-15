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
        public bool AgeEnabled { get; set; }
        public bool SkillsEnabled { get; set; }
        public bool GenderEnabled { get; set; }
        public bool BirthEnabled { get; set; }


        public string HashedPassword { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Competitor> Competitors { get; set; }
        public List<Championship> Championships { get; set; }
    }
}