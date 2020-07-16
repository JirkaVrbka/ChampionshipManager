using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class OrganizerService : AService<Organizer>
    {
        public OrganizerService(OrganizerRepository repository) : base(repository)
        {
        }
        
        public Guid GetIdByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName).ID;
        }
        
        public Organizer GetByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName);
        }

        public List<Championship> GetChampionshipsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string> {nameof(Organizer.Championships)})
                .Championships;
        }

        public List<Skill> GetSkillsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string> {nameof(Organizer.Skills)})
                .Skills;
        }

        public List<Competitor> GetCompetitorsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string> {nameof(Organizer.Competitors)})
                .Competitors;
        }

        public Championship GetChampionshipByNameWithIncludes(string organizerName, string championshipId)
        {
            return Guid.TryParse(championshipId, out Guid championshipGuid) ? 
                GetChampionshipByNameWithIncludes(organizerName, championshipGuid) : 
                null;
        }
        
        public Championship GetChampionshipByNameWithIncludes(string organizerName, Guid championshipId)
        {
            return _repository
                .Filter(o => o.Name == organizerName, new List<string>{nameof(Organizer.Championships)})
                .Single()
                .Championships
                .SingleOrDefault(c => c.ID == championshipId);
        }

        private Organizer GetByNameWithIncludes(string organizerName, List<string> includes = null)
        {
            return _repository.Filter(o => o.Name == organizerName, includes).Single();
        }
    }
}