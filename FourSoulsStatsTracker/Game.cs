using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Game
    {
        private int year;
        private int month;
        private int day;
        private int numberOfPlayers;
        private string date;
        public List<GameDataPerPlayer> gameDataByPlayer { get; }

        public Game(int year_, int month_, int day_, List<GameDataPerPlayer> gameData)
        {
            gameData = gameData.OrderBy(p => p.souls).ToList();
            year = year_;
            month = month_;
            day = day_;
            date = "(" + year + "/" + month + "/" + day + ")";
            numberOfPlayers = gameData.Count();
            gameDataByPlayer = gameData;
        }

    }
}
