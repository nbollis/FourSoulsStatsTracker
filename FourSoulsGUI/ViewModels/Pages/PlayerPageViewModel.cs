﻿using System;
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

        private List<Player> allPlayers;
        private Player selectedPlayer;
        private PlayerStatsDisplayViewModel playerStatsDisplayViewModel;

        #endregion

        #region Public Properties

        public List<Player> AllPlayers
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
                PlayerStatsDisplayViewModel.Player = value;
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
            AllPlayers = FourSoulsData.AllPlayers.Value.OrderByDescending(p => p.GamesPlayed ??= 0).ToList();
            PlayerStatsDisplayViewModel = new PlayerStatsDisplayViewModel(AllPlayers[0]);
            SelectedPlayer = AllPlayers[0];
        }

        #endregion

        #region Command Methods


        #endregion
    }
}
