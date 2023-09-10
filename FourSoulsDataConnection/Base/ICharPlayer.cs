using System;
using System.Collections.Generic;

namespace FourSoulsDataConnection
{
    public interface ICharPlayer : IEquatable<ICharPlayer>
    {
        int Id { get; set; }
        string Name { get; set; }
        int? Wins { get; set; }
        int? GamesPlayed { get; set; }
        double? WinRate { get; set; }
        int? CumulativeSouls { get; set; }
        double? AverageSouls { get; set; }
        ICollection<GameData> GameDatas { get; set; }
    }
}
