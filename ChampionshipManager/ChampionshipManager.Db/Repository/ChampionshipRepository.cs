using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class ChampionshipRepository : ASpecificEntityRepository<Championship>
    {
        protected override List<string> Includes { get; } = new List<string>
            {nameof(Championship.Organizer), nameof(Championship.Tournaments), nameof(Championship.Competitors)};

        public ChampionshipRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}