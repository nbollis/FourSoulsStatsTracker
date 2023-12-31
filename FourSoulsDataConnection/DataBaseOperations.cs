using FourSoulsDataConnection.DataBase;
using System.Linq;
using FourSoulsDataConnection.Util;

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
                var color = ColorQueue.GetNextColor(data, player);
                player.ColorCode = color;

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
                data.AllGames.Value.Add(game);
                data.AllGameData.Value.AddRange(game.GameDatas);
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

        public static void UpdatePlayerColor(FourSoulsData data, ICharPlayer charPlayer, string newColor)
        {
            using (var context = new FourSoulsDbContext())
            {
                bool isPlayer = charPlayer is Player;

                // update db and local
                if (isPlayer)
                {
                    context.Players.First(p => p.Id == charPlayer.Id).ColorCode = newColor;
                    data.AllPlayers.Value.First(p => p.Id == charPlayer.Id).ColorCode = newColor;
                }
                else
                {
                    context.Characters.First(p => p.Id == charPlayer.Id).ColorCode = newColor;
                    data.AllCharacters.Value.First(p => p.Id == charPlayer.Id).ColorCode = newColor;
                }
                context.SaveChanges();
            }
        }
    }
}
