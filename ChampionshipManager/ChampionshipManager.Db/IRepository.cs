using System;
using System.Collections.Generic;

namespace ChampionshipManager.Db
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Guid id);
        void Edit(TEntity entity);

        //read side (could be in separate Readonly Generic Repository)
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Filter(IList<string> includes = null);
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, IList<string> includes = null);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        void SaveChanges();
    }
}