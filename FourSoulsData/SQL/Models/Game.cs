using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    [Table("Games")]
    public class Game
    {
        [Key] public int GameId { get; set; }
        [Required] public int NumberOfPlayers { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? LengthOfGame { get; set; }
    }
}
