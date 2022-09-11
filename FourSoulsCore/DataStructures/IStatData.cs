using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public interface IStatData
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
        /// <summary>
        /// Method to call ParseGameData
        /// </summary>
        /// <param name="game"></param>
        public void ParseDataFromGame(Game game);

        /// <summary>
        /// Updates all non-table fields based
        /// </summary>
        /// <param name="souls"></param>
        /// <param name="win"></param>
        public void AddGame(int souls, bool win)
        {
            if (win)
            {
                Wins++;
            }
            else
            {
                Losses++;
            }

            GamesPlayed++;
            CumulativeSouls++;
            WinRate = Wins / GamesPlayed;
            AverageSouls = CumulativeSouls / GamesPlayed;
        }

        /// <summary>
        /// Initialized All Data Tables
        /// </summary>
        /// <param name="sd"></param>
        protected static void InitializeDataTables(IStatData sd)
        {
            InitializeIndividualTable(sd.CharacterDataTable = new DataTable() {TableName = nameof(CharacterDataTable)});
            InitializeIndividualTable(sd.Character4PlayersDataTable = new DataTable() { TableName = nameof(Character4PlayersDataTable) });
            InitializeIndividualTable(sd.Character3PlayersDataTable = new DataTable() { TableName = nameof(Character3PlayersDataTable) });
            InitializeIndividualTable(sd.Character2PlayersDataTable = new DataTable() { TableName = nameof(Character2PlayersDataTable) });
            InitializeIndividualTable(sd.PlayerDataTable = new DataTable() { TableName = nameof(PlayerDataTable) });
            InitializeIndividualTable(sd.Player4PlayersDataTable = new DataTable() { TableName = nameof(Player4PlayersDataTable) });
            InitializeIndividualTable(sd.Player3PlayersDataTable = new DataTable() { TableName = nameof(Player3PlayersDataTable) });
            InitializeIndividualTable(sd.Player2PlayersDataTable = new DataTable() { TableName = nameof(Player2PlayersDataTable) });
        }

        /// <summary>
        /// Initialize an individual data table
        /// </summary>
        /// <param name="table"></param>
        private static void InitializeIndividualTable(DataTable table)
        {
            // initialize unique columnHeader and all rows
            if (table.TableName.Contains("Character"))
            {
                DataColumn col = new DataColumn()
                {
                    DataType = typeof(CharacterNames),
                    ColumnName = "Name",
                    Caption = "Name"
                };
                table.Columns.Add(col);
                foreach (var character in Enum.GetValues<CharacterNames>())
                {
                    DataRow row = table.NewRow();
                    row["Name"] = character;
                    table.Rows.Add(row);
                }
            }
            else
            {
                DataColumn col = new DataColumn()
                {
                    DataType = typeof(string),
                    ColumnName = "Name",
                    Caption = "Name"
                };
                table.Columns.Add(col);
                foreach (var player in FourSoulsGlobalData.AllPlayerNames)
                {
                    DataRow row = table.NewRow();
                    row["Name"] = player;
                    table.Rows.Add(row);
                }
            }

            // initialize all common columns
            DataColumn column = new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Games Played",
                Caption = "Games Played"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Wins",
                Caption = "Wins"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(int),
                ColumnName = "Losses",
                Caption = "Losses"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(double),
                ColumnName = "Win Rate",
                Caption = "Win Rate"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(double),
                ColumnName = "Average Souls",
                Caption = "Average Souls"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(double),
                ColumnName = "Total Souls",
                Caption = "Total Souls"
            };
            table.Columns.Add(column);
        }

        /// <summary>
        /// Adds individual game data to the IStatData params tables
        /// Game must have the winner as first
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="game"></param>
        protected static void ParseGameData(IStatData sd, Game game) 
        {
            int numPlayers = game.GameData.Rows.Count;
            int souls = (int)game.GameData.Rows.Find(sd.Name).ItemArray[2];
            bool winner = sd.Name == game.Winner || sd.Name == game.GameData.Rows[0]["Name"].ToString();
            sd.AddGame(souls, winner);

            // all character and player data tables
            // iterate through each player data in game
            for (int i = 0; i < numPlayers; i++)
            {
                string player = game.GameData.Rows.Find(sd.Name).ItemArray[0].ToString();
                CharacterNames character = (CharacterNames)game.GameData.Rows.Find(sd.Name).ItemArray[1];
                int characterIndex = sd.CharacterDataTable.Rows.IndexOf(sd.CharacterDataTable.Rows.Find(character));
                int playerIndex = sd.PlayerDataTable.Rows.IndexOf(sd.PlayerDataTable.Rows.Find(player));

                AdjustRowOfTable(sd.CharacterDataTable, souls, characterIndex, winner);
                AdjustRowOfTable(sd.PlayerDataTable, souls, playerIndex, winner);

                // number of character specific tables
                switch (game.GameData.Rows.Count)
                {
                    case 2:
                        AdjustRowOfTable(sd.Character2PlayersDataTable, souls, characterIndex, winner);
                        AdjustRowOfTable(sd.Player2PlayersDataTable, souls, playerIndex, winner);
                        break;
                    case 3:
                        AdjustRowOfTable(sd.Character3PlayersDataTable, souls, characterIndex, winner);
                        AdjustRowOfTable(sd.Player3PlayersDataTable, souls, playerIndex, winner);
                        break;
                    case 4:
                        AdjustRowOfTable(sd.Character4PlayersDataTable, souls, characterIndex, winner);
                        AdjustRowOfTable(sd.Player4PlayersDataTable, souls, playerIndex, winner);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AdjustRowOfTable(DataTable table, int souls, int rowIndex, bool winner)
        {
            EditTableCell(table, rowIndex, "Games Played", -1);
            EditTableCell(table, rowIndex, "Total Souls", souls);
            if (winner)
            {
                EditTableCell(table, rowIndex, "Wins", -1);
            }
            else
            {
                EditTableCell(table, rowIndex, "Losses", -1);
            }

            double averageSouls = (double)table.Rows[rowIndex]["Total Souls"] /
                                  (double)table.Rows[rowIndex]["Games Played"];
            table.Rows[rowIndex].SetField("Average Souls", averageSouls);

            double winRate = (double)table.Rows[rowIndex]["Wins"] /
                                  (double)table.Rows[rowIndex]["Games Played"];
            table.Rows[rowIndex].SetField("Win Rate", winRate);
        }

        private static void EditTableCell(DataTable table, int rowIndex, string columnHeader, int souls)
        {
            if (souls >= 0)
            {
                table.Rows[rowIndex].SetField(columnHeader, (int)table.Rows[rowIndex][columnHeader] + souls);
            }
            else
            {
                table.Rows[rowIndex].SetField(columnHeader, (int)table.Rows[rowIndex][columnHeader] + 1);
            }
        }
    }
}
