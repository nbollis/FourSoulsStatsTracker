using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SqlServer
{
    public class EFSampleContext : DbContext
    {
        public EFSampleContext(string connectionString)
        {
            Database.SetInitializer<EFSampleContext>(new DropCreateDatabaseAlways<EFSampleContext>());
            this.Database.Connection.ConnectionString = connectionString;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }

    public class FourSoulsEfContext : DbContext
    {
        public FourSoulsEfContext(string connectionString)
        {
            Database.SetInitializer<EFSampleContext>(new DropCreateDatabaseAlways<EFSampleContext>());
            this.Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Player> Players
    }
}
