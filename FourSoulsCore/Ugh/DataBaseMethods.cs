using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsCore
{
    public static class DataBaseMethods
    {
        public static void AddPlayer(string name)
        {
            var context = new FourSoulsStatsContext();
            var player = new Player
            {
                PlayerName = name,
            };
            context.Players.Add(player);
            context.SaveChanges();
        }

        public static void AddGame(Game game)
        {
            using (var context = new FourSoulsStatsContext())
            {
                game.NumberOfPlayers = game.GameDatas.Count;

                Game gameToInsert = context.Games.Create();
                gameToInsert.GameDatas = game.GameDatas;
                gameToInsert.GameId = game.GameId;
                gameToInsert.Date = game.Date;
                gameToInsert.NumberOfPlayers = game.NumberOfPlayers;
                gameToInsert.LengthOfGame = game.LengthOfGame;

                context.Games.Add(gameToInsert);
                context.SaveChanges();
            }
        }

        public static void AddFirst12Games()
        {
            List<Game> games = new List<Game>()
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

            foreach (var game in games)
            {
                game.GameDatas = gameData.Where(m => m.GameId == games.IndexOf(game) + 1).ToList();
                AddGame(game);
            }
        }
    }
}
