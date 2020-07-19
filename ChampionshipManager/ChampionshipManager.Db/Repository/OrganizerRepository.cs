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

        public OrganizerRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}