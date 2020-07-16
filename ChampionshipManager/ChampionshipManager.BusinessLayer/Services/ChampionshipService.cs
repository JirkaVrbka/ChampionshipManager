using System;
using System.Collections.Generic;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class ChampionshipService : AService<Championship>
    {
        public ChampionshipService(ASpecificEntityRepository<Championship> repository) : base(repository)
        {
        }

    }
}