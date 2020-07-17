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

        public void ProcessSpiderGamesAndEdit(string id)
        {
            if (Guid.TryParse(id, out var guid))
            {
                Edit(ProcessSpiderGames(GetById(guid)));
            }
        }

        public Tournament ProcessSpiderGames(Tournament tournament)
        {
            //Default winners
            foreach (var game in tournament.Games.Where(g => g.Round == 0 && g.PlayerOne == null && g.PlayerTwo != null))
            {
                game.Winner = game.PlayerTwo;
                game.PlayerTwoScore = 1;
            }
            
            foreach (var game in tournament.Games.Where(g => g.Round == 0 && g.PlayerOne != null && g.PlayerTwo == null))
            {
                game.Winner = game.PlayerOne;
                game.PlayerOneScore = 1;
            }
            
            var tiers = tournament.Games.GroupBy(
                g => g.Round,
                g => g,
                (round, games) => new {round, games}).ToList();

            for (int i = 0; i < tiers.Count - 1; i++)
            {
                var tierI = tournament.Games.Where(g => g.Round == i).ToList();
                
                var tierIPlusOne = tournament.Games.Where(g => g.Round == i + 1).ToList();
                var tierIPlusOnePlayers = tierIPlusOne.FindAll(g => g.PlayerOne != null).Select(g => g.PlayerOne).ToList();
                tierIPlusOnePlayers.AddRange(tierIPlusOne.FindAll(g => g.PlayerTwo != null).Select(g => g.PlayerTwo));

                
                
                var unassigned = tierI.FindAll(g => 
                    (g.Winner != null && !tierIPlusOnePlayers.Contains(g.Winner))
                    ).Select(g => g.Winner).ToList();

                foreach (var unsign in unassigned)
                {
                    var tierUpGame = tournament.Games.FirstOrDefault(g => g.Round == i + 1 && g.PlayerOne == null);
                    if (tierUpGame != null)
                    {
                        tierUpGame.PlayerOne = unsign;
                    }
                    else
                    {
                        tournament.Games.Find(g => g.Round == i + 1 && g.PlayerTwo == null)!.PlayerTwo = unsign;
                    }
                }

            }

            return tournament;
        }
        
        private List<Game> CreateSpiderGames(Tournament tournament)
        { //TODO
            // Create spider bottom
            int tierZeroCount = HighestSmallerPowerOfTwo(tournament.Competitors.Count);
            var tierZeroGames = new List<Game>();
            for (int i = 0; i <= tierZeroCount; i++)
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
                if (i <= tierZeroCount)
                {
                    tierZeroGames[i].PlayerOne = tournament.Competitors[i];
                }
                else
                {
                    tierZeroGames[i % (tierZeroCount + 1)].PlayerTwo = tournament.Competitors[i];
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


        private int HighestSmallerPowerOfTwo(int limit)
        {
            double i = 1;
            while (((int) i^2) < limit)
            {
                i++;
            }

            return (int)i - 1;
        }
    }
    
}