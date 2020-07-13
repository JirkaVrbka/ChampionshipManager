using System;

namespace ChampionshipManager.Db
{
    public interface IEntity
    {
        Guid ID { get; set; }
    }
}