using System;
using ChampionshipManager.Db.Context;

namespace ChampionshipManager.Db
{
    public interface IContextProvider : IDisposable
    {
        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        public ChampionshipManagerContext Create();

        /// <summary>
        /// Gets the unit of work in the current scope.
        /// </summary>
        public ChampionshipManagerContext GetUnitOfWorkInstance();
    }
}