using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public class GameDataPerPlayer
    {
        public int Souls { get; set; }
        public string PlayerName { get; set; }
        public string CharacterPlayed { get; set; }

        public GameDataPerPlayer(string name, string character, int soul)
        {
            PlayerName = name;
            CharacterPlayed = character;
            Souls = soul;
        }

        public override string ToString()
        {
            string output = CharacterPlayed + ":" + PlayerName + ":" + Souls.ToString();
            return output;
        }
    }
}
