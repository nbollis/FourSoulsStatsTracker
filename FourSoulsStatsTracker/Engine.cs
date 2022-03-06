using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Engine
    {
        protected static List<Player> players;
        protected static List<FourSoulsGame> games;
        protected static List<Character> characters;

        // loads all data from file
        public static void LoadAllData()
        {
            games = FourSoulsGame.LoadData();
            characters = Character.LoadData();
            players = Player.LoadData().OrderBy(p => p.wins).ToList();
        }

        // saves all data to file
        public static void SaveAllData()
        {
            Player.PrintPlayers();
            FourSoulsGame.PrintGames();
            Character.PrintCharacters();
        }


       public static void ParseGame(string gameData) 
        {
            string[] fields = gameData.Split(':');
            int count = fields.Length;
            GameDataPerPlayer p1 = new(fields[0], fields[1], Int32.Parse(fields[2]));
            GameDataPerPlayer p2 = new(fields[3], fields[4], Int32.Parse(fields[5]));
            List<GameDataPerPlayer> gameDataList = new List<GameDataPerPlayer>() { p1, p2 };
            if (count > 7) //Seven fields are present for two players
            {
                GameDataPerPlayer p3 = new(fields[6], fields[7], Int32.Parse(fields[8]));
                gameDataList.Add(p3);
            }
            if (count > 10)//Ten fields are present for three players
            {
                GameDataPerPlayer p4 = new(fields[9], fields[10], Int32.Parse(fields[11]));
                gameDataList.Add(p4);
            }
            string date = DateTime.Now.ToString().Split(' ')[0];
            FourSoulsGame game = new FourSoulsGame(date, gameDataList);
            FourSoulsGame.AddGame(game);
            SaveAllData();
        }

        public static void ReloadStats()
        {
            // TODO: Find a more elegant way to reload the stats than just printing and loading all from games
            // possibly alter the initial load in methods to have a game input and run them with each saved game
            LoadAllData();
        }

        public override string ToString()
        {
            return "tacos";
        }
    }
}
