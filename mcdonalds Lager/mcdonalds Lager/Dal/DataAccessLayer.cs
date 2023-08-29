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
            return new SqlConnection(@"Data Source = localhost; Initial Catalog = Storage; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        // method for freestyle script execution, accepts a script as parameter
        public static void ExecuteScript(string script, SqlConnection s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(script);

            string sqlQuery = sb.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, s))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // sends 'select' query and prints result
        public static DataTable GetData(SqlConnection s, string script)
        {
            ExecuteScript(script, s);

            DataTable dt = new DataTable();  // DataTable declaration
            SqlDataAdapter sda = new SqlDataAdapter(script, s);

            sda.Fill(dt);  // fills datatable

            s.Dispose();  // disposes of the opened connection

            return dt;
        }
        // PRINT
        public static void Print(SqlConnection s, string table)
        {
            var x = 0;

            // whatever select script, in this case selects & prints top 5 entries (coffee_type and litres) from the coffee table (hehe) 
            var script = $"SELECT * FROM {table}";

            var dt = GetData(s, script);

            Console.WriteLine("\n");

            // prints column names
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Console.Write($"{dt.Columns[i]}    ");
            }

            Console.WriteLine("\n");

            // prints extracted data, spaced by 15 pr. column.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var cursorLeft = 0;
                for (int n = 1; n < dt.Rows[i].ItemArray.Length; n++)
                {
                    if (n % dt.Rows.Count - 1 == 0)
                        Console.CursorLeft = cursorLeft;
                    else
                        Console.CursorLeft = cursorLeft += 15;

                    Console.Write($"{dt.Rows[i].ItemArray[n]}");
                }
                Console.Write("\n");
            }
        }
    }
}
