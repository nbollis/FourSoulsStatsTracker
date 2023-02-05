using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;

namespace FourSoulsDataConnection
{
    public static class FourSoulsGlobalData
    {
        static FourSoulsGlobalData()
        {

            using (var context = new FourSoulsStatsContext())
            {
                AllPlayers = context.Players.ToObservableCollection();
                AllGames = context.Games.ToObservableCollection();
                AllCharacters = context.Characters.ToObservableCollection();
                AllGameData = context.GameDatas.ToObservableCollection();
            }
        }

        public static ObservableCollection<Player> AllPlayers { get; private set; } 
        public static ObservableCollection<Game> AllGames { get; private set; }
        public static ObservableCollection<Character> AllCharacters { get; private set; } 
        public static ObservableCollection<GameData> AllGameData { get; private set; }

        public static ObservableCollection<string> AllPlayerNames =>
            AllPlayers.Select(p => p.PlayerName).ToObservableCollection();

        public static ObservableCollection<string> AllCharacterNames =>
            AllCharacters.Select(p => p.CharacterName).ToObservableCollection();



        public static void AddPlayer(string name)
        {
            using (var context = new FourSoulsStatsContext())
            {
                // save player
                var player = new Player
                {
                    PlayerName = name,
                };
                context.Players.Add(player);
                context.SaveChanges();

                // update local
                AllPlayers = context.Players.ToObservableCollection();
            }
        } 

        public static void AddGame(Game game)
        {
            using (var context = new FourSoulsStatsContext())
            {
                // save game
                game.NumberOfPlayers = game.GameDatas.Count;
                context.Games.Add(game);
                context.SaveChanges();

                // update local representation of characters and players
                AllPlayers = context.Players.ToObservableCollection();
                AllCharacters = context.Characters.ToObservableCollection();
                AllGames.Add(game);
                foreach (var gameGameData in game.GameDatas)
                {
                    AllGameData.Add(gameGameData);
                }
            }
        }

        public static Game CreateNewGame()
        {
            Game game;
            using (var context = new FourSoulsStatsContext())
            {
                game = context.Games.Create();
                game.GameId = AllGames.Max(p => p.GameId) + 1;

                for (int i = 0; i < 4; i++)
                {
                    GameData data = context.GameDatas.Create();
                    data.Game = game;
                    game.GameDatas.Add(data);
                }
            }

            return game;
        }
    }
}
