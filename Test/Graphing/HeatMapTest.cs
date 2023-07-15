using FourSoulsDataConnection;
using FourSoulsGraphing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Graphing
{
    [TestFixture]
    public class HeatMapTest
    {
        [Test]
        public static void Test1()
        {

            var players = DataBaseOperations.AllPlayers.Select(p => p as ICharPlayer).ToList();
            var games = DataBaseOperations.AllGames.ToList();
            var graph = new WinRateHeatMap(players, ref games);
            




        }
    }
}
