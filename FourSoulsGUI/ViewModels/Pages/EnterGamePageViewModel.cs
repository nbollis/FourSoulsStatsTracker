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
using System.Windows;
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
        public ICommand AddPlayerCommand { get; set; }
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
            AddPlayerCommand = new RelayCommand(AddPlayer);
            SaveGameCommand = new RelayCommand(SaveGame);
            StartGameTimerCommand = new RelayCommand(StartGameTimer);
            PauseGameTimerCommand = new RelayCommand(PauseGameTimer);
            ResetGameCommand = new RelayCommand(ResetGame);
        }

        #endregion


        #region Timer Methods

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
        public void PauseGameTimer()
        {
            pauseTime = DateTime.Now;
            gameTimer.Stop();
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


        #region Command Methods

        private void AddPlayer()
        {
            var playerNameDialog = new TextResponseDialogWindow();
            if (playerNameDialog.ShowDialog() == true)
            {
                string playerName = playerNameDialog.ResponseText;
                var sb = new StringBuilder();
                if (playerName == "")
                    MessageBox.Show("Player Name Cannot Be Empty", "Player Name Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (playerName != null && FourSoulsGlobalData.AllPlayerNames.Contains(playerName))
                    MessageBox.Show("Player with name already exists", "Player Name Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    FourSoulsGlobalData.AddPlayer(playerName);
                    OnPropertyChanged(nameof(Players));
                    ResetGame();
                }
            }
        }

        private void SaveGame()
        {
            PauseGameTimer();

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

            // display errors if any
            if (GameParsingErrors.Any())
            {
                // if only one player does not have four souls
                if (GameParsingErrors.Count == 1 && GameParsingErrors.First().Equals("No Player With Four Souls"))
                {
                    // TODO: Mom's Heart PopUp and remove code below to dos
                    // TODO: This will need to set the winner's GameData Win to 1
                    var sb = new StringBuilder();
                    foreach (var error in GameParsingErrors)
                        sb.AppendLine(error);
                    MessageBox.Show(sb.ToString(), "Game Parsing Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    var sb = new StringBuilder();
                    foreach (var error in GameParsingErrors)
                        sb.AppendLine(error);
                    MessageBox.Show(sb.ToString(), "Game Parsing Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // save game
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

    }
}
