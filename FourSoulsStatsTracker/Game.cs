using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public abstract class  Game
    {
        public abstract List<Game> LoadData();

        public abstract void PrintGames(List<Game> games);
    }
}
