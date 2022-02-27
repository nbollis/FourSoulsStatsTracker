using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Game : Engine
    {

        private int numberOfPlayers;
        private string dateOfGame;
        public List<GameDataPerPlayer> gameDataByPlayer { get; }

        public Game(string date, List<GameDataPerPlayer> gameData)
        {
            gameDataByPlayer = gameData;
            dateOfGame = date;
            numberOfPlayers = gameData.Count();
        }

        // Loads in game data from file
        public static List<Game> LoadData()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Games.txt";
            int players;
            using (StreamReader input = new StreamReader(filepath))
            {
                try
                {
                    players = (int)input.Read();
                    string line = input.ReadLine();


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
            //TODO load in player data from file
            string date = DateTime.Today.ToString().Split(' ')[0];
            GameDataPerPlayer player1 = new GameDataPerPlayer("Nic", "Issac", 4);
            GameDataPerPlayer player2 = new GameDataPerPlayer("Clayton", "Keeper", 4);
            GameDataPerPlayer player3 = new GameDataPerPlayer("Nico", "Blue Baby", 4);
            GameDataPerPlayer player4 = new GameDataPerPlayer("Maia", "Maggy", 4);
            GameDataPerPlayer player5 = new GameDataPerPlayer("Nic", "Azazel", 4);
            GameDataPerPlayer player6 = new GameDataPerPlayer("Clayton", "The Forgotten", 4);
            GameDataPerPlayer player7 = new GameDataPerPlayer("Nico", "Judas", 4);
            GameDataPerPlayer player8 = new GameDataPerPlayer("Maia", "Dark Judas", 4);
            List<GameDataPerPlayer> gameData1 = new List<GameDataPerPlayer>() { player1, player2, player3, player4 };
            List<GameDataPerPlayer> gameData2 = new List<GameDataPerPlayer>() { player5, player6, player7, player8 };
            Game game1 = new Game(date, gameData1);
            Game game2 = new Game(date, gameData2);
            var games = new List<Game>() { game1, game2 };
            return games;
        }

        public static void PrintGames(List<Game> games)
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Games.txt";
            using (StreamWriter output = new StreamWriter(filepath))
            {
                foreach (Game game in games)
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

    }
}
