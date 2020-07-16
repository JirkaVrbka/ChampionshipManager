using System;
using System.Collections.Generic;
using ChampionshipManager.Db.Context;

namespace ChampionshipManager.Db.Repository
{
    public abstract class ASpecificEntityRepository<TEntity> : Repository<TEntity>
        where TEntity : class, IEntity
    {
        public abstract List<string> Includes { get; }

        protected ASpecificEntityRepository(ChampionshipManagerContext context) : base(context)
        {
        }
        
        public IEnumerable<TEntity> FilterWithIncludes()
        {
            return base.Filter(Includes);
        }

        public IEnumerable<TEntity> FilterWithIncludes(Func<TEntity, bool> predicate)
        {
            return base.Filter(predicate, Includes);
        }
    }
}