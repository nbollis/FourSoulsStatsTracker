using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    [Table("Characters")]
    public class Character
    {
        [Key] public int CharacterId { get; set; }
        [Required] public string CharacterName { get; set; } = null!;

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
