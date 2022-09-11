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
        public static void TestOrganizeTableBySouls()
        {
            Game game = new Game();
            game.AddRowToTable("Nic", CharacterNames.Maggy, 2);
            game.AddRowToTable("Clayton", CharacterNames.Albert, 4);
            game.AddRowToTable("Nico", CharacterNames.CaptainViridian, 3);
            Assert.That(game.GameData.Rows.Count == 3);
            
            game.OrganizeTableBySouls();
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
