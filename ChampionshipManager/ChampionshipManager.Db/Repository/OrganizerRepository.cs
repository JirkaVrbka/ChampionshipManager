using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class OrganizerRepository : ASpecificEntityRepository<Organizer>
    {
        public override List<string> Includes { get; } = new List<string>
        {
            nameof(Organizer.Skills), 
            nameof(Organizer.Competitors), 
            nameof(Organizer.Championships),
            nameof(Organizer.Teams)
        };
        
        // public OrganizerRepository(IContextProvider provider) : base(provider)
        // {
        //     // if (!context.Organizers.Any())
        //     // {
        //     //     var organizer = new Organizer
        //     //     {
        //     //         Name = "b@b.b", AgeEnabled = true, BirthEnabled = false, GenderEnabled = true, SkillsEnabled = false
        //     //     };
        //     //     organizer.Skills = new List<Skill>{new Skill{ Name = "None", Order = 0, Organizer = organizer}};
        //     //     organizer.Teams = new List<Team>{new Team{ Name = "None", Organizer = organizer}};
        //     //     
        //     //     Create(new Organizer{Name = "b@b.b", AgeEnabled = true, BirthEnabled = false, GenderEnabled = true, SkillsEnabled = false});
        //     // }
        // }
        public OrganizerRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}