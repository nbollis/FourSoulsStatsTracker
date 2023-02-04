using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
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

        public static void AddPlayer(string name)
        {
            Player player = new Player()
            {
                PlayerName = name,
                PlayerId = SqlConnection.EfContext.Players.Max(p => p.PlayerId) + 1,
            };
            SqlConnection.EfContext.Players.Add(player);
            SqlConnection.EfContext.SaveChanges();
        }

        public static void AddFirst12Games()
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

            var gameDatum = games.ToDictionary(p => p, p => gameData.Where(m => m.GameId == games.IndexOf(p) + 1));


            foreach (var game in gameDatum)
            {
                AddGame(game.Key, game.Value);
            }
        }

        
    }

    
}
