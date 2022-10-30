using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public class GameDataPerPlayer
    {
        public string? Souls { get; set; }
        public string? PlayerName { get; set; }
        public string? CharacterPlayed { get; set; }
        public double GameDataPerPlayerHash { get; set; }

        public GameDataPerPlayer()
        {
            PlayerName = null;
            CharacterPlayed = null;
            Souls = null;
            Random rand = new Random();
            GameDataPerPlayerHash = rand.Next();
        }

        public override string ToString()
        {
            string output = CharacterPlayed + ":" + PlayerName + ":" + Souls.ToString();
            return output;
        }
    }
}
