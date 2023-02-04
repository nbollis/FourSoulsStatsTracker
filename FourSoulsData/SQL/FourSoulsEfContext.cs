using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    public class FourSoulsEfContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public FourSoulsEfContext(string connectionString)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Database.SetInitializer<EFSampleContext>(new DropCreateDatabaseAlways<EFSampleContext>());
            this.Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameData> GameData { get; set; }

    }
}
