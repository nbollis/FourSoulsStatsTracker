using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class FourSoulsGame
    {
        public static List<FourSoulsGame> AllGames { get; set; }
        public string Winner;
        public int NumberOfPlayers;
        private string DateOfEntry;
        public List<GameDataPerPlayer> GameDataPerPlayer { get; private set; }

        public FourSoulsGame(string date, List<GameDataPerPlayer> gameData)
        {
            
            GameDataPerPlayer = gameData.OrderByDescending(p => p.Souls).ToList();
            DateOfEntry = date;
            NumberOfPlayers = gameData.Count();
            Winner = GameDataPerPlayer.First().PlayerName;
        }

        // Loads in game data from file
        public static List<FourSoulsGame> LoadData()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Storage\Games.txt");
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
                                game.GameDataPerPlayer.Add(new GameDataPerPlayer(fields[9], fields[8], Int32.Parse(fields[10])));
                                game.NumberOfPlayers = 3;
                            }
                            else if (Int32.Parse(fields[0]) == 4)
                            {
                                game.GameDataPerPlayer.Add(new GameDataPerPlayer(fields[9], fields[8], Int32.Parse(fields[10])));
                                game.GameDataPerPlayer.Add(new GameDataPerPlayer(fields[12], fields[11], Int32.Parse(fields[13])));
                                game.NumberOfPlayers = 4;
                            }
                            game.GameDataPerPlayer.OrderByDescending(p => p.Souls).ToList();
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
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\AllGames.txt";
            JsonSerializerDeserializer.SerializeCollection(AllGames, filepath);
            //using (StreamWriter output = new StreamWriter(filepath))
            //{
            //    output.WriteLine("Players:Date:Character1:Player1:Souls1:Character2:Player2:Souls2:Character3:Player3:Souls3:Character4:Player4:Souls4");
            //    foreach (FourSoulsGame game in AllGames)
            //    {
            //        output.WriteLine(game.ToString());
            //    }
            //}
        }

        public override string ToString()
        {
            string output = NumberOfPlayers + ":" + DateOfEntry;
            foreach (var gameData in GameDataPerPlayer)
            {
                output += ":" + gameData.ToString();
            }
            return output;
        }

        public static void AddGame(FourSoulsGame game)
        {
            AllGames.Add(game);
        }

        public static string GetFolderPath(string folderName)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), folderName);
            return path;
        }
    }
}
