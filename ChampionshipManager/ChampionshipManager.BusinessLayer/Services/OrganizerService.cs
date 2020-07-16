using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class OrganizerService : AService<Organizer>
    {
        public OrganizerService() : base((provider) => new OrganizerRepository(provider))
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
        
        public Organizer GetWithCompetitorsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string>{nameof(Organizer.Competitors)});
        }
        
        public Organizer GetWithSkillsTeamsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string>{nameof(Organizer.Skills), nameof(Organizer.Teams)});
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
        

        public Skill GetSkillByNameOrDefault(string organizerName, string skillId)
        {
            Skill result = null;
            var skills = GetSkillsByName(organizerName);
            if (Guid.TryParse(skillId, out var skillGuid))
            {
                result = skills.SingleOrDefault(s => s.ID == skillGuid);
            }

            return result ?? skills.Single(s => s.Name == "None");
        }
        
        public List<Team> GetTeamsByName(string organizerName)
        {
            return GetByNameWithIncludes(organizerName, new List<string> {nameof(Organizer.Teams)})
                .Teams;
        }

        public Team GetTeamByNameOrDefault(string organizerName, string teamId)
        {
            Team result = null;
            var teams = GetTeamsByName(organizerName);
            if (Guid.TryParse(teamId, out var teamGuid))
            {
                result = teams.SingleOrDefault(s => s.ID == teamGuid);
            }

            return result ?? teams.Single(s => s.Name == "None");
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
            return Repository
                .Filter(o => o.Name == organizerName, new List<string>{nameof(Organizer.Championships)})
                .Single()
                .Championships
                .SingleOrDefault(c => c.ID == championshipId);
        }

        private Organizer GetByNameWithIncludes(string organizerName, List<string> includes = null)
        {
            using (ContextProvider.Create())
            {
                return Repository.Filter(o => o.Name == organizerName, includes).Single();
            }
        }

        public bool ExistOrganizerByName(string organizerName)
        {
            using (ContextProvider.Create())
            {
                return Repository.Filter(o => o.Name == organizerName, null).Any();
            }
        }

        public async Task EditAsync(Organizer entity)
        {
            await using (ContextProvider.Create())
            {
                await Repository.EditAsync(entity);
            }
        }
    }
}