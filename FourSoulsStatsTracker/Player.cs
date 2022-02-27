using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Player : Engine
    {
        private string name { get; }
        public int wins { get; private set; }
        private int losses { get; }
        public int gamesPlayed { get; private set; }
        public int cumulativeSouls { get; }
        private float winRate;
        

        //constructor for simple players with only the name field initialized
        Player(string playerName)
        {
            name = playerName;
        }

        // constructor for player with stats
        Player(string playerName, int win = 0, int lose = 0)
        {
            name = playerName;
            wins = win;
            losses = lose;
            gamesPlayed = win + lose;
        }
        // returns a list of players from file
        public static List<Player> LoadData()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Players.txt";
            string[] fields;
            string line = "";
            List<Player> players = new();
            using (StreamReader input = new StreamReader(filepath))
            {
                try
                {
                    while (line != null)
                    {
                        line = input.ReadLine();
                        if (line != null && !line.Contains("name"))
                        {
                            line = line.ToString();
                            fields = line.Split(':');
                            Player player = new Player(fields[0], Int32.Parse(fields[1]), Int32.Parse(fields[2])); // Need to update this with every field added
                            player.UpdateStats();
                            players.Add(player);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (input != null)
                        input.Close();
                }
            }
            return players;
        }

        // recalculates the statistics of a player
        public void UpdateStats()
        {
            gamesPlayed = wins + losses;
            winRate = wins / gamesPlayed;
            double tacos = winRate;
        }

        // returns a list of playernames from file
        public List<string> LoadNameData()
        {
            //TODO load name data from file
            List<Player> players = new() { new Player("Nic", 3, 0), new Player("Nico", 2, 3), new Player("Jamir", 1, 5) };
            List<string> playerNames = new();
            foreach (var player in players)
            {
                playerNames.Add(player.name);
            }
            return playerNames;
        }
        // Prints the list of players and their statistics to file
        public static void PrintPlayers(List<Player> players)
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Players.txt";
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.WriteLine("name:wins:losses");
                foreach (var player in players)
                {
                    output.WriteLine(player.ToString());
                }
            }
        }
        // overide of the ToString method
        public override string ToString()
        {
            string output = name + ':' + wins + ':' + losses; // Need to update this with every field added
            return output;
        }

        // Adds players names to the playerNames list if not on there already
        public static void ParsePlayersFromGames(List<Game> games)
        {
            foreach (var game in games)
            {
                foreach (var gameData in game.gameDataByPlayer)
                {
                    if (!playerNames.Contains(gameData.playerName))
                        AddPlayer(gameData.playerName);
                }
            }
        }
        // Updates the stats of a player taking into account the newest games
        public static void ParseStatsFromGames(List<Game> games)
        {
            //TODO parse stats from a list of games
        }
        // Adds a players name to the static list playerNames
        public static void AddPlayer(string name)
        {
            playerNames.Add(name);
        }
        // Returns playerNames list
        public static List<string> GetPlayerList()
        {
            List<string> names = new();
            foreach (var player in players)
            {
                names.Add(player.name);
            }
            return names;
        }
        // Returns a string representation of a players name
        public string GetPlayerName()
        {
            return this.name;
        }
    }
}
