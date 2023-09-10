using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using NUnit.Framework;

namespace Test.DataHandling
{
    [TestFixture]
    public class TestDataOperations : DataTestingBase
    {
        [Test]
        public void TestGetWinRateByPlayer()
        {
            var nicPlayer = MockedData.AllPlayers.Value[0];
            var claytonPlayer = MockedData.AllPlayers.Value[1];
            var nicoPlayer = MockedData.AllPlayers.Value[2];


            // Nic in MockData
            var winRates = DataOperations.GetWinRateByPlayer(MockedData, nicPlayer);
            var nic = winRates[1];
            var clayton = winRates[2];
            var nico = winRates[3];

            Assert.That(nic, Is.EqualTo(nicPlayer.WinRate).Within(0.01));
            Assert.That(clayton, Is.EqualTo(66.67).Within(0.01));
            Assert.That(nico, Is.EqualTo(50).Within(0.01));

            // Clayton in MockData
            winRates = DataOperations.GetWinRateByPlayer(MockedData, claytonPlayer);
            nic = winRates[1];
            clayton = winRates[2];
            nico = winRates[3];

            Assert.That(nic, Is.EqualTo(1/(double)6 * 100).Within(0.01));
            Assert.That(clayton, Is.EqualTo(claytonPlayer.WinRate).Within(0.01));
            Assert.That(nico, Is.EqualTo(25).Within(0.01));


            // Nico in MockData
            winRates = DataOperations.GetWinRateByPlayer(MockedData, nicoPlayer);
            nic = winRates[1];
            clayton = winRates[2];
            nico = winRates[3];

            Assert.That(nic, Is.EqualTo(33.33).Within(0.01));
            Assert.That(clayton, Is.EqualTo(50).Within(0.01));
            Assert.That(nico, Is.EqualTo(nicoPlayer.WinRate).Within(0.01));
        }

        [Test]
        public void TestGetAllPlayerNames()
        {
            var names = DataOperations.GetAllPlayerNames(MockedData).ToList();
            Assert.That(names.Count, Is.EqualTo(3));
            Assert.That(names.Contains("Nic"));
            Assert.That(names.Contains("Clayton"));
            Assert.That(names.Contains("Nico"));
        }

        [Test]
        public void TestGetGamesByPlayer()
        {
            var nicPlayer = MockedData.AllPlayers.Value[0];
            var claytonPlayer = MockedData.AllPlayers.Value[1];
            var nicoPlayer = MockedData.AllPlayers.Value[2];

            var players = new List<Player>
            {
                nicPlayer, claytonPlayer, nicoPlayer
            };

            foreach (var player in players)
            {
                var games = DataOperations.GetGamesByPlayer(MockedData, player).ToList();
                Assert.That(games.Count, Is.EqualTo(player.GamesPlayed));
                Assert.That(games.All(p => p.GameDatas.Any(m => m.PlayerId == player.Id)));
                Assert.That(games.Count(p => p.WinningPlayer == player.Id) / (double)games.Count * 100, Is.EqualTo(player.WinRate));
            }
        }
    }
}
