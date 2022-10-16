using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore.MVVMBase;

namespace FourSoulsCore.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        #region Private Members

        private Game game;

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

        public ObservableCollection<int> PossibleSouls { get; } 
            = new ObservableCollection<int>() { 0, 1, 2, 3, 4 };

        public string Player1
        {
            get => GetPlayer(0);
            set
            {
                SetPlayer(0, value); OnPropertyChanged(nameof(Player1));
            }
        }

        public string Player2
        {
            get => GetPlayer(1);
            set
            {
                SetPlayer(1, value); OnPropertyChanged(nameof(Player2));
            }
        }

        public string Player3
        {
            get => GetPlayer(2);
            set
            {
                SetPlayer(2, value); OnPropertyChanged(nameof(Player3));
            }
        }

        public string Player4
        {
            get => GetPlayer(3);
            set
            {
                SetPlayer(3, value); OnPropertyChanged(nameof(Player4));
            }
        }

        public string Character1
        {
            get => GetCharacter(0);
            set
            {
                SetCharacter(0, value); OnPropertyChanged(nameof(Character1));
            }
        }

        public string Character2
        {
            get => GetCharacter(1);
            set
            {
                SetCharacter(1, value); OnPropertyChanged(nameof(Character2));
            }
        }

        public string Character3
        {
            get => GetCharacter(2);
            set
            {
                SetCharacter(2, value); OnPropertyChanged(nameof(Character3));
            }
        }

        public string Character4
        {
            get => GetCharacter(3);
            set
            {
                SetCharacter(3, value); OnPropertyChanged(nameof(Character4));
            }
        }

        public int Souls1
        {
            get => GetSouls(0);
            set
            {
                SetSouls(0, value); OnPropertyChanged(nameof(Souls1));
            }
        }

        public int Souls2
        {
            get => GetSouls(1);
            set
            {
                SetSouls(1, value); OnPropertyChanged(nameof(Souls2));
            }
        }

        public int Souls3
        {
            get => GetSouls(2);
            set
            {
                SetSouls(2, value); OnPropertyChanged(nameof(Souls3));
            }
        }

        public int Souls4
        {
            get => GetSouls(3);
            set
            {
                SetSouls(3, value); OnPropertyChanged(nameof(Souls4));
            }
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public GameViewModel(Game game)
        {
            this.game = game;
        }

        #endregion

        #region Private Helpers

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
