using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class GameDataPerPlayer
    {
        public int souls { get; set; }
        public string playerName { get; set; }
        public string characterPlayed { get; set; }

        public GameDataPerPlayer(string name, string character, int soul)
        {
            playerName = name;
            characterPlayed = character;
            souls = soul;
        }

        public override string ToString()
        {
            string output = characterPlayed + "," + playerName + "," + souls.ToString();
            return output;
        }
    }
}
