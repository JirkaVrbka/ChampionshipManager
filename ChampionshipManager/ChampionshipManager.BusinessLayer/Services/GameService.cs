using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class GameService : AService<Game>
    {
        public GameService(GameRepository repository) : base(repository)
        {
        }

        public List<Game> GetByTournamentIdWithIncludes(string tournamentId)
        {
            return Guid.TryParse(tournamentId, out var tournamentGuid)
                ? Repository.FilterWithIncludes(g => g.Tournament.ID == tournamentGuid).ToList()
                : new List<Game>();
        }
    }
}