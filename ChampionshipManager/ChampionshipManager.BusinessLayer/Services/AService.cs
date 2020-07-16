using System;
using System.Linq;
using ChampionshipManager.Db;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public abstract class AService<TEntity> where TEntity : class, IEntity 
    {
        protected readonly ASpecificEntityRepository<TEntity> Repository;
        protected readonly ContextProvider ContextProvider = new ContextProvider();
        
        protected AService(Func<IContextProvider ,ASpecificEntityRepository<TEntity>> repositoryProvider)
        {
            Repository = repositoryProvider.Invoke(ContextProvider);
        }

        public virtual TEntity GetById(Guid id)
        {
            using (ContextProvider.Create())
            {
                return Repository.GetById(id);
            }
        }
        
        public virtual TEntity GetById(string id)
        {
            using (ContextProvider.Create())
            {
                return Guid.TryParse(id, out var guid) ? Repository.GetById(guid) : null;
            }
        }
        
        public virtual Guid Create(TEntity entity)
        {
            using (ContextProvider.Create())
            {
                return Repository.Create(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (ContextProvider.Create())
            {
                Repository.Delete(entity);
            }
        }

        public virtual void Delete(Guid id)
        {
            using (ContextProvider.Create())
            {
                Repository.Delete(id);
            }
        }

        public virtual void Edit(TEntity entity)
        {
            using (ContextProvider.Create())
            {
                Repository.Edit(entity);
            }
        }
        
        public virtual TEntity GetWithAllIncludes(Guid id)
        {
            using (ContextProvider.Create())
            {
                return Repository.FilterWithIncludes(c => c.ID == id).Single();
            }
        }
        
        public virtual TEntity GetWithAllIncludes(string id)
        {
            using (ContextProvider.Create())
            {
                return Guid.TryParse(id, out var guid)
                    ? GetWithAllIncludes(guid)
                    : null;
            }
        }
    }
}