using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Accessibility;
using FourSoulsDataConnection;
using FourSoulsGUI.Graphing;
using Graphing.Data;
using Graphing;
using ScottPlot;
using DataOperations = FourSoulsDataConnection.DataOperations;

namespace FourSoulsGUI
{
    public class PlayerStatsDisplayViewModel : BaseViewModel
    {
        #region Private Fields

        private Player player;

        #endregion

        #region Public Fields
          
        public Player Player
        {
            get => player;
            set
            {
               
                // TODO: Think of a better way to update databse only when the final color is selected, instread of whenerver it is changed
                // current idea is to do it when player is changed, but this is not ideal. Especially in the case of when the program is closed 
                CheckForColorChangeAndUpdateDatabase();

                SetProperty(ref player, value);
                PlayerColor = ((Color)ColorConverter.ConvertFromString(player.ColorCode));
                PlayedAgainstPieChart.GraphData = FourSoulsData.GetPlayedAgainstPieChartGraphData(value);
                CharactersPlayedWithPieChart.GraphData = FourSoulsData.GetCharactersPlayedPieChartGraphData(value);
                WinRateDistributionGraph.GraphData = FourSoulsData.GetWinRateStatisticsGraphData(value);
                AverageSoulDistributionGraph.GraphData = FourSoulsData.GetAverageSoulStatisticsGraphData(value);

                WinRateDistributionGraph.Plot.RenderGraph(WinRateDistributionGraph.GraphData, new object());

            }
        }

        #region Player Info

        private Color playerColor;
        public Color PlayerColor
        {
            get => playerColor;
            set => SetProperty(ref playerColor, value);
        }

        private PropertyStatistics winRateStatistics;

        public PropertyStatistics WinRateStatistics =>
            (WinRateDistributionGraph.GraphData as PropertyStatisticsGraphData)!.PropertyStatistics;

        public PropertyStatistics AverageSoulStatistics =>
            (AverageSoulDistributionGraph.GraphData as PropertyStatisticsGraphData)!.PropertyStatistics;

       

        #endregion

        #region Graphs

        //public Character MostPlayedCharacter { get; set; }
        //public Character BestCharacter { get; set; }
        //public Character WorstCharacter { get; set; }
        //public Player BestPlayerAgainst { get; set; }
        //public Player WorstPlayerAgainst { get; set; }

        public GraphViewModel PlayedAgainstPieChart { get; }
        public GraphViewModel CharactersPlayedWithPieChart { get; }
        public GraphViewModel WinRateDistributionGraph { get; } 
        public GraphViewModel AverageSoulDistributionGraph { get; }

        #endregion


        #endregion

        #region Commands

        private void CheckForColorChangeAndUpdateDatabase() 
        {
            // the first time the player is set, it will be null, so we can just return
            if (player == null) return;


            string hexcode = $"#{PlayerColor.A:X2}{PlayerColor.R:X2}{PlayerColor.G:X2}{PlayerColor.B:X2}";
            if (hexcode != Player.ColorCode)
            {
               DataBaseOperations.UpdatePlayerColor(FourSoulsData, Player, hexcode);
            }
        }

        #endregion

        #region Constructor

        public PlayerStatsDisplayViewModel(Player player)
        {
            // initialize charts
            PlayedAgainstPieChart = new GraphViewModel() { Plot = new PieChart() };
            CharactersPlayedWithPieChart = new GraphViewModel() { Plot = new PieChart() };
            WinRateDistributionGraph = new GraphViewModel() { Plot = new DistributionGraph() };
            AverageSoulDistributionGraph = new GraphViewModel() { Plot = new DistributionGraph() };

            // initialize commands

            // do this last so all other things are initilized when player set occurs
            Player = player;


        }

        #endregion

    }
}
