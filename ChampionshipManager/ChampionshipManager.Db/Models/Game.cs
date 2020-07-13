using System;

namespace ChampionshipManager.Db.Models
{
    public class Game : IEntity
    {
        public Guid ID { get; set; }

        public Competitor PlayerOne { get; set; }
        public int PlayerOneScore { get; set; }
        public Competitor PlayerTwo { get; set; }
        public int PlayerTwoScore { get; set; }

        public Winner Winner { get; set; }
    }

    public enum Winner
    {
        PlayerOne,
        PlayerTwo
    }
}