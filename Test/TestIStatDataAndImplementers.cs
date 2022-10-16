using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FourSoulsCore;

namespace Test
{
    public class TestIStatDataAndImplementers
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static List<Game> Games { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            Game game1 = new Game();
            game1.AddRowToTable("Nic", CharacterNames.Maggy, 2);
            game1.AddRowToTable("Clayton", CharacterNames.Albert, 4);
            game1.AddRowToTable("Nico", CharacterNames.CaptainViridian, 3);

            Game game2 = new Game();
            game2.AddRowToTable("Nic", CharacterNames.Albert, 2);
            game2.AddRowToTable("Clayton", CharacterNames.Maggy, 4);
            game2.AddRowToTable("Nico", CharacterNames.CaptainViridian, 3);

            Game game3 = new Game();
            game3.AddRowToTable("Nic", CharacterNames.Maggy, 4);
            game3.AddRowToTable("Clayton", CharacterNames.Albert, 2);
            game3.AddRowToTable("Nico", CharacterNames.CaptainViridian, 3);

            Game game4 = new Game();
            game4.AddRowToTable("Nic", CharacterNames.Maggy, 3);
            game4.AddRowToTable("Clayton", CharacterNames.Albert, 1);
            game4.AddRowToTable("Nico", CharacterNames.CaptainViridian, 4);

            Games = new List<Game>() { game1, game2, game3, game4 };
        }


        [Test]
        public static void TestPlayerConstructor()
        {
            // test constructor
            Player nic = new Player("Nic");
            Assert.That(nic.Name, Is.EqualTo("Nic"));
            Assert.That(nic.Wins == 0);
            Assert.That(nic.Losses == 0);
            Assert.That(nic.GamesPlayed == 0);
            Assert.That(nic.CumulativeSouls == 0);
            Assert.That(nic.WinRate == 0);
            Assert.That(nic.AverageSouls == 0);
            Assert.That(nic.StatDataType == StatDataTypes.Player);
            Assert.That(nic.AllTables.Count == 12);

            // test tables are set up properly
            for (var i = 0; i < nic.CharacterDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.CharacterDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.Character2PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.Character2PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.Character3PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.Character3PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.Character4PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.Character4PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }

            for (var i = 0; i < nic.VsCharacterDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.VsCharacterDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.VsCharacter2PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.VsCharacter2PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.VsCharacter3PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.VsCharacter3PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }
            for (var i = 0; i < nic.VsCharacter4PlayersDataTable.Rows.Count; i++)
            {
                CharacterNames name = nic.VsCharacter4PlayersDataTable.Rows[i].Field<CharacterNames>("Name");
                Assert.That(name == Enum.GetValues<CharacterNames>()[i]);
            }

            for (int i = 0; i < nic.PlayerDataTable.Rows.Count; i++)
            {
                string? playerName = nic.PlayerDataTable.Rows[i].Field<string>("Name");
                Assert.That(playerName == FourSoulsGlobalData.AllPlayerNames[i]);
            }
            for (int i = 0; i < nic.Player2PlayersDataTable.Rows.Count; i++)
            {
                string? playerName = nic.Player2PlayersDataTable.Rows[i].Field<string>("Name");
                Assert.That(playerName == FourSoulsGlobalData.AllPlayerNames[i]);
            }
            for (int i = 0; i < nic.Player3PlayersDataTable.Rows.Count; i++)
            {
                string? playerName = nic.Player3PlayersDataTable.Rows[i].Field<string>("Name");
                Assert.That(playerName == FourSoulsGlobalData.AllPlayerNames[i]);
            }
            for (int i = 0; i < nic.Player4PlayersDataTable.Rows.Count; i++)
            {
                string? playerName = nic.Player4PlayersDataTable.Rows[i].Field<string>("Name");
                Assert.That(playerName == FourSoulsGlobalData.AllPlayerNames[i]);
            }
        }

