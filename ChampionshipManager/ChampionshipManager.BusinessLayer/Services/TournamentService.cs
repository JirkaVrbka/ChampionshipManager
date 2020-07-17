using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Services
{
    public class TournamentService : AService<Tournament>
    {
        public TournamentService(TournamentRepository repository) : base(repository)
        {
        }

        public override Guid Create(Tournament entity)
        {
            switch (entity.TournamentType)
            {
                case TournamentType.AgainstEverybody:
                    entity.Games = CreateAgainstEverybodyGames(entity);
                    break;
                case TournamentType.Spider:
                    entity.Games = CreateSpiderGames(entity);
                    break;
            }

            return base.Create(entity);
        }

        private List<Game> CreateAgainstEverybodyGames(Tournament tournament)
        {
            List<Game> games = new List<Game>();
            var competitors = tournament.Competitors;
 
            for (int i = 0; i < competitors.Count; i++)
            {
                for (int j = i+1; j < competitors.Count; j++)
                {
                    games.Add(new Game
                    {
                        PlayerOne = competitors[i],
                        PlayerTwo = competitors[j],
                        PlayerOneScore = 0,
                        PlayerTwoScore = 0,
                        Round = 0
                    });
                }
            }

            return games;
        }

        public void ProcessSpiderGames(ref Tournament tournament)
        {
            var tiers = tournament.Games.GroupBy(
                g => g.Round,
                g => g,
                (round, games) => new {round, games}).ToList();
            
            
            
            
        }
        
        private List<Game> CreateSpiderGames(Tournament tournament)
        { //TODO
            // Create spider bottom
            int tierZeroCount = (int) Math.Ceiling(Math.Log2(tournament.Competitors.Count));
            var tierZeroGames = new List<Game>();
            for (int i = 0; i < tierZeroCount; i++)
            {
                tierZeroGames.Add(
                    new Game
                    {
                        Tournament = tournament,
                        Round = 0
                    }
                    );
            }

            // Fill zero tier with players
            for (int i = 0; i < tournament.Competitors.Count; i++)
            {
                if (i < tierZeroCount)
                {
                    tierZeroGames[i].PlayerOne = tournament.Competitors[i];
                }
                else
                {
                    tierZeroGames[i % tierZeroCount].PlayerTwo = tournament.Competitors[i];
                }
            }

            var higherTierCount = tierZeroCount - 1;
            // Create higher tier games
            var higherTierGames = new List<Game>();
            for (int i = 0; i < higherTierCount; i++)
            {
                for (int j = 0; j < Math.Pow(2,i); j++)
                {
                    higherTierGames.Add(
                        new Game
                        {
                            Tournament = tournament,
                            Round = higherTierCount - i
                        }
                    );
                }
                
            }
            
            var result = new List<Game>(tierZeroGames);
            result.AddRange(higherTierGames);
            return result;
        }
    }
}