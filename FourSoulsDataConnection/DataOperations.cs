using FourSoulsDataConnection.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FourSoulsDataConnection
{
    public static class DataOperations
    {
        /// <summary>
        /// Gets the winrate of a specific player, against all other players
        /// </summary>
        /// <param name="data"></param>
        /// <param name="player"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Dictionary<int, double> GetWinRateByPlayer(FourSoulsData data, Player player, GameFilter filter = null)
        {
            Dictionary<int, (int win, int loss)> temp = data.AllPlayers.Value.ToDictionary(p => p.Id, p => (0, 0));
            // all games played by player of interest
            foreach (var game in GetGamesByPlayer(data, player, filter))
            {

                bool win = game.WinningPlayer.Equals(player.Id);
                foreach (var id in game.GameDatas.Select(p => p.PlayerId))
                {
                    var valueTuple = temp[id];
                    if (win)
                    {
                        valueTuple.win += 1;
                    }
                    else
                    {
                        valueTuple.loss += 1;
                    }

                    temp[id] = valueTuple;
                }
            }

            var result = temp.ToDictionary(p => p.Key,
                p => Math.Round(p.Value.win / (double)(p.Value.win + p.Value.loss) * 100, 2));
            return result;
        }

        /// <summary>
        /// Gets the winrate of a specific character, against all other characters
        /// </summary>
        /// <param name="data"></param>
        /// <param name="character"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Dictionary<int, double> GetWinRateByCharacter(FourSoulsData data, Character character, GameFilter filter = null)
        {
            Dictionary<int, (int win, int loss)> temp = data.AllPlayers.Value.ToDictionary(p => p.Id, p => (0, 0));
            // all games played by player of interest
            foreach (var game in GetGamesByCharacter(data, character, filter))
            {

                bool win = game.WinningPlayer.Equals(character.Id);
                foreach (var id in game.GameDatas.Select(p => p.PlayerId))
                {
                    var valueTuple = temp[id];
                    if (win)
                    {
                        valueTuple.win += 1;
                    }
                    else
                    {
                        valueTuple.loss += 1;
                    }

                    temp[id] = valueTuple;
                }
            }

            var result = temp.ToDictionary(p => p.Key,
                p => Math.Round(p.Value.win / (double)(p.Value.win + p.Value.loss) * 100, 2));
            return result;
        }

        /// <summary>
        /// Gets all games a specific player has been a part of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="player"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<Game> GetGamesByPlayer(FourSoulsData data, Player player,
            GameFilter filter = null)
        {
            var result = GetGamesByPlayer(data.AllGames.Value, player);
            if (filter == null)
                return result;
            return filter.Filter(result);
        }

        /// <summary>
        /// Gets all games a specific character has been a part of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="character"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<Game> GetGamesByCharacter(FourSoulsData data, Character character,
            GameFilter filter = null)
        {
            var result = data.AllGames.Value.Where(p => p.GameDatas.Any(m => m.CharacterId == character.Id));
            if (filter == null)
                return result;
            return filter.Filter(result);
        }

        public static IEnumerable<string> GetAllPlayerNames(FourSoulsData data)
        {
            return data.AllPlayers.Value.Select(player => player.Name);
        }

        public static IEnumerable<string> GetAllCharacterNames(FourSoulsData data)
        {
            return data.AllCharacters.Value.Select(character => character.Name);
        }

        public static IEnumerable<(string Name, int Id, int Count, string HexCode)> GetPlayFrequencyForPlayer(FourSoulsData data,
            Player player)
        {
            var games = GetGamesByPlayer(data, player);
            var result = games.SelectMany(p => p.GameDatas)
                .GroupBy(p => p.PlayerId)
                .Where(p => p.Key != player.Id)
                .Select(p => (p.First().Player.Name, p.Key, p.Count(), p.First().Player.ColorCode))
                .OrderByDescending(p => p.Item3);
            return result;
        }





        private static IEnumerable<Game> GetGamesByPlayer(IEnumerable<Game> games, Player player)
        {
            return games.Where(p => p.GameDatas.Any(m => m.PlayerId == player.Id));
        }
    }


}
