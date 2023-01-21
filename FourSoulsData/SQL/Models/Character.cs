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
        [Required]
        public int Wins { get; set; }
        [Required]
        public int GamesPlayed { get; set; }

        public int Losses => GamesPlayed - Wins;
        public double WinRate => Wins / (double)GamesPlayed;

    }
}
