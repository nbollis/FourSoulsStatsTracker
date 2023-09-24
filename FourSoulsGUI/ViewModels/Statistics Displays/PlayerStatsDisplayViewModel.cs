using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SetProperty(ref player, value);
                PlayerColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(player.ColorCode));
            }
        }

        #region Player Info

        private SolidColorBrush playerColorBrush;

        public SolidColorBrush PlayerColorBrush
        {
            get => playerColorBrush;
            set
            {
                playerColorBrush = value;
                OnPropertyChanged(nameof(PlayerColorBrush));
            }
        }

        #endregion

        #region Graphs

        //public Character MostPlayedCharacter { get; set; }
        //public Character BestCharacter { get; set; }
        //public Character WorstCharacter { get; set; }
        //public Player BestPlayerAgainst { get; set; }
        //public Player WorstPlayerAgainst { get; set; }



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

        private GraphViewModel charactersPieChart;

        public GraphViewModel CharactersPieChart
        {
            get => charactersPieChart;
            set
            {
                charactersPieChart = value;
                OnPropertyChanged(nameof(CharactersPieChart));
            }
        }

        #endregion


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
            CharactersPieChart = new GraphViewModel()
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
            PieChartGraphData playerData = new PieChartGraphData("Player Play Frequency", null, seriesValues.ToArray(),
                               seriesColors.ToArray(), seriesNames.ToArray());

            PlayersPieChart.GraphData = playerData;

            seriesNames.Clear();
            seriesValues.Clear();
            seriesColors.Clear();
            foreach (var result in DataOperations.GetPlayFrequencyForCharacterByPlayer(FourSoulsData, Player))
            {
                seriesNames.Add(result.Name);
                seriesValues.Add(result.Count);
                seriesColors.Add(result.HexCode);
            }
            PieChartGraphData characterData = new PieChartGraphData("Character Play Frequency", null, seriesValues.ToArray(),
                seriesColors.ToArray(), seriesNames.ToArray());
            CharactersPieChart.GraphData = characterData;

        }
    }
}
