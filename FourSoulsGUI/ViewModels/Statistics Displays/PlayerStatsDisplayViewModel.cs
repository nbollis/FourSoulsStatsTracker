using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            set => SetProperty(ref player, value);
        }

        #region Stats

        //public Character MostPlayedCharacter { get; set; }
        //public Character BestCharacter { get; set; }
        //public Character WorstCharacter { get; set; }
        //public Player BestPlayerAgainst { get; set; }
        //public Player WorstPlayerAgainst { get; set; }


        #endregion

        private GraphViewModel playersPieChart;
        public GraphViewModel PlayersPieChart
        {
            get => playersPieChart;
            set
            {
                playersPieChart = value;
                OnPropertyChanged(nameof(PlayersPieChart));
            }
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public PlayerStatsDisplayViewModel(Player player)
        {
            Player = player;
            PlayersPieChart = new GraphViewModel()
            {
                Plot = new PieChart()
            };
        }

        #endregion



        public void ChangePlayer(Player player)
        {
            Player = player; 
            CreatePieChart();
        }
        
     

        private void CreatePieChart()
        {
            List<string> seriesNames = new List<string>();
            List<double> seriesValues = new List<double>();
            List<string> seriesColors = new List<string>();
            foreach (var result in DataOperations.GetPlayFrequencyForPlayer(FourSoulsData, Player))
            {
                seriesNames.Add(result.Name);
                seriesValues.Add(result.Count);
                seriesColors.Add(result.HexCode);
            }
            PieChartGraphData data = new PieChartGraphData("Player Play Frequency", null, seriesValues.ToArray(),
                               seriesColors.ToArray(), seriesNames.ToArray());

            PlayersPieChart.GraphData = data;
        }
    }
}
