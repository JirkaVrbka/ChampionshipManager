using System.Collections.Generic;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Models;

namespace ChampionshipManager.Db.Repository
{
    public class SkillRepository: ASpecificEntityRepository<Skill>
    {
        public override List<string> Includes { get; } = new List<string>{ nameof(Skill.Organizer)};

        public SkillRepository(IContextProvider provider) : base(provider)
        {
        }
    }
}