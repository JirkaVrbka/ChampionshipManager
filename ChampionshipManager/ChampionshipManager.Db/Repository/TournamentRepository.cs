using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class TournamentRepository : ASpecificEntityRepository<Tournament>
    {
        protected override List<string> Includes { get; } = new List<string>
        {
            nameof(Tournament.Championship),
            nameof(Tournament.Competitors),
            nameof(Tournament.Games)
        };

        public TournamentRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}