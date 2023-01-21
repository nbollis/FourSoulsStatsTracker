using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

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
        public StatDataTypes StatDataType { get; set; }
        public List<DataTable> AllTables { get; set; }

        #region Tables
        public DataTable CharacterDataTable { get; set; }
        public DataTable Character4PlayersDataTable { get; set; }
        public DataTable Character3PlayersDataTable { get; set; }
        public DataTable Character2PlayersDataTable { get; set; }
        public DataTable PlayerDataTable { get; set; }
        public DataTable Player4PlayersDataTable { get; set; }
        public DataTable Player3PlayersDataTable { get; set; }
        public DataTable Player2PlayersDataTable { get; set; }

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
        private void AddGame(int souls, bool win)
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
            CumulativeSouls += souls;
            WinRate = (double)Wins / GamesPlayed;
            AverageSouls = (double)CumulativeSouls / GamesPlayed;
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

            if (sd.StatDataType == StatDataTypes.Player)
            {
                InitializeIndividualTable(((Player)sd).VsCharacterDataTable = new DataTable() { TableName = "VsCharacterDataTable" });
                InitializeIndividualTable(((Player)sd).VsCharacter4PlayersDataTable = new DataTable() { TableName = "VsCharacter4PlayersDataTable" });
                InitializeIndividualTable(((Player)sd).VsCharacter3PlayersDataTable = new DataTable() { TableName = "VsCharacter3PlayersDataTable" });
                InitializeIndividualTable(((Player)sd).VsCharacter2PlayersDataTable = new DataTable() { TableName = "VsCharacter2PlayersDataTable" });
            }
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
                DataType = typeof(double),
                ColumnName = "Games Played",
                Caption = "Games Played"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(double),
                ColumnName = "Wins",
                Caption = "Wins"
            };
            table.Columns.Add(column);
            column = new DataColumn()
            {
                DataType = typeof(double),
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

            // set all values to 0
            // j is set to 1 to avoid the name row
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var tableRow = table.Rows[i];
                for (var j = 1; j < tableRow.ItemArray.Length; j++)
                {
                    tableRow[j] = 0;
                }
            }
        }

        /// <summary>
        /// Adds individual game data to the IStatData params tables
        /// Game must have the winner as first
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="game"></param>
        protected static void ParseGameData(IStatData sd, Game game)
        {
            DataRow rowForSpecificSd = game.GameData.Select($"Player = '{sd.Name}'").First();
            int numPlayers = game.GameData.Rows.Count;
            int souls = rowForSpecificSd.Field<int>("Souls");
            bool winner = sd.Name == game.Winner;
            string sdName = sd.Name;
            sd.AddGame(souls, winner);

            // all character and player data tables
            // iterate through each player data in game
            for (int i = 0; i < numPlayers; i++)
            {
                DataRow row = game.GameData.Rows[i];
                string player = row.Field<string>("Player") ?? throw new ArgumentNullException();
                CharacterNames character = row.Field<CharacterNames>("Character");
                int characterIndex = Array.IndexOf(Enum.GetValues<CharacterNames>(), character);
                int playerIndex = FourSoulsGlobalData.AllPlayerNames.IndexOf(player);

                AdjustRowOfTable(sd.PlayerDataTable, souls, playerIndex, winner);
                if (sd.StatDataType == StatDataTypes.Player)
                {
                    if (sdName == player || sd.Name == character.ToString())
                    {
                        AdjustRowOfTable(sd.CharacterDataTable, souls, characterIndex, winner);
                    }
                    else
                    {
                        AdjustRowOfTable(((Player)sd).VsCharacterDataTable, souls, characterIndex, winner);
                    }
                }
                else
                {
                    AdjustRowOfTable(sd.CharacterDataTable, souls, characterIndex, winner);
                }
                

                // number of character specific tables
                switch (game.GameData.Rows.Count)
                {
                    case 2:
                        AdjustRowOfTable(sd.Player2PlayersDataTable, souls, playerIndex, winner);
                        if (sd.StatDataType == StatDataTypes.Player)
                        {
                            if (sdName == player || sd.Name == character.ToString())
                            {
                                AdjustRowOfTable(sd.Character2PlayersDataTable, souls, characterIndex, winner);
                            }
                            else
                            {
                                AdjustRowOfTable(((Player)sd).VsCharacter2PlayersDataTable, souls, characterIndex, winner);
                            }
                        }
                        else
                        {
                            AdjustRowOfTable(sd.Character2PlayersDataTable, souls, characterIndex, winner);
                        }
                        break;
                    case 3:
                        AdjustRowOfTable(sd.Player3PlayersDataTable, souls, playerIndex, winner);
                        if (sd.StatDataType == StatDataTypes.Player)
                        {
                            if (sdName == player || sd.Name == character.ToString())
                            {
                                AdjustRowOfTable(sd.Character3PlayersDataTable, souls, characterIndex, winner);
                            }
                            else
                            {
                                AdjustRowOfTable(((Player)sd).VsCharacter3PlayersDataTable, souls, characterIndex, winner);
                            }
                        }
                        else
                        {
                            AdjustRowOfTable(sd.Character3PlayersDataTable, souls, characterIndex, winner);
                        }
                        break;
                    case 4:
                        AdjustRowOfTable(sd.Player4PlayersDataTable, souls, playerIndex, winner);
                        if (sd.StatDataType == StatDataTypes.Player)
                        {
                            if (sdName == player || sd.Name == character.ToString())
                            {
                                AdjustRowOfTable(sd.Character4PlayersDataTable, souls, characterIndex, winner);
                            }
                            else
                            {
                                AdjustRowOfTable(((Player)sd).VsCharacter4PlayersDataTable, souls, characterIndex, winner);
                            }
                        }
                        else
                        {
                            AdjustRowOfTable(sd.Character4PlayersDataTable, souls, characterIndex, winner);
                        }
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

            double averageSouls = table.Rows[rowIndex].Field<double>("Total Souls") /
                                  table.Rows[rowIndex].Field<double>("Games Played");
            table.Rows[rowIndex].SetField("Average Souls", averageSouls);

            double winRate = table.Rows[rowIndex].Field<double>("Wins") /
                             table.Rows[rowIndex].Field<double>("Games Played");
            table.Rows[rowIndex].SetField("Win Rate", winRate);
        }

        private static void EditTableCell(DataTable table, int rowIndex, string columnHeader, int souls)
        {
            // if adding to a column that cares about souls
            if (souls >= 0)
            {
                table.Rows[rowIndex].SetField(columnHeader, table.Rows[rowIndex].Field<double>(columnHeader) + souls);
            }
            // if incrementing by one
            else
            {
                table.Rows[rowIndex].SetField(columnHeader, table.Rows[rowIndex].Field<double>(columnHeader) + 1);
            }
        }
    }
}
