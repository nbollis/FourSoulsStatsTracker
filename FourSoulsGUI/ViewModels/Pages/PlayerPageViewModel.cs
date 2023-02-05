using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;

namespace FourSoulsGUI
{
    public class PlayerPageViewModel : BaseViewModel
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

        public PlayerPageViewModel()
        {
            AllPlayers = FourSoulsGlobalData.AllPlayers;
        }

        #endregion

        #region Private Helpers

        #endregion
    }
}
