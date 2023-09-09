using System.Linq;

namespace FourSoulsDataConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            GameDatas = new HashSet<GameData>();
        }

        public int GameId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? LengthOfGame { get; set; }

        public int NumberOfPlayers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameData> GameDatas { get; set; }

        [NotMapped] public int WinningPlayer => GameDatas.First(p => p.Win == 1).PlayerId;

        [NotMapped] public int WinningCharacter => GameDatas.First(p => p.Win == 1).CharacterId;
    }
}
