using ChampionshipManager.Db;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public abstract class AService<TEntity> where TEntity : class, IEntity
    {
        protected ASpecificEntityRepository<TEntity> _repository;
        
        protected AService(ASpecificEntityRepository<TEntity> repository)
        {
            _repository = repository;
        }
    }
}