using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore;
using FourSoulsCore.MVVMBase;

namespace FourSoulsStatGUI
{
    public class PlayerPageViewModel : BaseViewModel
    {
        #region Private Members

        private PlayerStatsViewModel playerStatsViewModel;

        #endregion

        #region Public Properties

        public ObservableCollection<Player> Players { get; set; }

        public PlayerStatsViewModel PlayerStatsViewModel
        {
            get => playerStatsViewModel;
            set => SetProperty(ref playerStatsViewModel, value);
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public PlayerPageViewModel()
        {
            Players = new ObservableCollection<Player>(FourSoulsGlobalData.AllPlayers);
        }

        #endregion

        #region Private Helpers

        #endregion
    }
}
