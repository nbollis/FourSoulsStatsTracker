using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Xml.Serialization;
using FourSoulsCore;
using Task = System.Threading.Tasks.Task;
using Timer = System.Timers.Timer;

namespace FourSoulsStatGUI
{
    public class EnterGamePageViewModel : BaseViewModel
    {
        #region Private Members

        private Timer gameTimer;
        private DateTime? startTime;
        private DateTime? pauseTime;
        private string elapsedTime;

        #endregion

        #region Public Properties

        public ObservableCollection<string> CharacterNames => FourSoulsGlobalData.AllCharacterNames;

        public ObservableCollection<string> PlayerNames => FourSoulsGlobalData.AllPlayerNames;

        public GameViewModel GameViewModel { get; set; }

        public ObservableCollection<string> GameParsingErrors { get; set; }

        public string ElapsedTime
        {
            get => elapsedTime;
            set => SetProperty(ref elapsedTime, value);
        }

        #endregion

        #region Commands
        public ICommand AddPlayerCommand { get; set; }
        public ICommand SaveGameCommand { get; set; }
        public ICommand StartGameTimerCommand { get; set; }
        public ICommand PauseGameTimerCommand { get; set; }
        public ICommand ResetGameCommand { get; set; }

        #endregion

        #region Constructor

        public EnterGamePageViewModel()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000; //milliseconds
            GameViewModel = new();

            gameTimer.Elapsed += (s,e) => UpdateText();
            AddPlayerCommand = new RelayCommand(AddPlayer);
            SaveGameCommand = new RelayCommand(SaveGame);
            StartGameTimerCommand = new RelayCommand(StartGameTimer);
            PauseGameTimerCommand = new RelayCommand(PauseGameTimer);
            ResetGameCommand = new RelayCommand(ResetGame);
        }

        #endregion

        #region Public Methods

        public void ParseGameForCorrectness()
        {
            GameParsingErrors.Clear();
            var data = GameViewModel.GameData;
            var characters = data.Select(p => p.CharacterId).ToArray();
            var players = data.Select(p => p.PlayerId).ToArray();
            var souls = data.Select(p => p.Souls).ToList();

            if (data.Count == 1)
                GameParsingErrors.Add("Only One Player");

            if (characters.Any(p => p == 0))
                GameParsingErrors.Add("Missing Character");
            else if (characters.Length != characters.Distinct().Count())
                GameParsingErrors.Add("Duplicate Characters");

            if (players.Any(p => p == 0))
                GameParsingErrors.Add("Missing Player Name");
            else if (players.Length != players.Distinct().Count())
                GameParsingErrors.Add("Duplicate Players");

            if (souls.Count(p => p >= 4) != 1)
                GameParsingErrors.Add("Multiple Players Cannot Have Four Souls");
            else if (souls.All(p => p != 4))
                GameParsingErrors.Add("No Player With Four Souls");
        }

        public void PauseGameTimer()
        {
            pauseTime = DateTime.Now;
            gameTimer.Stop();
        }

        public void SaveGame()
        {
            //GameViewModel.DateOfEntry = DateTime.Now;
            GameViewModel.GameTime = TimeSpan.Parse(ElapsedTime);
            FourSoulsGlobalData.AddGame(GameViewModel.Game, GameViewModel.GameData);
        }

        #endregion

        #region Private Helpers

        private void AddPlayer()
        {

        }

        private void StartGameTimer()
        {
            // paused timer
            if (pauseTime.HasValue && startTime != null)
            {
                var pausedElapsed = DateTime.Now - pauseTime.Value;
                startTime = startTime.Value.Add(pausedElapsed);
            }
            else 
            {
                startTime = DateTime.Now;
            }
            
            gameTimer.Start();
        }

        private async void ResetGame()
        {
            gameTimer.Stop();
            await Task.Delay(1000);
            ElapsedTime = "00:00:00";
            startTime = null;
        }

        private void UpdateText()
        {
            if (startTime != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ElapsedTime = (DateTime.Now - startTime ?? throw new NullReferenceException()).Duration()
                        .ToString(@"hh\:mm\:ss");
                });
            }
        }

        #endregion

        public void UpdatePlayerNames()
        {
            OnPropertyChanged(nameof(PlayerNames));
            
        }
    }
}
