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
        public string Name { get; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int GamesPlayed { get; private set; }
        public int CumulativeSouls;
        public double AverageSouls;
        private double winRate;
        public List<Character> charactersPlayed;

        // constructor for player with stats
        public Player(string playerName, int win = 0, int lose = 0)
        {
            Name = playerName;
            Wins = win;
            Losses = lose;
            GamesPlayed = win + lose;
        }
        // returns a list of players from file
        public static List<Player> LoadData()
        {
            // Creates a new player and adds it to players list for each name in the txt file
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Storage\Players.txt");
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
            // Creates every character object for each player
            foreach (var name in Character.characterNames)
            {
                charactersPlayed.Add(new Character(name));
            }
            Wins = games.Where(p => p.winner.Equals(this.Name)).Count();
            List<FourSoulsGame> gamesWithPlayer = games.Where(p => p.gameDataByPlayer.Any(n => n.playerName.Equals(this.Name))).ToList();
            
            // Totals a players souls across all games
            foreach (var game in gamesWithPlayer)
            {
                foreach (var gamedata in game.gameDataByPlayer)
                {
                    if (gamedata.playerName.Equals(this.Name))
                    {
                        CumulativeSouls += gamedata.souls;
                    }
                }
            }


            GamesPlayed = gamesWithPlayer.Count;
            Losses = GamesPlayed - Wins;
            if (GamesPlayed != 0)
            {
                AverageSouls = Math.Round((double)CumulativeSouls / (double)GamesPlayed, 2);
                winRate = Math.Round((double)Wins / (double)GamesPlayed, 2);
            }

            // Populates character stats for only with games that player is in
            foreach (var character in charactersPlayed)
            {
                character.CrunchNumbers(gamesWithPlayer, true, Name);
            }
        }

        // Prints the list of players and their statistics to file
        public static void PrintPlayers()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Storage\Players.txt");
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.WriteLine("name:wins:losses");
                foreach (var player in AllPlayers)
                {
                    output.WriteLine(player.ToString());
                }
            }
        }

        public static void AddPlayer(Player player)
        {
            AllPlayers.Add(player);
        }
        // overide of the ToString method
        public override string ToString()
        {
            string output = Name + ':' + Wins + ':' + Losses; // Need to update this with every field added
            return output;
        }
    }
}
