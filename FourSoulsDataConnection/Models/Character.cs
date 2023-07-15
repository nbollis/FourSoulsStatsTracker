namespace FourSoulsDataConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Character : ICharPlayer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character()
        {
            GameDatas = new HashSet<GameData>();
        }

        [Column("CharacterId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CharacterName")]
        public string Name { get; set; }

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

        [NotMapped]
        public string IconPath;

        public override string ToString()
        {
            return Name;
        }
        public bool Equals(ICharPlayer other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(other, null))
                return false;
            else
                return (Id == other.Id && Name == other.Name);
        }
    }
}
