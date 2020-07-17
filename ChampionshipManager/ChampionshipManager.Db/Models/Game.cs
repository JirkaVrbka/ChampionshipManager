using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampionshipManager.Db.Models
{
    public class Game : IEntity
    {
        public Guid ID { get; set; }

        public Competitor PlayerOne { get; set; }
        public int PlayerOneScore { get; set; }
        
        public Competitor PlayerTwo { get; set; }
        public int PlayerTwoScore { get; set; }

        public int Round { get; set; }

        public Competitor Winner { get; set; }

        public Tournament Tournament { get; set; }
    }
}