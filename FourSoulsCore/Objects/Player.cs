using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public class Player : IStatData
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GamesPlayed { get; set; }
        public int CumulativeSouls { get; set; }
        public double WinRate { get; set; }
        public double AverageSouls { get; set; }
        public StatDataTypes StatDataType { get; set; }
        public List<DataTable> AllTables { get; set; }

        #region Tables
        public DataTable CharacterDataTable { get; set; }
        public DataTable Character4PlayersDataTable { get; set; }
        public DataTable Character3PlayersDataTable { get; set; }
        public DataTable Character2PlayersDataTable { get; set; }
        public DataTable VsCharacterDataTable { get; set; }
        public DataTable VsCharacter4PlayersDataTable { get; set; }
        public DataTable VsCharacter3PlayersDataTable { get; set; }
        public DataTable VsCharacter2PlayersDataTable { get; set; }
        public DataTable PlayerDataTable { get; set; }
        public DataTable Player4PlayersDataTable { get; set; }
        public DataTable Player3PlayersDataTable { get; set; }
        public DataTable Player2PlayersDataTable { get; set; }


        #endregion

        // need a better solution than this for a parameterless constyruct
        public Player()
        {
            Name = "";
            Wins = 0;
            Losses = 0;
            GamesPlayed = 0;
            CumulativeSouls = 0;
            WinRate = 0;
            AverageSouls = 0;
            StatDataType = StatDataTypes.Player;
            AllTables = new List<DataTable>();
            IStatData.InitializeDataTables(this);
            AllTables.Add(CharacterDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character2PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacterDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter2PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(PlayerDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player2PlayersDataTable ?? throw new NullReferenceException());
        }

        public Player(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
            GamesPlayed = 0;
            CumulativeSouls = 0;
            WinRate = 0;
            AverageSouls = 0;
            StatDataType = StatDataTypes.Player;
            AllTables = new List<DataTable>();
            IStatData.InitializeDataTables(this);
            AllTables.Add(CharacterDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character2PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacterDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(VsCharacter2PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(PlayerDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player2PlayersDataTable ?? throw new NullReferenceException());
        }

        public void ParseDataFromGame(Game game)
        {
            if (game.GameData.AsEnumerable().Select(p => p.Field<string>("Player")).Any(p => p == Name))
            {
                IStatData.ParseGameData(this, game);
            }
            else
            {
                throw new ArgumentException("Game does not contain player");
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
