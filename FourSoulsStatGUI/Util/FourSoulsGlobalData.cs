using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;
using FourSoulsCore;

namespace FourSoulsStatGUI
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
        public static ObservableCollection<Character> AllCharacters { get;  } 
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

                // update local objects
                AllGames = context.Games.ToObservableCollection();
                AllGameData = context.GameDatas.ToObservableCollection();
            }
        }
    }
}
