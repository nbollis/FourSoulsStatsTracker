using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;

namespace FourSoulsData
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses => GamesPlayed - Wins;
        public double WinRate => Math.Round(Wins / (double)GamesPlayed, 2);
        public int CumulativeSouls { get; set; }
        public double AverageSouls => Math.Round(CumulativeSouls / (double)GamesPlayed, 2);
    }
}