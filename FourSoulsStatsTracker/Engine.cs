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
        protected static List<string> playerNames;
        protected static List<FourSoulsGame> games;
        protected static List<Character> characters;

        // loads all data from file
        public static void LoadAllData()
        {
            games = FourSoulsGame.LoadData();
            characters = Character.LoadData();
            players = Player.LoadData().OrderBy(p => p.wins).ToList();
            playerNames = Player.GetPlayerList();
        }

        // saves all data to file
        public static void SaveAllData()
        {
            Player.PrintPlayers(players);
            FourSoulsGame.PrintGames();
            Character.PrintCharacters();

        }


       public static void ParseGame() 
        {

        }

        public static void ReloadStats()
        {

        }
    }
}
