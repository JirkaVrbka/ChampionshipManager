using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class OrganizerRepository : ASpecificEntityRepository<Organizer>
    {
        protected override List<string> Includes { get; } = new List<string>
            { nameof(Organizer.Skills), nameof(Organizer.Competitors), nameof(Organizer.Championships) };
        
        public OrganizerRepository(ChampionshipManagerContext context) : base(context)
        {
            if (!context.Organizers.Any())
            {
                Create(new Organizer{Name = "b@b.b", AgeEnabled = true, BirthEnabled = false, GenderEnabled = true, SkillsEnabled = false});
            }
        }

        public Guid GetIdByName(string organizerName)
        {
            return Filter(o => o.Name == organizerName, null).Single().ID;
        }
    }
}