using System;
using System.Collections.Generic;
using System.Linq;
using ChampionshipManager.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipManager.Db.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ChampionshipManagerContext _context;

        public Repository(ChampionshipManagerContext context) => _context = context;

        public Guid Create(TEntity entity)
        {
            var createdEntity = _context.Set<TEntity>().Add(entity);
            SaveChanges();
            return createdEntity.Entity.ID;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.ID == id);
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
                SaveChanges();
            }
        }

        public void Edit(TEntity entity)
        {
            var editedEntity = _context.Set<TEntity>().FirstOrDefault(e => e.ID == entity.ID);
            editedEntity = entity;
            SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<TEntity> Filter(IList<string> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

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
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.AsEnumerable().Where(predicate);
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}