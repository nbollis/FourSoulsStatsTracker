using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using FourSoulsCore.MVVMBase;

namespace FourSoulsCore.ViewModels
{
    public class EnterGamePageViewModel : BaseViewModel
    {
        #region Private Members

        private Stopwatch GameTimer;

        #endregion

        #region Public Properties
        public ObservableCollection<string> CharacterNames { get; } =
            new ObservableCollection<string>(FourSoulsGlobalData.AllCharacters.Select(p => p.Name));

        public ObservableCollection<string> PlayerNames { get; } =
            new ObservableCollection<string>(FourSoulsGlobalData.AllPlayerNames);

        public GameViewModel GameViewModel { get; set; }

        public TimeSpan TimeElapsed => GameTimer.Elapsed;

        #endregion

        #region Commands
        public ICommand AddPlayerCommand { get; set; }
        public ICommand RemovePlayerCommand { get; set; }
        public ICommand EnterGameCommand { get; set; }
        public ICommand StartGameTimerCommand { get; set; }
        public ICommand StopGameTimmerCommand { get; set; }

        #endregion

        #region Constructor

        public EnterGamePageViewModel()
        {
            GameTimer = new Stopwatch();

            AddPlayerCommand = new RelayCommand(AddPlayer);
            RemovePlayerCommand = new RelayCommand(RemovePlayer);
            EnterGameCommand = new RelayCommand(EnterGame);
            StartGameTimerCommand = new RelayCommand(StartGameTimer);
            StopGameTimmerCommand = new RelayCommand(StopGameTimer);
        }

        #endregion

        #region Private Helpers

        private void AddPlayer()
        {

        }

        private void RemovePlayer()
        {

        }

        private void EnterGame()
        {

        }

        private void StartGameTimer()
        {

        }

        private void StopGameTimer()
        {

        }

        #endregion
    }
}
