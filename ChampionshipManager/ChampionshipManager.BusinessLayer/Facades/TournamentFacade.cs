using System;
using System.Collections.Generic;
using ChampionshipManager.BusinessLayer.Services;
using ChampionshipManager.Db.Models;
using ChampionshipManager.Db.Repository;

namespace ChampionshipManager.BusinessLayer.Facades
{
    public class TournamentFacade
    {
        // private readonly TournamentService _tournamentService;
        // private readonly GameService _gameService;
        //
        //
        // public TournamentFacade(TournamentService tournamentService, GameService gameService)
        // {
        //     _tournamentService = tournamentService;
        //     _gameService = gameService;
        // }
        //
        // public Guid CreateTournament(Tournament tournament)
        // {
        //     var id = _tournamentService.Create(tournament);
        //     var createdTournament = _tournamentService.GetById(id);
        //     
        //     var games = new List<Game>();
        //     switch (tournament.TournamentType)
        //     {
        //         case TournamentType.AgainstEverybody:
        //             games = CreateAgainstEverybodyGames(tournament);
        //             break;
        //         case TournamentType.Spider:
        //             games = CreateSpiderGames(tournament);
        //             break;
        //     }
        //
        //     foreach (var game in games)
        //     {
        //         _gameService.Create(game);
        //     }
        //
        //     return id;
        // }
        //
        // private List<Game> CreateAgainstEverybodyGames(Tournament tournament)
        // {
        //     List<Game> games = new List<Game>();
        //     var competitors = tournament.Competitors;
        //
        //     for (int i = 0; i < competitors.Count; i++)
        //     {
        //         for (int j = i+1; j < competitors.Count; j++)
        //         {
        //             games.Add(new Game
        //             {
        //                 Tournament = tournament,
        //                 PlayerOne = competitors[i],
        //                 PlayerTwo = competitors[j],
        //                 PlayerOneScore = 0,
        //                 PlayerTwoScore = 0
        //             });
        //         }
        //     }
        //
        //     return games;
        // }
        //
        // private List<Game> CreateSpiderGames(Tournament tournament)
        // { //TODO
        //     List<Game> games = new List<Game>();
        //
        //     for (int i = 0; i < tournament.Competitors.Count; i += 2)
        //     {
        //         var game = new Game
        //         {
        //             Tournament = tournament,
        //             PlayerOneScore = 0,
        //             PlayerTwoScore = 0,
        //             PlayerOne = tournament.Competitors[i],
        //             PlayerTwo = tournament.Competitors.Count > i + 1 ? 
        //                 tournament.Competitors[i + 1] :
        //                 null
        //         };
        //         
        //         games.Add(game);
        //     }
        //     
        //     return games;
        // }
    }
}