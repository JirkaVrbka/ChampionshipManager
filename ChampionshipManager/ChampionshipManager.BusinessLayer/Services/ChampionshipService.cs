using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class ChampionshipService : AService<Championship>
    {
        public ChampionshipService() : base((provider) => new ChampionshipRepository(provider))
        {
        }
        
        public Championship GetWithCompetitors(Guid championshipId)
        {
            return GetWithIncludes(championshipId, new List<string>{nameof(Championship.Competitors)});
        }
        
        public Championship GetWithCompetitors(string championshipId)
        {
            return Guid.TryParse(championshipId, out var championshipGuid) 
                ? GetWithCompetitors(championshipGuid) 
                : null;
        }
        
        private Championship GetWithIncludes(Guid championshipId, List<string> includes = null)
        {
            using (ContextProvider.Create())
            {
                return Repository.Filter(c => c.ID == championshipId, includes).Single();
            }
        }

    }
}