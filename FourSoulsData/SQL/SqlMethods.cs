using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    public static class SqlConnection
    {
        public static FourSoulsEfContext EfContext { get; set; }

        static SqlConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "NICS-DESKTOP"; // update me
            builder.UserID = "admin"; // update me
            builder.Password = "admin"; // update me
            builder.InitialCatalog = "FourSoulsStats";
            EfContext = new FourSoulsEfContext(builder.ConnectionString);
        }
    }




    public static class SqlMethods
    {
        public static void AddGame(Game game, IEnumerable<GameData> gameDatum)
        {
            game.NumberOfPlayers = gameDatum.Count();
            SqlConnection.EfContext.Games.Add(game);
            SqlConnection.EfContext.SaveChanges();
            SqlConnection.EfContext.GameData.AddRange(gameDatum);
            SqlConnection.EfContext.SaveChanges();
        }

        public static List<Player> GetPlayers()
        {
            return (from p in SqlConnection.EfContext.Players select p).ToList();
        }

        public static List<Character> GetCharacters()
        {
            return (from c in SqlConnection.EfContext.Characters select c).ToList();
        }

        public static List<Game> GetGames()
        {
            return (from g in SqlConnection.EfContext.Games select g).ToList();
        }

        public static List<GameData> GetGameData()
        {
            return (from d in SqlConnection.EfContext.GameData select d).ToList();
        }

        public static void AddExampleGame()
        {
            List<Game> games = new()
            {
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
                new Game(),
            };

            List<GameData> gameData = new()
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
                    PlayerId = 2,
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
                        PlayerId = 2, 
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
                        PlayerId = 2, 
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

            var gameDatum = games.ToDictionary(p => p, p => gameData.Where(m => m.GameId == games.IndexOf(p) + 1));


            foreach (var game in gameDatum)
            {
                AddGame(game.Key, game.Value);
            }


        }
    }
}
