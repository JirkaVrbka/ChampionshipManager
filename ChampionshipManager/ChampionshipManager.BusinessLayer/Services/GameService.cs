using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class GameService : AService<Game>
    {
        public GameService() : base((provider) => new GameRepository(provider))
        {
        }
    }
}