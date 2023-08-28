using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class DataAccessLayer
    {
        // returns connection string for linked database
        static SqlConnection GetConnection()
        {
            // not to be included in final push; .gitignore
            return new SqlConnection(@"Data Source = localhost; Initial Catalog = Storage; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        // method for freestyle script execution, accepts a script as parameter
        static void ExecuteScript(string script, SqlConnection s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(script);

            string sqlQuery = sb.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, s))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
