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
using FourSoulsDataConnection;

namespace FourSoulsGUI
{
    public class GameViewModel : BaseViewModel
    {
        #region Private Members

        private Game game;

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

        public ICollection<GameData> GameData
        {
            get => game.GameDatas;
        }
    

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public GameViewModel()
        {
            game = DataBaseOperations.CreateNewGame();
            OnPropertyChanged(nameof(GameData));
        }

        #endregion

        #region Private Helpers

     

        #endregion

    }
}
