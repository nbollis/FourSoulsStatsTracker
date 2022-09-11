using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore;
using NUnit.Framework;

namespace Test
{
    public static class tempProcessing
    {
        [Test]
        public static void OutputCharactersForEnum()
        {
            string[] characterNames = new string[] {"Isaac", "Cain", "Maggy", "Judas", "Samson", "Eve", "Lilith", "Blue Baby",
                "Lazarus", "The Forgotten", "Eden", "The Lost", "The Keeper", "Azazel", "Apollyon", "Guppy", "Bum-Bo", "Whore of Babylon",
                "Dark Judas", "Tapeworm", "Albert", "Bethany", "Jacob & Esau", "The Broken", "The Hoarder", "The Duantless", "The Deceiver", "The Savage",
                "The Curdled", "The Harlot", "The Soiled", "The Enigma", "The Fettered", "The Capricious", "The Baleful", "The Miser", "The Benighted",
                "The Empty", "The Zealot", "The Deserter", "Ash", "Guy Spelunky", "The Silent", "Captain Viridian", "The Knight", "Pink Knight",
                "Boyfriend", "Psycho Goreman", "Blind Johnny", "Salad Fingers", "Blue Archer", "Quote", "Crewmate", "Bum-Bo The Weird", "Steven",
                "Johnny", "Baba", "Edmund", "Flash Isaac"};

            using (StreamWriter writer = new(File.Create(@"C:\Users\nboll\characters.txt")))
            {
                foreach (var character in characterNames)
                {
                    writer.WriteLine(character.Replace(" ", "") + ",");
                }
            }
        }

        [Test]
        public static void CreateCharacterAndPlayersFiles()
        {
            List<Character> characters = new();
            List<Player> players = new();
            foreach (var character in Enum.GetValues(typeof(CharacterNames)))
            {
                characters.Add(new Character((CharacterNames)character));
            }

            foreach (var player in FourSoulsGlobalData.AllPlayerNames)
            {
                players.Add(new Player(player));
            }

            FourSoulsGlobalData.AllPlayers = players;
            FourSoulsGlobalData.AllCharacters = characters;
            FourSoulsGlobalData.SaveAllData();
        }
    }
}
