using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsDataConnection.DataBase
{
    public class FourSoulsDataDirectClient : IFourSoulsData
    {
        private FourSoulsDbAccess _dbAccess;
        private FourSoulsData _data = null;

        public FourSoulsDataDirectClient(bool getAllData)
        {
            _dbAccess = new FourSoulsDbAccess();
            if (getAllData)
                Data = GetMetaDrawData();
        }

        public FourSoulsData Data
        {
            get => _data = GetMetaDrawData();
            set => _data = value;
        }

        private FourSoulsData GetMetaDrawData()
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
