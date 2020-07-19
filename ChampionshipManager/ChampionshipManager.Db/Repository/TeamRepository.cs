using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;
using System.Linq;

namespace ChampionshipManager.Db.Repository
{
    public class TeamRepository : ASpecificEntityRepository<Team>
    {
        public override List<string> Includes { get; } = new List<string>
        {
            nameof(Team.Competitors),
            nameof(Team.Organizer)
        };

        public TeamRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}