﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FourSoulsDataConnection.DataBase
{
    /// <summary>
    /// Calls the data from the database
    /// </summary>
    public class FourSoulsDbAccess
    {
        private FourSoulsDbContext context;

        public FourSoulsDbAccess()
        {
            context = new FourSoulsDbContext();
        }

        public List<Player> GetAllPlayers()
        {
            try
            {
                List<Player> players = context.Players.ToList();
                return players;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Game> GetAllGames()
        {
            try
            {
                List<Game> games = context.Games.ToList();
                return games;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Character> GetAllCharacters()
        {
            try
            {
                List<Character> characters = context.Characters.ToList();
                return characters;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<GameData> GetAllGameData()
        {
            try
            {
                List<GameData> gameDatum = context.GameDatas.ToList();
                return gameDatum;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
