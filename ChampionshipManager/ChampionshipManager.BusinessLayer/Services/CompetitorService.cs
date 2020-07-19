using System;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class CompetitorService : AService<Competitor>
    {
        public CompetitorService(CompetitorRepository repository) : base(repository)
        {
        }
    }
}