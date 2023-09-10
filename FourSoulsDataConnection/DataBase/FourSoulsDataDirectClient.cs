using System;
using System.Collections.Generic;

namespace FourSoulsDataConnection.DataBase
{
    /// <summary>
    /// Data client to provide data from the database
    /// </summary>
    public class FourSoulsDataDirectClient : IFourSoulsData
    {
        private FourSoulsDbAccess _dbAccess;
        private FourSoulsData _data = null;

        public FourSoulsDataDirectClient(bool getAllData)
        {
            _dbAccess = new FourSoulsDbAccess();
            if (getAllData)
                Data = GetFourSoulsData();
        }

        public FourSoulsData Data
        {
            get => _data = GetFourSoulsData();
            set => _data = value;
        }

        private FourSoulsData GetFourSoulsData()
        {
            try
            {
                FourSoulsData fourSouls = new FourSoulsData()
                {
                    AllPlayers = new Lazy<List<Player>>(() => _dbAccess.GetAllPlayers()),
                    AllGames = new Lazy<List<Game>>(() => _dbAccess.GetAllGames()),
                    AllCharacters = new Lazy<List<Character>>(() => _dbAccess.GetAllCharacters()),
                    AllGameData = new Lazy<List<GameData>>(() => _dbAccess.GetAllGameData())
                };

                return fourSouls;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
