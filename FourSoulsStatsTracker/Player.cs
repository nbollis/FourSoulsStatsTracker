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
        public static List<Player> AllPlayers;
        private string name { get; }
        public int wins { get; private set; }
        public int losses { get; private set; }
        public int gamesPlayed { get; private set; }
        public int cumulativeSouls { get; }
        private float winRate;
        public List<Character> charactersPlayed;

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
            // Creates a new player and adds it to players list for each name in the txt file
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Players.txt";
            string[] fields;
            string line = "";
            AllPlayers = new();
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
                            Player player = new Player(fields[0]);
                            AllPlayers.Add(player);
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

            foreach (var player in AllPlayers)
            {
                player.charactersPlayed = new();
                player.CrunchNumbers();
            }
            return AllPlayers;
        }

        // Calculates the wins and losses of each player and initializes the characters inside of each player object
        public void CrunchNumbers()
        {
            foreach (var name in Character.characterNames)
            {
                charactersPlayed.Add(new Character(name));
            }
            List<FourSoulsGame> gamesWithPlayer = games.Where(p => p.gameDataByPlayer.Any(n => n.playerName.Equals(this.name))).ToList();
            gamesPlayed = gamesWithPlayer.Count;
            wins = games.Where(p => p.winner.Equals(this.name)).Count();
            losses = gamesPlayed - wins;
            winRate = wins / gamesPlayed;
            foreach (var character in charactersPlayed)
            {
                character.CrunchNumbers(gamesWithPlayer);
            }
        }

        // Prints the list of players and their statistics to file
        public static void PrintPlayers()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Players.txt";
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.WriteLine("name:wins:losses");
                foreach (var player in AllPlayers)
                {
                    output.WriteLine(player.ToString());
                }
            }
        }

        public void OnNewPlayerAdded(object sender, EventArgs e)
        {
            Console.WriteLine("It Worked!");
        }
        // overide of the ToString method
        public override string ToString()
        {
            string output = name + ':' + wins + ':' + losses; // Need to update this with every field added
            return output;
        }
    }
}
