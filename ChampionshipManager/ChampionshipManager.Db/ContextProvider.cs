using System;
using System.Threading;
using ChampionshipManager.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ChampionshipManager.Db
{
    public class ContextProvider : IContextProvider
    {
        public static readonly ILoggerFactory DbCommandConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected static ChampionshipManagerContext UowLocalInstance = null;

        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        public ChampionshipManagerContext Create()
        {
            var optionBuilder = new DbContextOptionsBuilder<ChampionshipManagerContext>();
            optionBuilder.UseSqlite("Filename=./manager.db");
            optionBuilder.UseLoggerFactory(DbCommandConsoleLoggerFactory);
            optionBuilder.EnableSensitiveDataLogging();

            UowLocalInstance = new ChampionshipManagerContext(
                optionBuilder.Options
            );

            return UowLocalInstance;
        }

        /// <summary>
        /// Gets the unit of work in the current scope.
        /// </summary>
        public ChampionshipManagerContext GetUnitOfWorkInstance()
        {
            return UowLocalInstance != null
                ? UowLocalInstance
                : throw new InvalidOperationException("Context not created");
        }

        public void Dispose()
        {
            UowLocalInstance?.Dispose();
            UowLocalInstance = null;
        }
    }
}