using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class CompetitorRepository : ASpecificEntityRepository<Competitor>
    {
        public override List<string> Includes { get; } = new List<string>
        {
            nameof(Competitor.Skill),
            nameof(Competitor.Organizer),
            nameof(Competitor.Team)
        };

        public CompetitorRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}