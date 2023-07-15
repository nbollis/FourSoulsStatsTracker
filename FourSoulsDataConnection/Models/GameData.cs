namespace FourSoulsDataConnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameData")]
    public partial class GameData
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlayerId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterId { get; set; }

        public int Souls { get; set; }

        public int Win { get; set; }

        #region Not Mapped

        [NotMapped]
        public virtual Character Character
        {
            get => _character;
            set
            {
                _character = value;
                CharacterId = _character?.Id ?? 0;
            }
        }

        [NotMapped]
        public virtual Game Game
        {
            get => _game;
            set
            {
                _game = value;
                GameId = _game?.GameId ?? 0;
            }
        }

        [NotMapped]
        public virtual Player Player
        {
            get => _player;
            set
            {
                _player = value;
                PlayerId = _player?.Id ?? 0;
            }
        }

        [NotMapped]
        private double? dataHash;

        [NotMapped]
        private Player _player;

        [NotMapped]
        private Character _character;

        [NotMapped]
        private Game _game;

        [NotMapped]
        public double DataHash
        {
            get
            {
                if (dataHash.HasValue) return dataHash.Value;
                dataHash = new Random().Next();
                return dataHash.Value;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"{Player?.Name ?? ""} : {Character?.Name ?? ""} : {Souls}";
        }
    }
}
