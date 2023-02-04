namespace FourSoulsCore
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

        [NotMapped]
        public virtual Character Character
        {
            get => _character;
            set
            {
                _character = value;
                CharacterId = _character.CharacterId;
            }
        }

        [NotMapped]
        public virtual Game Game
        {
            get => _game;
            set
            {
                _game = value;
                GameId = _game.GameId;
            }
        }

        [NotMapped]
        public virtual Player Player
        {
            get => _player;
            set 
            {
                _player = value;
                PlayerId = _player.PlayerId;
            }
        }


        #region Not Mapped

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
    }
}
