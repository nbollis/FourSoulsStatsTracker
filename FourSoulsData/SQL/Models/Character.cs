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
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        public int Wins { get; set; }
        public int Losses => GamesPlayed - Wins;
        public int GamesPlayed { get; set; }
        public double WinRate => Math.Round(Wins / (double)GamesPlayed, 2);
        public int CumulativeSouls { get; set; }
        public double AverageSouls => Math.Round(CumulativeSouls / (double)GamesPlayed, 2);
    }
}
