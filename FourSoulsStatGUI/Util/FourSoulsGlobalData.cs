using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;
using FourSoulsData;

namespace FourSoulsStatGUI
{
    public static class FourSoulsGlobalData
    {
        static FourSoulsGlobalData()
        {
            AllPlayers = SqlConnection.EfContext.Players.Local;
            AllGames = SqlConnection.EfContext.Games.Local;
            AllCharacters = SqlConnection.EfContext.Characters.Local;
            AllGameData = SqlConnection.EfContext.GameData.Local;
        }


        public static ObservableCollection<Player> AllPlayers { get; } 
        public static ObservableCollection<Game> AllGames { get; }
        public static ObservableCollection<Character> AllCharacters { get; } 
        public static ObservableCollection<GameData> AllGameData { get; }

        public static ObservableCollection<string> AllPlayerNames =>
            AllPlayers.Select(p => p.PlayerName).ToObservableCollection();

        public static ObservableCollection<string> AllCharacterNames =>
            AllCharacters.Select(p => p.CharacterName).ToObservableCollection();



        public static void AddPlayer(string name) => SqlMethods.AddPlayer(name);
        public static void AddGame(Game game, IEnumerable<GameData> gameData) => SqlMethods.AddGame(game, gameData);
        public static void UpdatePlayerNames() => SqlConnection.UpdateNameKeyDictionary();
    }
}
