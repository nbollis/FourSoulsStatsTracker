using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using FourSoulsDataConnection.DataBase;
using Graphing.Data;

namespace Graphing
{
    public static class GraphingDataOperations
    {
        public static PropertyStatisticsGraphData GetWinRateStatisticsGraphData(this FourSoulsData data, 
            ICharPlayer charPlayer)
        {
            PropertyStatistics stats = DataOperations.GetWinRateStatistics(data, charPlayer);
            return new PropertyStatisticsGraphData(stats);
           
        }

        public static PropertyStatisticsGraphData GetAverageSoulStatisticsGraphData(this FourSoulsData data,
            ICharPlayer charPlayer)
        {
            PropertyStatistics stats = DataOperations.GetAverageSoulsStatistics(data, charPlayer);
            return new PropertyStatisticsGraphData(stats);
        }

        public static PieChartGraphData GetPlayedAgainstPieChartGraphData(this FourSoulsData data, Player player)
        {
            var games = DataOperations.GetGamesByPlayer(data, player);
            var results = games.SelectMany(p => p.GameDatas)
                .GroupBy(p => p.PlayerId)
                .Where(p => p.Key != player.Id)
                .Select(p => (p.First().Player.Name, p.Key, p.Count(), p.First().Player.ColorCode))
                .OrderByDescending(p => p.Item3)
                .ToArray();
            

            var names = results.Select(x => x.Name).ToArray();
            var values = results.Select(x => (double)x.Item3).ToArray();
            var colors = results.Select(x => x.ColorCode).ToArray();

            return new PieChartGraphData("Played Against Frequency", null, values, colors, names);
        }

        public static PieChartGraphData GetCharactersPlayedPieChartGraphData(this FourSoulsData data, Player player)
        {
            var games = DataOperations.GetGamesByPlayer(data, player);
            var results = games.SelectMany(p => p.GameDatas)
                    .GroupBy(p => p.CharacterId)
                    .Select(p => (p.First().Character.Name, p.Key, p.Count(), p.First().Character.ColorCode))
                    .OrderByDescending(p => p.Item3)
                .ToArray();

            var names = results.Select(x => x.Name).ToArray();
            var values = results.Select(x => (double)x.Item3).ToArray();
            var colors = results.Select(x => x.ColorCode).ToArray();

            return new PieChartGraphData("Characters Played Frequency", null, values, colors, names);
        }

        public static StackedBarGraphData GetPlayerStackedBarGraphData(this FourSoulsData data, Player player)
        {





            return null;
        }
    }
}
