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
                CreatePieChart();
            }
        }

        #region Player Info

        private Color playerColor;
        public Color PlayerColor
        {
            get => playerColor;
            set
            {
                SetProperty(ref playerColor, value);

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
            PlayersPieChart = new GraphViewModel()
            {
                Plot = new PieChart()
            };
            CharactersPieChart = new GraphViewModel()
            {
                Plot = new PieChart()
            };

            // initialize commands

            // do this last so all other things are initilized when player set occurs
            Player = player;


        }

        #endregion



   
        
     

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
