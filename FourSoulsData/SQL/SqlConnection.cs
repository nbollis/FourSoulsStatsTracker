using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsData
{
    public static class SqlConnection
    {
        public static FourSoulsEfContext EfContext { get; set; }

        public static Dictionary<int, string> NameKeyDictionary { get; set; } = null!;

        static SqlConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "NICS-DESKTOP"; // update me
            builder.UserID = "admin"; // update me
            builder.Password = "admin"; // update me
            builder.InitialCatalog = "FourSoulsStats";
            EfContext = new FourSoulsEfContext(builder.ConnectionString);

            UpdateNameKeyDictionary();
        }

        public static void UpdateNameKeyDictionary()
        {
            NameKeyDictionary = EfContext.Players.ToDictionary(p => p.PlayerId, p => p.PlayerName);
            NameKeyDictionary.Add(0, "");
        }
    }
}
