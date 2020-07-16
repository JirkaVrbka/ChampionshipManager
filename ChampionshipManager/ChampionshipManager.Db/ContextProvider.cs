using System;
using System.Threading;
using ChampionshipManager.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipManager.Db
{
    public class ContextProvider : IContextProvider
    {
        protected readonly AsyncLocal<ChampionshipManagerContext> UowLocalInstance
            = new AsyncLocal<ChampionshipManagerContext>();

        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        public ChampionshipManagerContext Create()
        {
            var optionBuilder = new DbContextOptionsBuilder<ChampionshipManagerContext>();
            optionBuilder.UseSqlite("Filename=./manager.db");
            UowLocalInstance.Value = new ChampionshipManagerContext(
                optionBuilder.Options
            );

            return UowLocalInstance.Value;
        }

        /// <summary>
        /// Gets the unit of work in the current scope.
        /// </summary>
        public ChampionshipManagerContext GetUnitOfWorkInstance()
        {
            return UowLocalInstance != null ? UowLocalInstance.Value : throw new InvalidOperationException("Context not created");
        }

        public void Dispose()
        {
            UowLocalInstance.Value?.Dispose();
            UowLocalInstance.Value = null;
        }
    }
}