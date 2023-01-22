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

        static SqlConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "NICS-DESKTOP"; // update me
            builder.UserID = "admin"; // update me
            builder.Password = "admin"; // update me
            builder.InitialCatalog = "FourSoulsStats";
            EfContext = new FourSoulsEfContext(builder.ConnectionString);
        }
    }
}
