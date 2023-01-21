using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        /// <summary>
        /// Constructor for the view in entering games
        /// </summary>
        public GameDataPerPlayer()
        {
            PlayerName = null;
            CharacterPlayed = null;
            Souls = null;
            Random rand = new Random();
            GameDataPerPlayerHash = rand.Next();
        }

        /// <summary>
        /// Construction from a Game data in the Game object
        /// </summary>
        /// <param name="row"></param>
        public GameDataPerPlayer(DataRow row)
        {
            PlayerName = (string)row.ItemArray[0]!;
            CharacterPlayed = row.ItemArray[1]!.ToString();
            Souls = row.ItemArray[2]!.ToString();
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
