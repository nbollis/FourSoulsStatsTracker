using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsDataConnection.DataBase
{
    public class FourSoulsData
    {
        public Lazy<List<Player>> AllPlayers { get; set; }
        public Lazy<List<Game>> AllGames { get; set; }
        public Lazy<List<Character>> AllCharacters { get; set; }
        public Lazy<List<GameData>> AllGameData { get; set; }
    }
}
