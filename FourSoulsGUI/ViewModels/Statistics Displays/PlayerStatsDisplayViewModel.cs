using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using ScottPlot;

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

        public Character MostPlayedCharacter { get; set; }
        public Character BestCharacter { get; set; }
        public Character WorstCharacter { get; set; }
        public Player BestPlayerAgainst { get; set; }
        public Player WorstPlayerAgainst { get; set; }


        #endregion

        public Plot PlayersPieChart { get; set; }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public PlayerStatsDisplayViewModel(Player player)
        {
            Player = player;
            DataOperations.GetWinRateByPlayer(FourSoulsData, Player);;
        }

        #endregion

        #region Command Methods



        #endregion

        
     

        private void CreateCharts()
        {
            var plot = new ScottPlot.Plot();
        }
    }
}
