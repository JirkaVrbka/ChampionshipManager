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

        public Championship GetWithIncludes(Guid championshipId)
        {
            return _repository.FilterWithIncludes(c => c.ID == championshipId).Single();
        }
        
        public Championship GetWithIncludes(string championshipId)
        {
            return Guid.TryParse(championshipId, out var championshipGuid) 
                ? GetWithIncludes(championshipGuid) 
                : null;
        }

        public Guid Create(Championship championship)
        {
            return _repository.Create(championship);
        }

    }
}