using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using NUnit.Framework;

namespace Test
{
    public static class tempProcessing
    {

        [Test]
        public static void GetCharacterEnumForSQL()
        {
            var temp = Enum.GetValues<CharacterName>();
            var sb = new StringBuilder();
            for (var index = 0; index < temp.Length; index++)
            {
                var name = temp[index];
                sb.Append($"({index}, '{name.ToString()}'),");
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
            List<Game> games = new List<Game>()
            {
                new Game() {GameId = 1},
                new Game() {GameId = 2},
                new Game() {GameId = 3},
                new Game() {GameId = 4},
                new Game() {GameId = 5},
                new Game() {GameId = 6},
                new Game() {GameId = 7},
                new Game() {GameId = 8},
                new Game() {GameId = 9},
                new Game() {GameId = 10},
                new Game() {GameId = 11},
                new Game() {GameId = 12},
            };

            List<GameData> gameData = new List<GameData>()
            {
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheKeeper,
                    GameId = 1,
                    PlayerId = 1,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Judas,
                    GameId = 1,
                    PlayerId = 2,
                    Souls = 1,
                    Win = 0
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Lilith,
                    GameId = 2,
                    PlayerId = 1,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.DarkJudas,
                    GameId = 2,
                    PlayerId = 2,
                    Souls = 3,
                    Win = 0
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.BlueBaby,
                    GameId = 3,
                    PlayerId = 1,
                    Souls = 3,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.DarkJudas,
                    GameId = 3,
                    PlayerId = 2,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheKeeper,
                    GameId = 3,
                    PlayerId = 3,
                    Souls = 1,
                    Win = 0
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Samson,
                    GameId = 4,
                    PlayerId = 1,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Lazarus,
                    GameId = 4,
                    PlayerId = 2,
                    Souls = 0,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Eden,
                    GameId = 4,
                    PlayerId = 3,
                    Souls = 1,
                    Win = 0
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Lazarus,
                    GameId = 5,
                    PlayerId = 1,
                    Souls = 1,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Eve,
                    GameId = 5,
                    PlayerId = 3,
                    Souls = 4,
                    Win = 1
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Eve,
                    GameId = 6,
                    PlayerId = 1,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheKeeper,
                    GameId = 6,
                    PlayerId = 3,
                    Souls = 3,
                    Win = 0
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Judas,
                    GameId = 7,
                    PlayerId = 2,
                    Souls = 2,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Eden,
                    GameId = 7,
                    PlayerId = 3,
                    Souls = 4,
                    Win = 1
                },


                new GameData()
                {
                    CharacterId = (int)CharacterName.Azazel,
                    GameId = 8,
                    PlayerId = 2,
                    Souls = 2,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Eden,
                    GameId = 8,
                    PlayerId = 3,
                    Souls = 4,
                    Win = 1
                },


                new GameData()
                {
                    CharacterId = (int)CharacterName.Judas,
                    GameId = 9,
                    PlayerId = 2,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheForgotten,
                    GameId = 9,
                    PlayerId = 3,
                    Souls = 1,
                    Win = 0
                },


                new GameData()
                {
                    CharacterId = (int)CharacterName.Lazarus,
                    GameId = 10,
                    PlayerId = 2,
                    Souls = 3,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Eve,
                    GameId = 10,
                    PlayerId = 3,
                    Souls = 4,
                    Win = 1
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Lazarus,
                    GameId = 11,
                    PlayerId = 1,
                    Souls = 2,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Maggy,
                    GameId = 11,
                    PlayerId = 2,
                    Souls = 3,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheKeeper,
                    GameId = 11,
                    PlayerId = 3,
                    Souls = 4,
                    Win = 1
                },

                new GameData()
                {
                    CharacterId = (int)CharacterName.Lazarus,
                    GameId = 12,
                    PlayerId = 1,
                    Souls = 4,
                    Win = 1
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.Azazel,
                    GameId = 12,
                    PlayerId = 2,
                    Souls = 2,
                    Win = 0
                },
                new GameData()
                {
                    CharacterId = (int)CharacterName.TheKeeper,
                    GameId = 12,
                    PlayerId = 3,
                    Souls = 1,
                    Win = 0
                },

            };

            using (var context = new FourSoulsStatsContext())
            {
                foreach (var game in games)
                {
                    game.GameDatas = gameData.Where(m => m.GameId == games.IndexOf(game) + 1).ToList();
                    game.NumberOfPlayers = game.GameDatas.Count;
                }
                context.Games.AddRange(games);
                context.SaveChanges();
            }
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
