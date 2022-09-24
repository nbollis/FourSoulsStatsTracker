using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public class Game
    {
        public string Winner { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DataTable GameData { get; set; }

        public Game()
        {
            InitializeTable();
        }

        public void AddRowToTable(string player, CharacterNames character, int souls)
        {
            DataRow row = GameData.NewRow();
            row["Player"] = player;
            row["Character"] = character;
            row["Souls"] = souls;
            GameData.Rows.Add(row);
            OrganizeTableBySouls();
            Winner = GameData.Rows[0].Field<string>("Player") ?? throw new NullReferenceException("No Player Found");
        }

        public void OrganizeTableBySouls()
        {
            GameData.DefaultView.Sort = "Souls DESC";
            GameData = GameData.DefaultView.ToTable();
        }

        /// <summary>
        /// Creates the GameDataTable and instantiates the columns
        /// </summary>
        private void InitializeTable()
        {
            GameData = new DataTable();
            DataColumn column = new DataColumn()
            {
                DataType = typeof(string),
                ColumnName = "Player",
                Caption = "Player"
            };
            GameData.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(CharacterNames),
                ColumnName = "Character",
                Caption = "Character"
            };
            GameData.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Souls",
                Caption = "Souls"
            };
            GameData.Columns.Add(column);
        }
    }
}
