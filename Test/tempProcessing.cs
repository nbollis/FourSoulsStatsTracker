using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore;
using NUnit.Framework;
using CharacterName = FourSoulsCore.CharacterName;

namespace Test
{
    public static class tempProcessing
    {

        [Test]
        public static void GetCharacterEnumForSQL()
        {
            var temp = Enum.GetValues<CharacterName>();
            var sb = new StringBuilder();
            foreach (var name in temp)
            {
                sb.Append($"('{name.ToString()}'),");
            }
            //foreach (var name in temp)
            //{
            //    sb.AppendLine($"{name.ToString()} = {(int)name + 1},");
            //}

            var str = sb.ToString();
            var final = str.Substring(0, str.Length - 1) + ';';
        }

        [Test]
        public static void AddFirst12Games()
        {
           
            DataBaseMethods.AddFirst12Games();
        }

        [Test]
        public static void OutputCharactersForEnum()
        {


            //string[] characterNames = new string[] {"Isaac", "Cain", "Maggy", "Judas", "Samson", "Eve", "Lilith", "Blue Baby",
            //    "Lazarus", "The Forgotten", "Eden", "The Lost", "The Keeper", "Azazel", "Apollyon", "Guppy", "Bum-Bo", "Whore of Babylon",
            //    "Dark Judas", "Tapeworm", "Albert", "Bethany", "Jacob & Esau", "The Broken", "The Hoarder", "The Duantless", "The Deceiver", "The Savage",
            //    "The Curdled", "The Harlot", "The Soiled", "The Enigma", "The Fettered", "The Capricious", "The Baleful", "The Miser", "The Benighted",
            //    "The Empty", "The Zealot", "The Deserter", "Ash", "Guy Spelunky", "The Silent", "Captain Viridian", "The Knight", "Pink Knight",
            //    "Boyfriend", "Psycho Goreman", "Blind Johnny", "Salad Fingers", "Blue Archer", "Quote", "Crewmate", "Bum-Bo The Weird", "Steven",
            //    "Johnny", "Baba", "Edmund", "Flash Isaac"};

            //using (StreamWriter writer = new(File.Create(@"C:\Users\nboll\characters.txt")))
            //{
            //    foreach (var character in characterNames)
            //    {
            //        writer.WriteLine(character.Replace(" ", "") + ",");
            //    }
            //}
        }
    }
}
