using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;

namespace FourSoulsGUI
{
    public class PlayerPageModel : PlayerPageViewModel
    {
        public static PlayerPageModel Instance = new PlayerPageModel();

        public PlayerPageModel() : base()
        {
            for (int i = 0; i < 10; i++)
            {
                AllPlayers.Add(new PlayerModel() as Player);
            }
        }
    }
}
