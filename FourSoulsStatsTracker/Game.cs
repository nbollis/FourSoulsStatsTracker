using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public abstract class  Game
    {
        public abstract List<T> LoadData<T>();

        public abstract void PrintGames<T>(List<T> games);
    }
}