        [Test]
        public static void TestPlayerGameParsing()
        {
            Player nic = new Player("Nic");
            foreach (var game in Games)
            {
                nic.ParseDataFromGame(game);
            }

            // check basic info
            Assert.That(nic.Wins == 1);
            Assert.That(nic.Losses == 3);
            Assert.That(nic.GamesPlayed == 4);
            Assert.That(nic.CumulativeSouls == 11);
            Assert.That(Math.Abs(nic.WinRate - 0.25) < 0.01);
            Assert.That(Math.Abs(nic.AverageSouls - 11.0 / 4.0) < 0.01);

            // check character tables
            DataRow maggyRow = nic.CharacterDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 3);
            Assert.That(maggyRow.Field<double>("Wins") == 1);
            Assert.That(maggyRow.Field<double>("Losses") == 2);
            Assert.That(maggyRow.Field<double>("Win Rate") == (double)1/3);
            Assert.That(maggyRow.Field<double>("Average Souls") == (double)9/3);
            Assert.That(maggyRow.Field<double>("Total Souls") == 9);
            maggyRow = nic.Character2PlayersDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 0);
            Assert.That(maggyRow.Field<double>("Wins") == 0);
            Assert.That(maggyRow.Field<double>("Losses") == 0);
            Assert.That(maggyRow.Field<double>("Win Rate") == 0);
            Assert.That(maggyRow.Field<double>("Average Souls") == 0);
            Assert.That(maggyRow.Field<double>("Total Souls") == 0);
            maggyRow = nic.Character3PlayersDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 3);
            Assert.That(maggyRow.Field<double>("Wins") == 1);
            Assert.That(maggyRow.Field<double>("Losses") == 2);
            Assert.That(maggyRow.Field<double>("Win Rate") == (double)1/3);
            Assert.That(maggyRow.Field<double>("Average Souls") == (double)9/3);
            Assert.That(maggyRow.Field<double>("Total Souls") == 9);

            DataRow albertRow = nic.CharacterDataTable.Select($"Name = {(int)CharacterNames.Albert}").First();
            Assert.That(albertRow.Field<double>("Games Played") == 1);
            Assert.That(albertRow.Field<double>("Wins") == 0);
            Assert.That(albertRow.Field<double>("Losses") == 1);
            Assert.That(albertRow.Field<double>("Win Rate") == 0);
            Assert.That(albertRow.Field<double>("Average Souls") == (double)2);
            Assert.That(albertRow.Field<double>("Total Souls") == 2);

            DataRow captainRow = nic.CharacterDataTable.Select($"Name = {(int)CharacterNames.CaptainViridian}").First();
            Assert.That(captainRow.Field<double>("Games Played") == 0);
            Assert.That(captainRow.Field<double>("Wins") == 0);
            Assert.That(captainRow.Field<double>("Losses") == 0);
            Assert.That(captainRow.Field<double>("Win Rate") == 0);
            Assert.That(captainRow.Field<double>("Average Souls") == 0);
            Assert.That(captainRow.Field<double>("Total Souls") == 0);

            DataRow tapewormRow = nic.CharacterDataTable.Select($"Name = {(int)CharacterNames.Tapeworm}").First();
            Assert.That(tapewormRow.Field<double>("Games Played") == 0);
            Assert.That(tapewormRow.Field<double>("Wins") == 0);
            Assert.That(tapewormRow.Field<double>("Losses") == 0);
            Assert.That(tapewormRow.Field<double>("Win Rate") == 0);
            Assert.That(tapewormRow.Field<double>("Average Souls") == 0);
            Assert.That(tapewormRow.Field<double>("Total Souls") == 0);

            // check character vs tables
            maggyRow = nic.VsCharacterDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 1);
            Assert.That(maggyRow.Field<double>("Wins") == 0);
            Assert.That(maggyRow.Field<double>("Losses") == 1);
            Assert.That(maggyRow.Field<double>("Win Rate") == 0);
            Assert.That(maggyRow.Field<double>("Average Souls") == 2);
            Assert.That(maggyRow.Field<double>("Total Souls") == 2);
            maggyRow = nic.VsCharacter2PlayersDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 0);
            Assert.That(maggyRow.Field<double>("Wins") == 0);
            Assert.That(maggyRow.Field<double>("Losses") == 0);
            Assert.That(maggyRow.Field<double>("Win Rate") == 0);
            Assert.That(maggyRow.Field<double>("Average Souls") == 0);
            Assert.That(maggyRow.Field<double>("Total Souls") == 0);
            maggyRow = nic.VsCharacter3PlayersDataTable.Select($"Name = {(int)CharacterNames.Maggy}").First();
            Assert.That(maggyRow.Field<double>("Games Played") == 1);
            Assert.That(maggyRow.Field<double>("Wins") == 0);
            Assert.That(maggyRow.Field<double>("Losses") == 1);
            Assert.That(maggyRow.Field<double>("Win Rate") == 0);
            Assert.That(maggyRow.Field<double>("Average Souls") == 2);
            Assert.That(maggyRow.Field<double>("Total Souls") == 2);
            
            albertRow = nic.VsCharacterDataTable.Select($"Name = {(int)CharacterNames.Albert}").First();
            Assert.That(albertRow.Field<double>("Games Played") == 3);
            Assert.That(albertRow.Field<double>("Wins") == 1);
            Assert.That(albertRow.Field<double>("Losses") == 2);
            Assert.That(albertRow.Field<double>("Win Rate") == (double)1/3);
            Assert.That(albertRow.Field<double>("Average Souls") == (double)9/3);
            Assert.That(albertRow.Field<double>("Total Souls") == 9);

            captainRow = nic.VsCharacterDataTable.Select($"Name = {(int)CharacterNames.CaptainViridian}").First();
            Assert.That(captainRow.Field<double>("Games Played") == 4);
            Assert.That(captainRow.Field<double>("Wins") == 1);
            Assert.That(captainRow.Field<double>("Losses") == 3);
            Assert.That(captainRow.Field<double>("Win Rate") == 0.25);
            Assert.That(captainRow.Field<double>("Average Souls") == (double) 11 / 4);
            Assert.That(captainRow.Field<double>("Total Souls") == 11);

            // check player tables
            DataRow nicRow = nic.PlayerDataTable.Select("Name = 'Nic'").First();
            Assert.That(nicRow.Field<double>("Games Played") == 4);
            Assert.That(nicRow.Field<double>("Wins") == 1);
            Assert.That(nicRow.Field<double>("Losses") == 3);
            Assert.That(nicRow.Field<double>("Win Rate") == 0.25);
            Assert.That(nicRow.Field<double>("Average Souls") == (double)11 / 4);
            Assert.That(nicRow.Field<double>("Total Souls") == 11);
            nicRow = nic.Player2PlayersDataTable.Select("Name = 'Nic'").First();
            Assert.That(nicRow.Field<double>("Games Played") == 0);
            Assert.That(nicRow.Field<double>("Wins") == 0);
            Assert.That(nicRow.Field<double>("Losses") == 0);
            Assert.That(nicRow.Field<double>("Win Rate") == 0);
            Assert.That(nicRow.Field<double>("Average Souls") == 0);
            Assert.That(nicRow.Field<double>("Total Souls") == 0);
            nicRow = nic.Player3PlayersDataTable.Select("Name = 'Nic'").First();
            Assert.That(nicRow.Field<double>("Games Played") == 4);
            Assert.That(nicRow.Field<double>("Wins") == 1);
            Assert.That(nicRow.Field<double>("Losses") == 3);
            Assert.That(nicRow.Field<double>("Win Rate") == 0.25);
            Assert.That(nicRow.Field<double>("Average Souls") == (double)11 / 4);
            Assert.That(nicRow.Field<double>("Total Souls") == 11);

            DataRow claytonRow = nic.PlayerDataTable.Select("Name = 'Clayton'").First();
            Assert.That(claytonRow.Field<double>("Games Played") == 4);
            Assert.That(claytonRow.Field<double>("Wins") == 1);
            Assert.That(claytonRow.Field<double>("Losses") == 3);
            Assert.That(claytonRow.Field<double>("Win Rate") == 0.25);
            Assert.That(claytonRow.Field<double>("Average Souls") == (double)11 / 4);
            Assert.That(claytonRow.Field<double>("Total Souls") == 11);

            DataRow nicoRow = nic.PlayerDataTable.Select("Name = 'Nico'").First();
            Assert.That(nicoRow.Field<double>("Games Played") == 4);
            Assert.That(nicoRow.Field<double>("Wins") == 1);
            Assert.That(nicoRow.Field<double>("Losses") == 3);
            Assert.That(nicoRow.Field<double>("Win Rate") == 0.25);
            Assert.That(nicoRow.Field<double>("Average Souls") == (double)11 / 4);
            Assert.That(nicoRow.Field<double>("Total Souls") == 11);

            // add new game and ensure it is all added correctly
            Game newGame = new();
            newGame.AddRowToTable("Nic", CharacterNames.Apollyon, 4);
            newGame.AddRowToTable("Maia", CharacterNames.Azazel, 4);
            newGame.AddRowToTable("Claire", CharacterNames.Ash, 4);
            nic.ParseDataFromGame(newGame);

            Assert.That(nic.Wins == 2);
            Assert.That(nic.Losses == 3);
            Assert.That(nic.GamesPlayed == 5);
            Assert.That(nic.CumulativeSouls == 15);
            Assert.That(Math.Abs(nic.WinRate - 0.4) < 0.01);
            Assert.That(Math.Abs(nic.AverageSouls - 15.0 / 5.0) < 0.01);

            nicRow = nic.PlayerDataTable.Select("Name = 'Nic'").First();
            Assert.That(nicRow.Field<double>("Games Played") == 5);
            Assert.That(nicRow.Field<double>("Wins") == 2);
            Assert.That(nicRow.Field<double>("Losses") == 3);
            Assert.That(nicRow.Field<double>("Win Rate") == 0.4);
            Assert.That(nicRow.Field<double>("Average Souls") == (double)15 / 5);
            Assert.That(nicRow.Field<double>("Total Souls") == 15);

            nicoRow = nic.PlayerDataTable.Select("Name = 'Nico'").First();
            Assert.That(nicoRow.Field<double>("Games Played") == 4);
            Assert.That(nicoRow.Field<double>("Wins") == 1);
            Assert.That(nicoRow.Field<double>("Losses") == 3);
            Assert.That(nicoRow.Field<double>("Win Rate") == 0.25);
            Assert.That(nicoRow.Field<double>("Average Souls") == (double)11 / 4);
            Assert.That(nicoRow.Field<double>("Total Souls") == 11);

            DataRow maiaRow = nic.PlayerDataTable.Select("Name = 'Maia'").First();
            Assert.That(maiaRow.Field<double>("Games Played") == 1);
            Assert.That(maiaRow.Field<double>("Wins") == 1);
            Assert.That(maiaRow.Field<double>("Losses") == 0);
            Assert.That(maiaRow.Field<double>("Win Rate") == 1);
            Assert.That(maiaRow.Field<double>("Average Souls") == 4);
            Assert.That(maiaRow.Field<double>("Total Souls") == 4);
        }

        [Test]
        public static void TestCharacterConstructor()
        {

        }

        [Test]
        public static void TestCharacterGameParsing()
        {

        }

      
    }
}
