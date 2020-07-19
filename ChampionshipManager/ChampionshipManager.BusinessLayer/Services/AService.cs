using System;
using System.Linq;
using System.Threading.Tasks;
using ChampionshipManager.Db;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public abstract class AService<TEntity> where TEntity : class, IEntity
    {
        protected readonly ASpecificEntityRepository<TEntity> Repository;

        protected AService(ASpecificEntityRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public virtual TEntity GetById(string id)
        {
            return Guid.TryParse(id, out var guid) ? GetById(guid) : null;
        }

        public virtual async Task<Guid> Create(TEntity entity)
        {
            return await Repository.Create(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            await Repository.Delete(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            await Repository.Delete(id);
        }

        public virtual async Task<TEntity> Edit(TEntity entity)
        {
            return await Repository.Edit(entity);
        }

        public virtual TEntity GetWithAllIncludes(Guid id)
        {
            return Repository.FilterWithIncludes(c => c.ID == id).Single();
        }

        public virtual TEntity GetWithAllIncludes(string id)
        {
            return Guid.TryParse(id, out var guid)
                ? GetWithAllIncludes(guid)
                : null;
        }
    }
}