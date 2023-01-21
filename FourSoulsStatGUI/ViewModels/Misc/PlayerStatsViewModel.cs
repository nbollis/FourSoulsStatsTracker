using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore;
using FourSoulsCore.MVVMBase;

namespace FourSoulsStatGUI
{
    public class PlayerStatsViewModel : BaseViewModel
    {
        #region Private Members

        private Player player;

        #endregion

        #region Public Properties



        #endregion

        #region Commands

        #endregion

        #region Constructor

        public PlayerStatsViewModel(Player player)
        {
            this.player = player;
        }

        #endregion

        #region Private Helpers

        #endregion
    }
}
