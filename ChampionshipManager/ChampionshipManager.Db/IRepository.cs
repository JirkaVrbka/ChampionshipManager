using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChampionshipManager.Db
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<Guid> Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> Edit(TEntity entity);

        //read side (could be in separate Readonly Generic Repository)
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Filter(IList<string> includes = null);
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, IList<string> includes = null);
    }
}