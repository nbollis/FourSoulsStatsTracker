using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;

namespace FourSoulsStatGUI
{
    public class PlayerStatPageViewModel : BaseViewModel
    {
        #region Private Members

        private ObservableCollection<Player> allPlayers;

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

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public PlayerStatPageViewModel()
        {
            AllPlayers = DataBaseOperations.AllPlayers;
        }

        #endregion

        #region Private Helpers

        #endregion
    }
}
