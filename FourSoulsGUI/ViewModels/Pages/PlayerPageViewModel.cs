using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FourSoulsDataConnection;

namespace FourSoulsGUI
{
    public class PlayerPageViewModel : BaseViewModel
    {
        #region Private Members

        private ObservableCollection<Player> allPlayers;
        private Player selectedPlayer;
        private PlayerStatsDisplayViewModel playerStatsDisplayViewModel;

        #endregion

        #region Public Properties

        public ObservableCollection<Player> AllPlayers
        {
            get => allPlayers;
            set
            {
                allPlayers = value;
                OnPropertyChanged(nameof(AllPlayers));
            }
        }

        public Player SelectedPlayer
        {
            get => selectedPlayer;
            set
            {
                selectedPlayer = value;
                PlayerStatsDisplayViewModel = new PlayerStatsDisplayViewModel(SelectedPlayer);
                OnPropertyChanged(nameof(SelectedPlayer));
            }
        }

        public PlayerStatsDisplayViewModel PlayerStatsDisplayViewModel
        {
            get => playerStatsDisplayViewModel;
            set => SetProperty(ref playerStatsDisplayViewModel, value);
        }

        #endregion

        #region Commands
        

        #endregion

        #region Constructor

        public PlayerPageViewModel()
        {
            AllPlayers = DataBaseOperations.AllPlayers;
            
        }

        #endregion

        #region Command Methods


        #endregion
    }
}
