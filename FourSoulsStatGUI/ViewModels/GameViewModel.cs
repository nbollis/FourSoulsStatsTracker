using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FourSoulsData;

namespace FourSoulsStatGUI
{
    public class GameViewModel : BaseViewModel
    {
        #region Private Members

        private Game game;
        //private ObservableCollection<GameDataPerPlayer> gameDataPerPlayers;

        #endregion

        #region Public Properties


        public int NumberOfPlayers
        {
            get => game.NumberOfPlayers;
            set { game.NumberOfPlayers = value; OnPropertyChanged(nameof(NumberOfPlayers)); }
        }

        public DateTime? DateOfEntry
        {
            get => game.Date;
            set { game.Date = value; OnPropertyChanged(nameof(DateOfEntry)); }
        }

        public TimeSpan? GameTime
        {
            get => game.LengthOfGame;
            set { game.LengthOfGame = value; OnPropertyChanged(nameof(GameTime)); }
        }

        public Game Game
        {
            get { return game; }
            set { game = value; OnPropertyChanged(nameof(Game)); }
        }

        public ObservableCollection<GameData> GameData { get; set; }

        #endregion

        #region Commands

        public ICommand AddPlayerToGameCommand { get; set; }
        public ICommand RemovePlayerFromGameCommand { get; set; }

        #endregion

        #region Constructor

        public GameViewModel()
        {
            game = new Game();
            GameData = new();

            for (int i = 0; i < 2; i++)
            {
                AddPlayer();
            }

            AddPlayerToGameCommand = new RelayCommand(AddPlayer);
            RemovePlayerFromGameCommand = new RelayCommand(RemovePlayer);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Adds a new GameDataPerPlayer to the list
        /// </summary>
        private void AddPlayer()
        {
            GameData.Add(new GameData());
        }

        /// <summary>
        /// Removes the last GameDataPerPlayer from the list
        /// </summary>
        private void RemovePlayer()
        {
            GameData.RemoveAt(GameData.Count);
        }

        #endregion

    }
}
