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
    public class TestPlayer
    {
        [Test]
        public static void GetDataFormattedProperly()
        {
            List <FourSoulsGame> oldFormatgames = FourSoulsGame.LoadData();
            List<Game> games = new List<Game>();
            List<string> allNames = new List<string>();

            foreach (var oldGames in oldFormatgames)
            {
                Game game = new Game();
                foreach (var gameDataPerPlayer in oldGames.GameDataPerPlayer)
                {
                    DataRow row = game.GameData.NewRow();
                    row["Player"] = gameDataPerPlayer.PlayerName;
                    row["Souls"] = gameDataPerPlayer.Souls;
                    row["Character"] = (CharacterNames)Enum.Parse(typeof(CharacterNames), gameDataPerPlayer.CharacterPlayed
                        .Replace(" ", "").Replace("-", ""));
                    game.GameData.Rows.Add(row);

                    allNames.Add(gameDataPerPlayer.PlayerName);
                }

                game.NumberOfPlayers = oldGames.NumberOfPlayers;
                game.DateOfEntry = DateTime.Parse(oldGames.DateOfEntry);
                game.Winner = oldGames.Winner;
                games.Add(game);
            }

            allNames = allNames.Distinct().ToList();
            FourSoulsGlobalData.AllGames = games;
            FourSoulsGlobalData.AllPlayerNames = allNames;

            //FourSoulsGlobalData.SaveAllData();
        }

      
    }
}
