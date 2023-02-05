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
using FourSoulsDataConnection;
using Xamarin.Essentials;
using Task = System.Threading.Tasks.Task;
using Timer = System.Timers.Timer;

namespace FourSoulsGUI
{
    public class EnterGamePageViewModel : BaseViewModel
    {
        #region Private Members

        private Timer gameTimer;
        private DateTime? startTime;
        private DateTime? pauseTime;
        private string elapsedTime;
        private GameViewModel gameViewModel;

        #endregion

        #region Public Properties

        public ObservableCollection<Character> Characters => FourSoulsGlobalData.AllCharacters;

        public ObservableCollection<Player> Players => FourSoulsGlobalData.AllPlayers;

        public GameViewModel GameViewModel
        {
            get => gameViewModel;
            set => SetProperty(ref gameViewModel, value);
        }

        public ObservableCollection<string> GameParsingErrors { get; set; }

        public string ElapsedTime
        {
            get => elapsedTime;
            set => SetProperty(ref elapsedTime, value);
        }

        #endregion

        #region Commands
        public ICommand SaveGameCommand { get; set; }
        public ICommand StartGameTimerCommand { get; set; }
        public ICommand PauseGameTimerCommand { get; set; }
        public ICommand ResetGameCommand { get; set; }

        #endregion

        #region Constructor

        public EnterGamePageViewModel()
        {
            GameParsingErrors = new ObservableCollection<string>();
            gameTimer = new Timer();
            gameTimer.Interval = 1000; //milliseconds
            GameViewModel = new();

            gameTimer.Elapsed += (s,e) => UpdateText();
            SaveGameCommand = new RelayCommand(SaveGame);
            StartGameTimerCommand = new RelayCommand(StartGameTimer);
            PauseGameTimerCommand = new RelayCommand(PauseGameTimer);
            ResetGameCommand = new RelayCommand(ResetGame);
        }

        #endregion

        #region Public Methods

        public void AdjustAndParseGameData()
        {
            // remove unused game data
            var game = GameViewModel.Game;
            foreach (var data in game.GameDatas.Where(p => p.Character == null && p.Player == null && p.Souls == 0))
            {
                game.GameDatas.Remove(data);
            }
            game.NumberOfPlayers = game.GameDatas.Count;

            // parse game data
            GameParsingErrors.Clear();
            var characters = game.GameDatas.Select(p => p.CharacterId).ToArray();
            var players = game.GameDatas.Select(p => p.PlayerId).ToArray();
            var souls = game.GameDatas.Select(p => p.Souls).ToList();

            if (game.GameDatas.Count == 1)
                GameParsingErrors.Add("Only One Player");

            if (characters.Any(p => p == 0))
                GameParsingErrors.Add("Missing Character");
            else if (characters.Length != characters.Distinct().Count())
                GameParsingErrors.Add("Duplicate Characters");

            if (players.Any(p => p == 0))
                GameParsingErrors.Add("Missing Player Name");
            else if (players.Length != players.Distinct().Count())
                GameParsingErrors.Add("Duplicate Players");

            
            if (souls.All(p => p != 4))
                GameParsingErrors.Add("No Player With Four Souls"); 
            else if (souls.Count(p => p >= 4) != 1)
                GameParsingErrors.Add("Multiple Players Cannot Have Four Souls");
            else
                game.GameDatas.First(p => p.Souls == 4).Win = 1;
        }

        public void PauseGameTimer()
        {
            pauseTime = DateTime.Now;
            gameTimer.Stop();
        }

        public void SaveGame()
        {
            // TODO: Uncomment this for release version
            //GameViewModel.DateOfEntry = DateTime.Now;
            if (ElapsedTime == null)
                GameViewModel.GameTime = null;
            else
                GameViewModel.GameTime = TimeSpan.Parse(ElapsedTime);
            FourSoulsGlobalData.AddGame(GameViewModel.Game);
            ResetGame();
        }

        #endregion

        #region Private Helpers


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
            ElapsedTime = null;
            startTime = null;
            GameViewModel = new GameViewModel();
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
            OnPropertyChanged(nameof(Players));
            ResetGame();
        }
    }
}
