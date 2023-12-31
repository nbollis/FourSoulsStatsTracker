namespace FourSoulsDataConnection
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Player : ICharPlayer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            GameDatas = new HashSet<GameData>();
            GenerateNotMappedData();
        }

        [Column("PlayerId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("PlayerName")]
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

        [StringLength(50)]
        [Column("ColorCode")]
        public string ColorCode { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }


        private void GenerateNotMappedData()
        {
            //AllGamesPlayed = FourSoulsGlobalData.AllGames.Where(p => p.GameDatas.Any(m => m.PlayerId == Id)).ToList();
            //GamesByPlayerCount = AllGamesPlayed.GroupBy(p => p.NumberOfPlayers)
            //    .ToDictionary(p => p.Key, p => p.ToList());
            //GamesByCharacter = AllGamesPlayed.GroupBy(p => p.GameDatas.First(m => m.PlayerId == Id).CharacterId)
            //    .ToDictionary(p => p.Key, p => p.ToList());
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

        #region Not Mapped


        [NotMapped]
        public string IconPath;

        [NotMapped]
        public List<Game> AllGamesPlayed { get; private set; }

        [NotMapped]
        public Dictionary<int, List<Game>> GamesByPlayerCount { get; private set; }

        [NotMapped]
        public Dictionary<int, List<Game>> GamesByCharacter { get; private set; }

        #endregion
    }
}
