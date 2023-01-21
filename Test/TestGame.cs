using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore;
using NUnit.Framework;

namespace Test
{
    public class TestGame
    {

        [Test]
        public static void temp()
        {
            var temp = Enum.GetValues<CharacterNames>();


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Characters (name, games_played, wins)\n");
            sb.Append("VALUES ");
            foreach (var character in temp)
            {
                sb.Append($"('{character.ToString()}', 0, 0),");
            }
            var characterString = sb.ToString();
            characterString = characterString.Remove(characterString.LastIndexOf(','), 1);
        }



        [Test]
        public static void TestOrganizeTableBySouls()
        {
            Game game = new Game();
            game.AddRowToTable("Nic", CharacterNames.Maggy, 2);
            game.AddRowToTable("Clayton", CharacterNames.Albert, 4);
            game.AddRowToTable("Nico", CharacterNames.CaptainViridian, 3);
            Assert.That(game.GameData.Rows.Count == 3);
            
            int previousSouls = 4;
            for (var i = 0; i < game.GameData.Rows.Count; i++)
            {
                var row = game.GameData.Rows[i];
                Assert.That(previousSouls >= (int)row["Souls"]);
                previousSouls = (int)row["Souls"];
            }
        }
    }
}
