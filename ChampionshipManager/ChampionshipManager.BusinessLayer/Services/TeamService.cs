using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class TeamService : AService<Team>
    {
        public TeamService(TeamRepository repository) : base(repository)
        {
        }
        
    }
}