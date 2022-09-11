using System;
using System.Collections.Generic;
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

       public static List<Game> AllGames { get; set; }
       public static List<Character> AllCharacters { get; set; }
       public static List<Player> AllPlayers { get; set; }
       public static List<string> AllPlayerNames { get; set; }

       static FourSoulsGlobalData()
       {
           LoadAllData();
       }

       private static void LoadAllData()
       {
           AllGames = JsonSerializerDeserializer.DeserializeCollection<Game>(gamesPath).ToList();
           AllCharacters = JsonSerializerDeserializer.DeserializeCollection<Character>(charactersPath).ToList();
           AllPlayers = JsonSerializerDeserializer.DeserializeCollection<Player>(playersPath).ToList();
           AllPlayerNames = JsonSerializerDeserializer.DeserializeCollection<string>(playerNamesPath).ToList();
       }

       public static void SaveAllData()
       {
           JsonSerializerDeserializer.SerializeCollection(AllGames, gamesPath);
           JsonSerializerDeserializer.SerializeCollection(AllCharacters, charactersPath);
           JsonSerializerDeserializer.SerializeCollection(AllPlayers, playersPath);
           JsonSerializerDeserializer.SerializeCollection(AllPlayerNames, playerNamesPath);
       }

       public static void AddPlayerName(string playerName)
       {
            AllPlayerNames.Add(playerName);
            JsonSerializerDeserializer.SerializeAndAppend(playerName, playerNamesPath);
       }

       public static void AddGame(Game game)
       {
            AllGames.Add(game);
            JsonSerializerDeserializer.SerializeAndAppend(game, gamesPath);
       }
    }
}
