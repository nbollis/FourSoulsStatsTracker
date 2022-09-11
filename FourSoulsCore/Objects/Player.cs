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
        public List<DataTable> AllTables { get; set; }

        #region Tables
        public DataTable? CharacterDataTable { get; set; }
        public DataTable? Character4PlayersDataTable { get; set; }
        public DataTable? Character3PlayersDataTable { get; set; }
        public DataTable? Character2PlayersDataTable { get; set; }
        public DataTable? PlayerDataTable { get; set; }
        public DataTable? Player4PlayersDataTable { get; set; }
        public DataTable? Player3PlayersDataTable { get; set; }
        public DataTable? Player2PlayersDataTable { get; set; }

        #endregion


        public Player(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
            GamesPlayed = 0;
            CumulativeSouls = 0;
            WinRate = 0;
            AverageSouls = 0;
            AllTables = new List<DataTable>();
            IStatData.InitializeDataTables(this);
            AllTables.Add(CharacterDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Character2PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(PlayerDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player4PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player3PlayersDataTable ?? throw new NullReferenceException());
            AllTables.Add(Player2PlayersDataTable ?? throw new NullReferenceException());
        }

        public void ParseDataFromGame(Game game)
        {
            if (game.GameData.AsEnumerable().Select(p => p.Field<string>("Name")).Any(p => p == Name))
            {
                IStatData.ParseGameData(this, game);
            }
            else
            {
                throw new ArgumentException("Game does not contain player");
            }
        }
    }
}
