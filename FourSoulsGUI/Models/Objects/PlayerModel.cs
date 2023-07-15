using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;

namespace FourSoulsGUI
{
    public class PlayerModel : Player
    {
        public static PlayerModel Instance => new PlayerModel();

        public PlayerModel() : base()
        {
            Id = 1;
            Name = "Nic";
            Wins = 8;
            GamesPlayed = 16;
            WinRate = 0.5;
            CumulativeSouls = 26;
            AverageSouls = 2.67;
        }
    }
}
