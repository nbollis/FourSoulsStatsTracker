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
        [Required]
        public int Wins { get; set; }
        [Required]
        public int GamesPlayed { get; set; }

        public int Losses => GamesPlayed - Wins;
        public double WinRate => Wins / (double)GamesPlayed;

    }
}