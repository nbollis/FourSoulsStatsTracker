using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class FourSoulsGame
    {
        public static List<FourSoulsGame> AllGames { get; set; }
        public string winner;
        public int numberOfPlayers;
        private string dateOfGame;
        public List<GameDataPerPlayer> gameDataByPlayer { get; private set; }

        public FourSoulsGame(string date, List<GameDataPerPlayer> gameData)
        {
            
            gameDataByPlayer = gameData.OrderByDescending(p => p.souls).ToList();
            dateOfGame = date;
            numberOfPlayers = gameData.Count();
            winner = gameDataByPlayer.First().playerName;
        }

        // Loads in game data from file
        public static List<FourSoulsGame> LoadData()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Games.txt";
            int players;
            string[] fields;
            string line = "";
            AllGames = new();
            using (StreamReader input = new StreamReader(filepath))
            {
                try
                {
                    players = (int)input.Read();
                    line = input.ReadLine();
                    while (line != null)
                    {
                        line = input.ReadLine();
                        if (line != null && !line.Contains("Date"))
                        {
                            line = line.ToString();
                            fields = line.Split(':');
                            FourSoulsGame game = new(fields[1], new List<GameDataPerPlayer>() {
                                new GameDataPerPlayer(fields[3], fields[2], Int32.Parse(fields[4])), 
                                new GameDataPerPlayer(fields[6], fields[5], Int32.Parse(fields[7]))} );
                            if (Int32.Parse(fields[0]) == 3)
                            {
                                game.gameDataByPlayer.Add(new GameDataPerPlayer(fields[9], fields[8], Int32.Parse(fields[10])));
                                game.numberOfPlayers = 3;
                            }
                            else if (Int32.Parse(fields[0]) == 4)
                            {
                                game.gameDataByPlayer.Add(new GameDataPerPlayer(fields[9], fields[8], Int32.Parse(fields[10])));
                                game.gameDataByPlayer.Add(new GameDataPerPlayer(fields[12], fields[11], Int32.Parse(fields[13])));
                                game.numberOfPlayers = 4;
                            }
                            game.gameDataByPlayer.OrderByDescending(p => p.souls).ToList();
                            AllGames.Add(game);
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
            return AllGames;
        }

        public static void PrintGames()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Games.txt";
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.WriteLine("Players:Date:Character1:Player1:Souls1:Character2:Player2:Souls2:Character3:Player3:Souls3:Character4:Player4:Souls4");
                foreach (FourSoulsGame game in AllGames)
                {
                    output.WriteLine(game.ToString());
                }
            }
        }

        public override string ToString()
        {
            string output = numberOfPlayers + ":" + dateOfGame;
            foreach (var gameData in gameDataByPlayer)
            {
                output += ":" + gameData.ToString();
            }
            return output;
        }

        public static void AddGame(FourSoulsGame game)
        {
            AllGames.Add(game);
        }
    }
}
