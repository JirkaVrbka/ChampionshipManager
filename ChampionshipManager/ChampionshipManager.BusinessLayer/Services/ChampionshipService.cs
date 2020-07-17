using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class ChampionshipService : AService<Championship>
    {
        public ChampionshipService(ChampionshipRepository repository) : base(repository)
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

        public List<Competitor> GetCompetitors(string championshipId)
        {
            return GetWithCompetitors(championshipId).Competitors;
        }
        
        public List<Competitor> GetCompetitors(Guid championshipId)
        {
            return GetWithIncludes(championshipId, new List<string>{nameof(Championship.Competitors)}).Competitors;
        }
        
        private Championship GetWithIncludes(Guid championshipId, List<string> includes = null)
        {
                return Repository.Filter(c => c.ID == championshipId, includes).Single();
            
        }

    }
}