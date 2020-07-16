using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class OrganizerService : AService<Organizer>
    {
        public OrganizerService(ASpecificEntityRepository<Organizer> repository) : base(repository)
        {
        }
        
        public Guid GetIdByName(string organizerName)
        {
            return _repository.Filter(o => o.Name == organizerName).Single().ID;
        }

        public List<Championship> GetChampionships(Guid organizerId)
        {
            return _repository.GetById(organizerId).Championships;
        }

        public Championship GetChampionshipWithIncludes(string organizerName, string championshipId)
        {
            if (Guid.TryParse(championshipId, out Guid championshipGuid))
            {
                return GetChampionshipWithIncludes(organizerName, championshipGuid);
            }

            return null;
        }
        
        public Championship GetChampionshipWithIncludes(string organizerName, Guid championshipId)
        {
            return _repository
                .Filter(o => o.Name == organizerName, new List<string>{nameof(Organizer.Championships)})
                .Single()
                .Championships
                .SingleOrDefault(c => c.ID == championshipId);
        }
    }
}