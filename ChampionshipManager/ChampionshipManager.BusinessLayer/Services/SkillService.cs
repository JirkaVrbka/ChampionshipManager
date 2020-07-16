using System;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class SkillService : AService<Skill>
    {
        public SkillService(SkillRepository repository) : base(repository)
        {
        }

        public Guid Create(Skill skill)
        {
            return _repository.Create(skill);
        }
    }
}