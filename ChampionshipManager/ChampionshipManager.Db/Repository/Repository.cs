using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChampionshipManager.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipManager.Db.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected ChampionshipManagerContext Context => _provider.GetUnitOfWorkInstance();

        private readonly IContextProvider _provider;

        public Repository(IContextProvider provider) => _provider = provider;

        public Guid Create(TEntity entity)
        {
            var createdEntity = Context.Set<TEntity>().Add(entity);
            SaveChanges();
            return createdEntity.Entity.ID;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entityToDelete = Context.Set<TEntity>().FirstOrDefault(e => e.ID == id);
            if (entityToDelete != null)
            {
                Context.Set<TEntity>().Remove(entityToDelete);
                SaveChanges();
            }
        }

        public void Edit(TEntity entity)
        {
            var editedEntity = Context.Set<TEntity>().FirstOrDefault(e => e.ID == entity.ID);
            editedEntity = entity;
            SaveChanges();
        }

        public async Task EditAsync(TEntity entity)
        {
            var editedEntity = Context.Set<TEntity>().FirstOrDefault(e => e.ID == entity.ID);
            editedEntity = entity;
            await SaveChangesAsync();
        }

        public TEntity GetById(Guid id)
        {
            return Context.Set<TEntity>().FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<TEntity> Filter(IList<string> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, IList<string> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.AsEnumerable().Where(predicate);
        }

        public void SaveChanges() => Context.SaveChanges();
        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}