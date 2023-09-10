using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test.DataHandling
{
    [TestFixture]
    public class TestModels : DataTestingBase
    {
        [Test]
        public void TestCharacter()
        {
            var allCharacters = MockedData.AllCharacters.Value;

            var eve = allCharacters.First(p => p.Name == "Eve");
            Assert.That(eve.Id, Is.EqualTo(6));
            Assert.That(eve.Wins, Is.EqualTo(3));                               
            Assert.That(eve.GamesPlayed, Is.EqualTo(3));
            Assert.That(eve.WinRate, Is.EqualTo(100).Within(0.01));
            Assert.That(eve.AverageSouls, Is.EqualTo(2.67).Within(0.01));
            Assert.That(eve.CumulativeSouls, Is.EqualTo(8));
            Assert.That(eve.ToString(), Is.EqualTo($"{eve.Id}:{eve.Name}"));                                                                
        }

        [Test]
        public void TestPlayer()
        {
            var allPlayers = MockedData.AllPlayers.Value;

            var nic = allPlayers.First(p => p.Name == "Nic");
            Assert.That(nic.Id, Is.EqualTo(1));
            Assert.That(nic.Wins, Is.EqualTo(5));
            Assert.That(nic.GamesPlayed, Is.EqualTo(8));
            Assert.That(nic.WinRate, Is.EqualTo(62.5).Within(0.01));
            Assert.That(nic.AverageSouls, Is.EqualTo(2).Within(0.01));
            Assert.That(nic.CumulativeSouls, Is.EqualTo(16));
            Assert.That(nic.ToString(), Is.EqualTo($"{nic.Id}:{nic.Name}"));
        }

        [Test]
        public void TestGame()
        {
            var allGames = MockedData.AllGames.Value;
            var first = allGames[0];

            Assert.That(first.GameId, Is.EqualTo(1));
            Assert.That(first.NumberOfPlayers, Is.EqualTo(2));
            Assert.That(first.WinningPlayer, Is.EqualTo(1));
            Assert.That(first.WinningCharacter, Is.EqualTo(13));
            Assert.That(first.GameDatas.Count, Is.EqualTo(2));

            var firstData = first.GameDatas.First();
            Assert.That(firstData.GameId, Is.EqualTo(1));
            Assert.That(firstData.CharacterId, Is.EqualTo(13));
            Assert.That(firstData.PlayerId, Is.EqualTo(1));
            Assert.That(firstData.Souls, Is.EqualTo(4));
            Assert.That(firstData.Win, Is.EqualTo(1));   
            Assert.That(firstData.ToString(), Is.EqualTo("1:13:4"));

            var secondData = first.GameDatas.ToList()[1];
            Assert.That(secondData.GameId, Is.EqualTo(1));
            Assert.That(secondData.CharacterId, Is.EqualTo(4));
            Assert.That(secondData.PlayerId, Is.EqualTo(2));
            Assert.That(secondData.Souls, Is.EqualTo(1));
            Assert.That(secondData.Win, Is.EqualTo(0));
            Assert.That(secondData.ToString(), Is.EqualTo("2:4:1"));

        }
    }
}
