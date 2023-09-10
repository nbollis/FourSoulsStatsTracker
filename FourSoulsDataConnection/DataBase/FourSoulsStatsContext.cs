using System.Data.Entity;

namespace FourSoulsDataConnection
{
    public partial class FourSoulsDbContext : DbContext
    {
        public FourSoulsDbContext()
            : base("data source=NICS-DESKTOP;initial catalog=FourSoulsStats;persist security info=True;user id=admin;password=admin;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<GameData> GameDatas { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Character>()
                .HasMany(e => e.GameDatas)
                .WithRequired(e => e.Character)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.GameDatas)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.GameDatas)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);
        }
    }
}
