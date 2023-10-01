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

            var games = DataOperations.GetGamesByPlayer(data, player);
            (string Name, int Wins, int TheirWins, int Games)[] results = games.SelectMany(p => p.GameDatas)
                .GroupBy(p => p.PlayerId)
                .Where(p => p.Key != player.Id)
                .Select(p => (
                    p.First().Player.Name,
                    p.Count(gameData => player.GameDatas.First(playersData => playersData.GameId == gameData.GameId).Win == 1), 
                    p.Count(gameData => gameData.Win == 1),
                    p.Count(gameData => gameData.PlayerId == p.Key)))
                .OrderByDescending(p => p.Item3)
                .ToArray();






            //(string, int, int) averagePlayer = ("Average", (int)data.AllPlayers.Value.Average(p => p.Wins)!,
            //    (int)data.AllPlayers.Value.Average(p => p.GamesPlayed)!);
            //results = results.Prepend(averagePlayer).ToArray();
            var seriesNames = results.Select(x => x.Name).ToArray();
            var wins = results.Select(x => (double)x.Wins).ToArray(); 
            var theirWIns = results.Select(x => (double)x.TheirWins + (double)x.Wins).ToArray();
            var gamesArr = results.Select(x => (double)x.Games).ToArray();

            return new StackedBarGraphData(player.Name, gamesArr, wins, theirWIns, seriesNames,
                new string[] { "#f93500",  "#00f91e", "#1300f9" });

        }
    }
}
