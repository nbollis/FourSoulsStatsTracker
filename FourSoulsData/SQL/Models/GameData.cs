using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    [Table("GameData")]
    public class GameData
    {
        [Key, Column(Order = 0)] public int GameId { get; set; }

        [Key, Column(Order = 1)] public int PlayerId { get; set; }

        [Key, Column(Order = 2)] public int CharacterId { get; set; }

        [Required] public int Souls { get; set; }

        [Required] public int Win { get; set; }
        

        [NotMapped] public string PlayerName => SqlConnection.NameKeyDictionary[PlayerId];
        [NotMapped] public string CharacterName => Enum.GetNames<CharacterName>()[CharacterId];
        [NotMapped] public double GameDataHash => Random.Shared.Next();

    }
}
