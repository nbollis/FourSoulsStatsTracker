using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;

namespace FourSoulsData
{
    [Table("Players")]
    public class Player
    {
        [Key] public int PlayerId { get; set; }
        [Required] public string PlayerName { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int GamesPlayed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Wins { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int CumulativeSouls { get; set; }


        [NotMapped] public int Losses => GamesPlayed - Wins;
        [NotMapped] public double WinRate => Math.Round(Wins / (double)GamesPlayed, 2);
        [NotMapped] public double AverageSouls => Math.Round(CumulativeSouls / (double)GamesPlayed, 2);
    }
}