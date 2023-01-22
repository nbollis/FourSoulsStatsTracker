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
        public static ObservableCollection<Player> AllPlayers = SqlConnection.EfContext.Players.Local;
        public static ObservableCollection<Game> AllGames = SqlConnection.EfContext.Games.Local;
        public static ObservableCollection<Character> AllCharacters = SqlConnection.EfContext.Characters.Local;
        public static ObservableCollection<GameData> AllGameData = SqlConnection.EfContext.GameData.Local;
        public static ObservableCollection<string> AllPlayerNames =
            AllPlayers.Select(p => p.PlayerName).ToObservableCollection();

        public static void AddPlayer(string name) => SqlMethods.AddPlayer(name);
        public static void AddGame(Game game, IEnumerable<GameData> gameData) => SqlMethods.AddGame(game, gameData);
    }
}
