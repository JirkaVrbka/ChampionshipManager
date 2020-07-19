using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class GameRepository : ASpecificEntityRepository<Game>
    {
        public override List<string> Includes { get; } = new List<string>
        {
            nameof(Game.Tournament)
        };
        
        public GameRepository(ChampionshipManagerContext context) : base(context)
        {
        }
    }
}