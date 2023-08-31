using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    public class DataAccessLayer
    {
        // returns connection string for linked database
        public static SqlConnection GetConnection()
        {
            // not to be included in final push; .gitignore
            return new SqlConnection(@"Data Source = localhost; Initial Catalog = StorageDB; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        // method for freestyle script execution, accepts a script as parameter
        public static void ExecuteScript(string script)
        {
            SqlConnection s = GetConnection();
            s.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append(script);

            string sqlQuery = sb.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, s))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // sends 'select' query and prints result
        public static DataTable GetData(string script)
        {
            SqlConnection s = GetConnection();
            s.Open();
            ExecuteScript(script);

            DataTable dt = new DataTable();  // DataTable declaration
            SqlDataAdapter sda = new SqlDataAdapter(script, s);

            sda.Fill(dt);  // fills datatable

            s.Dispose();  // disposes of the opened connection

            return dt;
        }
    }
}
