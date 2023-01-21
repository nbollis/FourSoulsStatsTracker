using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public static class FourSoulsGlobalData
    {
        private static string gamesPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataHandling\Data\AllGames.txt");

        private static string charactersPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataHandling\Data\AllCharacters.txt");

        private static string playersPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataHandling\Data\AllPlayers.txt");

        private static string playerNamesPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataHandling\Data\AllPlayerNames.txt");

        // TODO: Eliminate player names from being a separate thing saved.
        // Have it just export all the players, and when a new player is
        // created from the gui, it creates a new player object instead

        public static List<Game> AllGames { get; set; }
        public static List<Character> AllCharacters { get; set; }
        public static List<Player> AllPlayers { get; set; }

        public static List<string> AllCharacterNames => AllCharacters.Select(p => p.Name).ToList();
        public static List<string> AllPlayerNames { get; private set; }

        static FourSoulsGlobalData()
        {
            LoadAllData();
        }

        public static void LoadAllData() 
        {
           AllPlayerNames = JsonSerializerDeserializer.DeserializeCollection<string>(playerNamesPath).ToList();
           AllGames = JsonSerializerDeserializer.DeserializeCollection<Game>(gamesPath).ToList();
           AllCharacters = JsonSerializerDeserializer.DeserializeCollection<Character>(charactersPath).ToList();
           AllPlayers = JsonSerializerDeserializer.DeserializeCollection<Player>(playersPath).ToList();
            foreach (var game in AllGames)
            {
                AssignGameStats(game);
            }
        }

        public static void SaveAllData()
        {
           JsonSerializerDeserializer.SerializeCollection(AllGames, gamesPath);
           JsonSerializerDeserializer.SerializeCollection(AllCharacters, charactersPath);
           JsonSerializerDeserializer.SerializeCollection(AllPlayers, playersPath);
           JsonSerializerDeserializer.SerializeCollection(AllPlayerNames, playerNamesPath);
        }

        /// <summary>
        /// Adds a new player to the global data
        /// </summary>
        /// <param name="playerName"></param>
        public static void AddPlayer(string playerName)
        {
            AllPlayerNames.Add(playerName);
            var newPlayer = new Player(playerName);
            AllPlayers.Add(newPlayer);
            JsonSerializerDeserializer.SerializeAndAppend(playerName, playerNamesPath);
            JsonSerializerDeserializer.SerializeAndAppend(newPlayer, playersPath);
        }

        public static void AddGame(Game game)
       {
            AllGames.Add(game);
            JsonSerializerDeserializer.SerializeAndAppend(game, gamesPath);
            AssignGameStats(game);
       }

        public static void AssignGameStats(Game game)
        {
            var metadata = game.GameData;
            var gameDataPerPlayers =
                (from DataRow row in metadata.Rows select new GameDataPerPlayer(row)).ToList();

            var playersInGame = 
                gameDataPerPlayers.Select(p => AllPlayers.First(m => m.Name.Equals(p.PlayerName))).ToList();
            var charactersInGame = gameDataPerPlayers.Select(p => AllCharacters.First(m =>
                    p.CharacterPlayed != null && m.CharacterName == Enum.Parse<CharacterNames>(p.CharacterPlayed)))
                .ToList();

            playersInGame.ForEach(p => p.ParseDataFromGame(game));
            charactersInGame.ForEach(p => p.ParseDataFromGame(game));

        }
    }
}
