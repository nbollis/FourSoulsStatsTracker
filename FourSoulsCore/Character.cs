namespace FourSoulsCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character()
        {
            GameDatas = new HashSet<GameData>();
        }

        public int CharacterId { get; set; }

        [Required]
        [StringLength(50)]
        public string CharacterName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Wins { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? GamesPlayed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? WinRate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? CumulativeSouls { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? AverageSouls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameData> GameDatas { get; set; }

        public override string ToString()
        {
            return CharacterName;
        }
    }
}
