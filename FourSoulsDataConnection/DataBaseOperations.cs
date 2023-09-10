using FourSoulsDataConnection.DataBase;
using System.Linq;

namespace FourSoulsDataConnection
{
    public static class DataBaseOperations
    {
        public static void AddPlayer(FourSoulsData data, string name)
        {
            using (var context = new FourSoulsDbContext())
            {
                // save player
                var player = new Player
                {
                    Name = name,
                };
                context.Players.Add(player);
                context.SaveChanges();

                // update local
                data.AllPlayers.Value.Add(player);
            }
        }

        public static void AddGame(FourSoulsData data, Game game)
        {
            using (var context = new FourSoulsDbContext())
            {
                // save game
                game.NumberOfPlayers = game.GameDatas.Count;
                context.Games.Add(game);
                context.SaveChanges();

                // update local representation of characters and players
                data = new FourSoulsDataDirectClient(true).Data;
            }
        }

        public static Game CreateNewGame(FourSoulsData data)
        {
            Game game;
            using (var context = new FourSoulsDbContext())
            {
                game = context.Games.Create();
                game.GameId = data.AllGames.Value.Max(p => p.GameId) + 1;

                for (int i = 0; i < 4; i++)
                {
                    GameData gameData = context.GameDatas.Create();
                    gameData.Game = game;
                    game.GameDatas.Add(gameData);
                }
            }

            return game;
        }


    }
}
