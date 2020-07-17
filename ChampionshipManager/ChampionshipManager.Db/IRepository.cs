using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChampionshipManager.Db
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
         Guid Create(TEntity entity);
         void Delete(TEntity entity);
         void Delete(Guid id);
         void Edit(TEntity entity);

        //read side (could be in separate Readonly Generic Repository)
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Filter(IList<string> includes = null);
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, IList<string> includes = null);

    }
}