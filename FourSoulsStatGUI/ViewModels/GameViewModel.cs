using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FourSoulsCore;
using FourSoulsCore.MVVMBase;

namespace FourSoulsStatGUI
{
    public class GameViewModel : BaseViewModel
    {
        #region Private Members

        private Game game;
        //private ObservableCollection<GameDataPerPlayer> gameDataPerPlayers;

        #endregion

        #region Public Properties

        public string Winner
        {
            get => game.Winner;
            set { game.Winner = value; OnPropertyChanged(nameof(Winner)); }
        }

        public int NumberOfPlayers
        {
            get => game.NumberOfPlayers;
            set { game.NumberOfPlayers = value; OnPropertyChanged(nameof(NumberOfPlayers)); }
        }

        public DateTime DateOfEntry
        {
            get => game.DateOfEntry;
            set { game.DateOfEntry = value; OnPropertyChanged(nameof(DateOfEntry)); }
        }

        public DataTable GameData
        {
            get => game.GameData; 
            set { game.GameData = value;OnPropertyChanged(nameof(GameData)); }
        }

        public TimeSpan GameTime
        {
            get => game.LengthOfGame;
            set { game.LengthOfGame = value; OnPropertyChanged(nameof(GameTime)); }
        }

        public ObservableCollection<GameDataPerPlayer> GameDataPerPlayers
        {
            get;
        }

        public Game Game
        {
            get { return game; }
            set { game = value; OnPropertyChanged(nameof(Game)); }
        }

        #endregion

        #region Commands

        public ICommand AddPlayerToGameCommand { get; set; }
        public ICommand RemovePlayerFromGameCommand { get; set; }

        #endregion

        #region Constructor

        public GameViewModel()
        {
            game = new Game();
            GameDataPerPlayers = new();

            for (int i = 0; i < 4; i++)
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
            GameDataPerPlayer gameDataPerPlayer = new GameDataPerPlayer();
            GameDataPerPlayers.Add(gameDataPerPlayer);
        }

        /// <summary>
        /// Removes the last GameDataPerPlayer from the list
        /// </summary>
        private void RemovePlayer()
        {
            GameDataPerPlayers.Remove(GameDataPerPlayers.Last());
        }


        private string GetPlayer(int index)
        {
            return GameData.Rows[index].Field<string>("Player") 
                   ?? throw new NullReferenceException("GetPlayer Failed");
        }

        private void SetPlayer(int index, string val)
        {
            GameData.Rows[index]["Player"] = val;
        }

        private string GetCharacter(int index)
        {
            return GameData.Rows[index].Field<string>("Character")
                   ?? throw new NullReferenceException("GetCharacter Failed");
        }
        private void SetCharacter(int index, string val)
        {
            GameData.Rows[index]["Character"] = val;
        }

        private int GetSouls(int index)
        {
            return GameData.Rows[index].Field<int>("Souls");
        }
        private void SetSouls(int index, int val)
        {
            GameData.Rows[index]["Souls"] = val;
        }

        #endregion

    }
}
