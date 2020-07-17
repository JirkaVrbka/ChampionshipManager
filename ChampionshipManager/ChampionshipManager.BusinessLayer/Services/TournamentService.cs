using System;
using System.Collections.Generic;
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
                        PlayerTwoScore = 0
                    });
                }
            }

            return games;
        }
        
        private List<Game> CreateSpiderGames(Tournament tournament)
        { //TODO
            List<Game> games = new List<Game>();

            for (int i = 0; i < tournament.Competitors.Count; i += 2)
            {
                var game = new Game
                {
                    Tournament = tournament,
                    PlayerOneScore = 0,
                    PlayerTwoScore = 0,
                    PlayerOne = tournament.Competitors[i],
                    PlayerTwo = tournament.Competitors.Count > i + 1 ? 
                        tournament.Competitors[i + 1] :
                        null
                };
                
                games.Add(game);
            }
            
            return games;
        }
    }
}