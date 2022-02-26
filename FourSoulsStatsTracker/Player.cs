using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Player
    {
        private string name { get; }
        private static List<string> players = new List<string>() { "Nic", "Nico", "Jamir"};

        private static void loadData()
        {
            //TODO load player data from file
        }
        private static void saveData()
        {
            //TODO write player data to file
        }
        public static void AddPlayer(string name)
        {
            players.Add(name);
        }
        public static string[] getPlayers()
        {
            return players.ToArray();
        }
        public static List<string> getPlayersList()
        {
            return players;
        }
    }
}
