using System.Collections.Generic;
using System.Linq;

namespace FourSoulsDataConnection
{
    public class GameFilter
    {
        public int NumberOfPlayers { get; private set; }

        public GameFilter(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }

        /// <summary>
        /// Default Values
        /// </summary>
        public GameFilter()
        {
            NumberOfPlayers = 0;
        }

        public IEnumerable<Game> Filter(IEnumerable<Game> gamesToFilter)
        {
            if (NumberOfPlayers != 0)
                return gamesToFilter.Where(p => p.NumberOfPlayers == NumberOfPlayers);
            else
            {
                return gamesToFilter;
            }
        }
    }
}
