using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test.DataHandling
{
    [TestFixture]
    public class TestMockData : DataTestingBase
    {

        [Test]
        public static void MockDataCountsCorrect()
        {
            var characters = MockedData.AllCharacters.Value;
            Assert.That(characters.Count, Is.EqualTo(12));

            var players = MockedData.AllPlayers.Value;
            Assert.That(players.Count, Is.EqualTo(3));

            var games = MockedData.AllGames.Value;
            Assert.That(games.Count, Is.EqualTo(12));

            var gameDatum = MockedData.AllGameData.Value;
            Assert.That(gameDatum.Count, Is.EqualTo(28));
        }
    }
}
